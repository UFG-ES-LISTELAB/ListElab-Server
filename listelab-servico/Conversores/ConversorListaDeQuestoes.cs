using ListElab.Data.Repositorios;
using ListElab.Dominio.Conceitos.AreaDeConhecimentoObj;
using ListElab.Dominio.Conceitos.DisciplinaObj;
using ListElab.Dominio.Conceitos.ListaObj;
using ListElab.Dominio.Dtos;
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
        private IRepositorio<Disciplina> repositorioDisciplina;
        private IRepositorio<AreaDeConhecimento> repositorioAreaConhecimento;

        public DtoListaQuestoes Converta(ListaQuestoes objeto)
        {
            DtoListaQuestoes dto = null;
            var conversorQuestoes = new ConversorQuestaoDiscursiva();

            if (objeto != null)
            {
                dto = new DtoListaQuestoes();
                dto.Id = objeto.Id;
                dto.NivelDificuldade = objeto.NivelDificuldade;
                dto.Tags = objeto.Tags;
                dto.Usuario = objeto.Usuario;
                dto.Titulo = objeto.Titulo;
                dto.ProntaParaAplicacao = objeto.ProntaParaAplicacao;

                if (objeto.AreaDeConhecimento != null)
                {
                    dto.AreaDeConhecimento = new DtoAreaDoConhecimento { Codigo = objeto.AreaDeConhecimento.Codigo, Descricao = objeto.AreaDeConhecimento.Descricao };
                }

                if (objeto.Disciplina != null)
                {
                    dto.Disciplina = new DtoDisciplina { Codigo = objeto.Disciplina.Codigo, Descricao = objeto.Disciplina.Descricao };
                }

                dto.Discursivas = objeto.Discursivas.Select(x => conversorQuestoes.Converta(x)).ToList();
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

                lista.NivelDificuldade = dto.NivelDificuldade;
                lista.Tags = dto.Tags;
                lista.Usuario = dto.Usuario;
                lista.Titulo = dto.Titulo;
                lista.ProntaParaAplicacao = lista.ProntaParaAplicacao;

                if (dto.AreaDeConhecimento != null)
                {
                    lista.AreaDeConhecimento = RepositorioAreaDeConhecimento().ConsulteUm(x => x.Codigo == dto.AreaDeConhecimento.Codigo);
                }

                if (dto.Disciplina != null)
                {
                    lista.Disciplina = RepositorioDisciplina().ConsulteUm(x => x.Codigo == dto.Disciplina.Codigo);

                }

                lista.Discursivas = dto.Discursivas.Select(x => conversorQuestoes.Converta(x)).ToList();
            }

            return lista;
        }

        private IRepositorio<Disciplina> RepositorioDisciplina()
        {
            return repositorioDisciplina ?? (repositorioDisciplina = new Repositorio<Disciplina>());
        }

        private IRepositorio<AreaDeConhecimento> RepositorioAreaDeConhecimento()
        {
            return repositorioAreaConhecimento ?? (repositorioAreaConhecimento = new Repositorio<AreaDeConhecimento>());
        }
    }
}
