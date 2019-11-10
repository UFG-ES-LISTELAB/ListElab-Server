using ListElab.Data.Repositorios;
using ListElab.Dominio.Conceitos.ListaObj;
using ListElab.Dominio.Conceitos.QuestaoObj;
using ListElab.Dominio.Conceitos.RespostaObj;
using ListElab.Dominio.Dtos;
using ListElab.Dominio.Enumeradores;
using ListElab.Servico.Conversores.Interfaces;
using System;
using System.Linq;

namespace ListElab.Servico.Conversores
{
    /// <summary>
    /// Conversor de lista de questões.
    /// </summary>
    public class ConversorListaDeQuestoes : IConversor<DtoListaQuestoes, ListaQuestoes>
    {
        private IRepositorio<Questao<Discursiva>> repositorioQuestao;

        public DtoListaQuestoes Converta(ListaQuestoes objeto)
        {
            DtoListaQuestoes dto = null;
            var conversorQuestoes = new ConversorQuestaoDiscursiva();

            if (objeto != null)
            {
                dto = new DtoListaQuestoes();
                dto.Id = objeto.Id;
                dto.Usuario = objeto.Usuario;
                dto.Titulo = objeto.Titulo;
                dto.ProntaParaAplicacao = objeto.ProntaParaAplicacao;

                dto.Questoes = objeto.Discursivas.Select(x => conversorQuestoes.Converta(x)).ToList();
            }

            return dto;
        }

        public ListaQuestoes Converta(DtoListaQuestoes dto)
        {
            ListaQuestoes lista = null;
            var conversorQuestoes = new ConversorQuestaoDiscursiva();

            if (dto != null)
            {
                lista = new ListaQuestoes();

                if (dto.Id != null && dto.Id != Guid.Empty)
                {
                    lista.Id = dto.Id;
                }

                var questoes = RepositorioQuestao().ConsulteListaDeIds(x => x.Id, dto.Questoes.Select(x => x.Id).ToArray());

                var nivelDificuldade = dto.Questoes.Sum(x => (int)x.NivelDificuldade) / dto.Questoes.Count;
                lista.NivelDificuldade = nivelDificuldade == 0 ? 1 : nivelDificuldade;
                lista.Usuario = dto.Usuario;
                lista.Titulo = dto.Titulo;
                lista.ProntaParaAplicacao = lista.ProntaParaAplicacao;
                lista.AreasDeConhecimento = questoes.Select(x => x.AreaDeConhecimento.Codigo).ToList();
                lista.TempoEsperadoResposta = questoes.Sum(x => x.TempoMaximoDeResposta);
                lista.Tags = questoes.SelectMany(x => x.Tags).ToList();
                lista.Disciplinas = questoes.Select(x => x.Disciplina.Codigo).ToList();
                lista.Discursivas = questoes.Where(x => x.Tipo == TipoQuestao.Discursiva).ToList();
            }

            return lista;
        }

        private IRepositorio<Questao<Discursiva>> RepositorioQuestao()
        {
            return repositorioQuestao ?? (repositorioQuestao = new Repositorio<Questao<Discursiva>>());
        }
    }
}
