using ListElab.Data.Repositorios;
using ListElab.Dominio.Conceitos.ListaObj;
using ListElab.Dominio.Conceitos.QuestaoObj;
using ListElab.Dominio.Conceitos.RespostaObj;
using ListElab.Dominio.Dtos;
using ListElab.Dominio.Enumeradores;
using ListElab.Servico.Conversores.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ListElab.Servico.Conversores
{
    /// <summary>
    /// Conversor de lista de questões.
    /// </summary>
    public class ConversorListaDeQuestoes : IConversor<DtoListaQuestoes, ListaQuestoes>
    {
        private IRepositorio<Questao<Discursiva>> repositorioQuestaoDiscursiva;
        private IRepositorio<Questao<MultiplaEscolha>> repositorioQuestaoMultiplaEscolha;

        public DtoListaQuestoes Converta(ListaQuestoes objeto)
        {
            DtoListaQuestoes dto = null;
            var conversorQuestoesDiscursiva = new ConversorQuestao<Discursiva, DtoQuestaoDiscursiva>();
            var conversorQuestoesMultiplaEscolha = new ConversorQuestao<MultiplaEscolha, DtoQuestaoMultiplaEscolha>();

            if (objeto != null)
            {
                dto = new DtoListaQuestoes();
                dto.Id = objeto.Id;
                dto.Usuario = objeto.Usuario;
                dto.Titulo = objeto.Titulo;
                dto.ProntaParaAplicacao = objeto.ProntaParaAplicacao;

                dto.QuestoesDiscursiva = objeto.QuestoesDiscursivas.Select(x => new DtoQuestaoDaLista<DtoQuestaoDiscursiva> { Questao = conversorQuestoesDiscursiva.Converta(x.Questao) as DtoQuestaoDiscursiva, Numero = x.Numero, Peso = x.Peso }).ToList();
                dto.QuestoesMultiplaEscolha = objeto.QuestoesMultiplaEscolha.Select(x => new DtoQuestaoDaLista<DtoQuestaoMultiplaEscolha> { Questao = conversorQuestoesMultiplaEscolha.Converta(x.Questao) as DtoQuestaoMultiplaEscolha, Numero = x.Numero, Peso = x.Peso }).ToList();
            }

            return dto;
        }

        public ListaQuestoes Converta(DtoListaQuestoes dto)
        {
            ListaQuestoes lista = null;
            var conversorQuestoesDiscursiva = new ConversorQuestao<Discursiva, DtoQuestaoDiscursiva>();
            var conversorQuestoesMultiplaEscolha = new ConversorQuestao<MultiplaEscolha, DtoQuestaoMultiplaEscolha>();

            if (dto != null)
            {
                lista = new ListaQuestoes();

                if (dto.Id != null && dto.Id != Guid.Empty)
                {
                    lista.Id = dto.Id;
                }

                List<QuestaoDaLista<Discursiva>> questoesDiscursiva = ConvertaQuestaoDiscursiva(dto);
                List<QuestaoDaLista<MultiplaEscolha>> questoesMultiplaEscolha = ConvertaQuestaoMultiplaEscolha(dto);

                var areasDeConhecimento = questoesDiscursiva.Select(x => x.Questao.AreaDeConhecimento.Codigo).ToList();
                areasDeConhecimento.AddRange(questoesMultiplaEscolha.Select(x => x.Questao.AreaDeConhecimento.Codigo).ToList());

                var disciplinas = questoesDiscursiva.Select(x => x.Questao.Disciplina.Codigo).ToList();
                disciplinas.AddRange(questoesMultiplaEscolha.Select(x => x.Questao.Disciplina.Codigo).ToList());

                var tags = questoesDiscursiva.SelectMany(x => x.Questao.Tags).ToList();
                tags.AddRange(questoesMultiplaEscolha.SelectMany(x => x.Questao.Tags).ToList());

                var nivelDificuldade = dto.QuestoesDiscursiva.Sum(x => (int)x.Questao.NivelDificuldade) + dto.QuestoesMultiplaEscolha.Sum(x => (int)x.Questao.NivelDificuldade) / dto.QuestoesDiscursiva.Count + dto.QuestoesMultiplaEscolha.Count;
                lista.NivelDificuldade = nivelDificuldade == 0 ? 1 : nivelDificuldade;
                lista.Usuario = dto.Usuario;
                lista.Titulo = dto.Titulo;
                lista.ProntaParaAplicacao = lista.ProntaParaAplicacao;
                lista.AreasDeConhecimento = areasDeConhecimento;
                lista.TempoEsperadoResposta = questoesDiscursiva.Sum(x => x.Questao.TempoMaximoDeResposta) + questoesMultiplaEscolha.Sum(x => x.Questao.TempoMaximoDeResposta);
                lista.Tags = tags;
                lista.Disciplinas = disciplinas;
                lista.QuestoesDiscursivas = questoesDiscursiva.Where(x => x.Questao.Tipo == TipoQuestao.Discursiva).ToList();
                lista.QuestoesMultiplaEscolha = questoesMultiplaEscolha.Where(x => x.Questao.Tipo == TipoQuestao.MultiplaEscolha).ToList();
            }

            return lista;
        }

        private List<QuestaoDaLista<MultiplaEscolha>> ConvertaQuestaoMultiplaEscolha(DtoListaQuestoes dto)
        {
            var questoesMultiplaEscolha = new List<QuestaoDaLista<MultiplaEscolha>>();

            foreach (var questao in dto.QuestoesMultiplaEscolha)
            {
                try
                {
                    var questaLista = new QuestaoDaLista<MultiplaEscolha>();
                    questaLista.Numero = questao.Numero;
                    questaLista.Peso = questao.Peso;
                    questaLista.Questao = RepositorioQuestaoMultiplaEscolha().ConsulteUm(x => x.Id == questao.Questao.Id);

                    questoesMultiplaEscolha.Add(questaLista);
                }
                catch (Exception)
                {
                    throw new Exception("Houve um erro ao recuperar a questão passada, o identificador da questão corresponde a alguma questão de múltipla escolha?");
                }
            }

            return questoesMultiplaEscolha;
        }

        private List<QuestaoDaLista<Discursiva>> ConvertaQuestaoDiscursiva(DtoListaQuestoes dto)
        {
            var questoesDiscursiva = new List<QuestaoDaLista<Discursiva>>();

            foreach (var questao in dto.QuestoesDiscursiva)
            {
                try
                {
                    var questaLista = new QuestaoDaLista<Discursiva>();

                    questaLista.Numero = questao.Numero;
                    questaLista.Peso = questao.Peso;
                    questaLista.Questao = RepositorioQuestaoDiscursiva().ConsulteUm(x => x.Id == questao.Questao.Id);

                    questoesDiscursiva.Add(questaLista);
                }
                catch (Exception)
                {
                    throw new Exception("Houve um erro ao recuperar a questão passada, o identificador da questão corresponde a alguma questão discursiva?");
                }
            }

            return questoesDiscursiva;
        }

        private IRepositorio<Questao<Discursiva>> RepositorioQuestaoDiscursiva()
        {
            return repositorioQuestaoDiscursiva ?? (repositorioQuestaoDiscursiva = new Repositorio<Questao<Discursiva>>());
        }

        private IRepositorio<Questao<MultiplaEscolha>> RepositorioQuestaoMultiplaEscolha()
        {
            return repositorioQuestaoMultiplaEscolha ?? (repositorioQuestaoMultiplaEscolha = new Repositorio<Questao<MultiplaEscolha>>());
        }
    }
}
