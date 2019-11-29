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
        private IRepositorio<Questao<AssociacaoDeColunas>> repositorioQuestaoAssociacaoDeColunas;
        private IRepositorio<Questao<VerdadeiroOuFalso>> repositorioQuestaoVerdadeiroOuFalso;

        private List<QuestaoDaLista<Discursiva>> questoesDiscursiva;
        private List<QuestaoDaLista<MultiplaEscolha>> questoesMultiplaEscolha;
        private List<QuestaoDaLista<AssociacaoDeColunas>> questoesAssociacaoColunas;
        private List<QuestaoDaLista<VerdadeiroOuFalso>> questoesVerdadeiroOuFalso;

        /// <summary>
        /// Converte uma lista para seu dto.
        /// </summary>
        /// <param name="objeto">O objeto a ser convertido.</param>
        /// <returns>O Dto convertido.</returns>
        public DtoListaQuestoes Converta(ListaQuestoes objeto)
        {
            DtoListaQuestoes dto = null;

            if (objeto != null)
            {
                dto = new DtoListaQuestoes();
                dto.Id = objeto.Id;
                dto.Usuario = objeto.Usuario;
                dto.Titulo = objeto.Titulo;
                dto.ProntaParaAplicacao = objeto.ProntaParaAplicacao;
                dto.NivelDeDificuldade = objeto.NivelDificuldade;

                dto.QuestoesDiscursiva = objeto.QuestoesDiscursivas.Select(x => new DtoQuestaoDaLista<DtoQuestaoDiscursiva> { Questao = ConversorQuestaoDiscursiva().Converta(x.Questao), Numero = x.Numero, Peso = x.Peso }).ToList();
                dto.QuestoesMultiplaEscolha = objeto.QuestoesMultiplaEscolha.Select(x => new DtoQuestaoDaLista<DtoQuestaoMultiplaEscolha> { Questao = ConversorQuestaoMultliplaEscolha().Converta(x.Questao), Numero = x.Numero, Peso = x.Peso }).ToList();
                dto.QuestoesAssociacaoDeColunas = objeto.QuestoesAssociacaoDeColunas.Select(x => new DtoQuestaoDaLista<DtoQuestaoAssociacaoDeColunas> { Questao = ConversorQuestaoAssociacaoDeColuna().Converta(x.Questao), Numero = x.Numero, Peso = x.Peso }).ToList();
                dto.QuestoesVerdadeiroOuFalso = objeto.QuestoesVerdadeiroOuFalso.Select(x => new DtoQuestaoDaLista<DtoQuestaoVerdadeiroOuFalso> { Questao = ConversorQuestaoVerdadeiroOuFalso().Converta(x.Questao), Numero = x.Numero, Peso = x.Peso }).ToList();

                dto.TiposDeQuestao = objeto.QuestoesDiscursivas.Select(x => x.Questao.Tipo)
                    .Union(objeto.QuestoesMultiplaEscolha.Select(x => x.Questao.Tipo))
                    .Union(objeto.QuestoesVerdadeiroOuFalso.Select(x => x.Questao.Tipo))
                    .Union(objeto.QuestoesAssociacaoDeColunas.Select(x => x.Questao.Tipo))
                    .ToList();
            }

            return dto;
        }

        /// <summary>
        /// Converte um dto de lista para seu objeto.
        /// </summary>
        /// <param name="dto">Dto a ser convertido.</param>
        /// <returns>Retorna o objeto convertido.</returns>
        public ListaQuestoes Converta(DtoListaQuestoes dto)
        {
            ListaQuestoes lista = null;

            if (dto != null)
            {
                lista = new ListaQuestoes();

                if (dto.Id != null && dto.Id != Guid.Empty)
                {
                    lista.Id = dto.Id;
                }

                ObtenhaQuestoesDaLista(dto);

                var areasDeConhecimento = ObtenhaAreasDeConhecimentoDaLista();
                var disciplinas = ObtenhaDisciplinhasDaLista();
                var tags = ObtenhaTagsDaLista();
                int nivelDificuldade = ObtenhaNivelDeDificuldadeDaLista();

                lista.NivelDificuldade = nivelDificuldade == 0 ? 1 : nivelDificuldade;
                lista.Usuario = dto.Usuario;
                lista.Titulo = dto.Titulo;
                lista.ProntaParaAplicacao = lista.ProntaParaAplicacao;
                lista.AreasDeConhecimento = areasDeConhecimento;
                lista.TempoEsperadoResposta = questoesDiscursiva.Sum(x => x.Questao.TempoMaximoDeResposta) + questoesMultiplaEscolha.Sum(x => x.Questao.TempoMaximoDeResposta) + questoesAssociacaoColunas.Sum(x => x.Questao.TempoMaximoDeResposta);
                lista.Tags = tags;
                lista.Disciplinas = disciplinas;
                PreenchaDadosDasQuestoes(lista);
            }

            return lista;
        }

        private void ObtenhaQuestoesDaLista(DtoListaQuestoes dto)
        {
            questoesDiscursiva = ConvertaQuestaoDiscursiva(dto);
            questoesMultiplaEscolha = ConvertaQuestaoMultiplaEscolha(dto);
            questoesAssociacaoColunas = ConvertaQuestaoAssociacaoDeColunas(dto);
            questoesVerdadeiroOuFalso = ConvertaQuestaoVerdadeiroOuFalso(dto);
        }

        #region DADOS DERIVADOES DE QUESTÕES

        private void PreenchaDadosDasQuestoes(ListaQuestoes lista)
        {
            lista.QuestoesDiscursivas = questoesDiscursiva.Where(x => x.Questao.Tipo == TipoQuestao.Discursiva).ToList();
            lista.QuestoesMultiplaEscolha = questoesMultiplaEscolha.Where(x => x.Questao.Tipo == TipoQuestao.MultiplaEscolha).ToList();
            lista.QuestoesAssociacaoDeColunas = questoesAssociacaoColunas.Where(x => x.Questao.Tipo == TipoQuestao.Associacao).ToList();
            lista.QuestoesVerdadeiroOuFalso = questoesVerdadeiroOuFalso.Where(x => x.Questao.Tipo == TipoQuestao.VerdadeiroOuFalso).ToList();
        }

        private int ObtenhaNivelDeDificuldadeDaLista()
        {
            return (questoesDiscursiva.Sum(x => (int)x.Questao.NivelDificuldade) + questoesMultiplaEscolha.Sum(x => (int)x.Questao.NivelDificuldade) +
                                questoesAssociacaoColunas.Sum(x => (int)x.Questao.NivelDificuldade) + questoesVerdadeiroOuFalso.Sum(x => (int)x.Questao.NivelDificuldade))
                                / (questoesAssociacaoColunas.Count + questoesVerdadeiroOuFalso.Count + questoesDiscursiva.Count + questoesMultiplaEscolha.Count);
        }

        private List<string> ObtenhaTagsDaLista()
        {
            var tags = questoesDiscursiva.SelectMany(x => x.Questao.Tags).ToList();
            tags.AddRange(questoesMultiplaEscolha.SelectMany(x => x.Questao.Tags).ToList());
            tags.AddRange(questoesAssociacaoColunas.SelectMany(x => x.Questao.Tags).ToList());
            tags.AddRange(questoesVerdadeiroOuFalso.SelectMany(x => x.Questao.Tags).ToList());
            return tags;
        }

        private List<string> ObtenhaDisciplinhasDaLista()
        {
            var disciplinas = questoesDiscursiva.Select(x => x.Questao.Disciplina.Codigo).ToList();
            disciplinas.AddRange(questoesMultiplaEscolha.Select(x => x.Questao.Disciplina.Codigo).ToList());
            disciplinas.AddRange(questoesAssociacaoColunas.Select(x => x.Questao.Disciplina.Codigo).ToList());
            disciplinas.AddRange(questoesVerdadeiroOuFalso.Select(x => x.Questao.Disciplina.Codigo).ToList());
            return disciplinas;
        }

        private List<string> ObtenhaAreasDeConhecimentoDaLista()
        {
            var areasDeConhecimento = questoesDiscursiva.Select(x => x.Questao.AreaDeConhecimento.Codigo).ToList();
            areasDeConhecimento.AddRange(questoesMultiplaEscolha.Select(x => x.Questao.AreaDeConhecimento.Codigo).ToList());
            areasDeConhecimento.AddRange(questoesAssociacaoColunas.Select(x => x.Questao.AreaDeConhecimento.Codigo).ToList());
            areasDeConhecimento.AddRange(questoesVerdadeiroOuFalso.Select(x => x.Questao.AreaDeConhecimento.Codigo).ToList());
            return areasDeConhecimento;
        }

        #endregion

        #region REPOSITÓRIOS

        private IRepositorio<Questao<Discursiva>> RepositorioQuestaoDiscursiva()
        {
            return repositorioQuestaoDiscursiva ?? (repositorioQuestaoDiscursiva = new Repositorio<Questao<Discursiva>>());
        }

        private IRepositorio<Questao<MultiplaEscolha>> RepositorioQuestaoMultiplaEscolha()
        {
            return repositorioQuestaoMultiplaEscolha ?? (repositorioQuestaoMultiplaEscolha = new Repositorio<Questao<MultiplaEscolha>>());
        }

        private IRepositorio<Questao<AssociacaoDeColunas>> RepositorioQuestaoAssociacaoDeColunas()
        {
            return repositorioQuestaoAssociacaoDeColunas ?? (repositorioQuestaoAssociacaoDeColunas = new Repositorio<Questao<AssociacaoDeColunas>>());
        }

        private IRepositorio<Questao<VerdadeiroOuFalso>> RepositorioQuestaoVerdadeiroOuFalso()
        {
            return repositorioQuestaoVerdadeiroOuFalso ?? (repositorioQuestaoVerdadeiroOuFalso = new Repositorio<Questao<VerdadeiroOuFalso>>());
        }

        #endregion

        #region CONVERSORES DE QUESTÕES

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

        private List<QuestaoDaLista<VerdadeiroOuFalso>> ConvertaQuestaoVerdadeiroOuFalso(DtoListaQuestoes dto)
        {
            var questoesAssociacaoDeColunas = new List<QuestaoDaLista<VerdadeiroOuFalso>>();

            foreach (var questao in dto.QuestoesVerdadeiroOuFalso)
            {
                try
                {
                    var questaLista = new QuestaoDaLista<VerdadeiroOuFalso>();
                    questaLista.Numero = questao.Numero;
                    questaLista.Peso = questao.Peso;
                    questaLista.Questao = RepositorioQuestaoVerdadeiroOuFalso().ConsulteUm(x => x.Id == questao.Questao.Id);

                    questoesAssociacaoDeColunas.Add(questaLista);
                }
                catch (Exception)
                {
                    throw new Exception("Houve um erro ao recuperar a questão passada, o identificador da questão corresponde a alguma questão de verdadeiro ou falso?");
                }
            }

            return questoesAssociacaoDeColunas;
        }

        private List<QuestaoDaLista<AssociacaoDeColunas>> ConvertaQuestaoAssociacaoDeColunas(DtoListaQuestoes dto)
        {
            var questoesAssociacaoDeColunas = new List<QuestaoDaLista<AssociacaoDeColunas>>();

            foreach (var questao in dto.QuestoesAssociacaoDeColunas)
            {
                try
                {
                    var questaLista = new QuestaoDaLista<AssociacaoDeColunas>();
                    questaLista.Numero = questao.Numero;
                    questaLista.Peso = questao.Peso;
                    questaLista.Questao = RepositorioQuestaoAssociacaoDeColunas().ConsulteUm(x => x.Id == questao.Questao.Id);

                    questoesAssociacaoDeColunas.Add(questaLista);
                }
                catch (Exception)
                {
                    throw new Exception("Houve um erro ao recuperar a questão passada, o identificador da questão corresponde a alguma questão de associação de colunas?");
                }
            }

            return questoesAssociacaoDeColunas;
        }

        private ConversorQuestaoDiscursiva ConversorQuestaoDiscursiva()
        {
            return new ConversorQuestaoDiscursiva();
        }

        private ConversorQuestaoMultiplaEscolha ConversorQuestaoMultliplaEscolha()
        {
            return new ConversorQuestaoMultiplaEscolha();
        }

        private ConversorQuestaoAssociacaoDeColunas ConversorQuestaoAssociacaoDeColuna()
        {
            return new ConversorQuestaoAssociacaoDeColunas();
        }

        private ConversorQuestaoVerdadeiroOuFalso ConversorQuestaoVerdadeiroOuFalso()
        {
            return new ConversorQuestaoVerdadeiroOuFalso();
        }

        #endregion
    }
}
