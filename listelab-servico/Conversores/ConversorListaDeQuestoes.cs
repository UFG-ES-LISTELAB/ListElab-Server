using ListElab.Dominio.Conceitos.ListaObj;
using ListElab.Dominio.Dtos;
using ListElab.Servico.Conversores.Interfaces;
using System.Linq;

namespace ListElab.Servico.Conversores
{
    /// <summary>
    /// Conversor de lista de questões.
    /// </summary>
    public class ConversorListaDeQuestoes : IConversor<DtoListaQuestoes, ListaQuestoes>
    {
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
                dto.AreaDeConhecimento = new ConversorAreaDeConhecimento().Converta(objeto.AreaDeConhecimento);
                dto.Disciplina = new ConversorDisciplina().Converta(objeto.Disciplina);
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
                lista.NivelDificuldade = dto.NivelDificuldade;
                lista.Tags = dto.Tags;
                lista.Usuario = dto.Usuario;
                lista.Titulo = dto.Titulo;
                lista.AreaDeConhecimento = new ConversorAreaDeConhecimento().Converta(dto.AreaDeConhecimento).GetValueOrDefault();
                lista.Disciplina = new ConversorDisciplina().Converta(dto.Disciplina).GetValueOrDefault();
                lista.Discursivas = dto.Discursivas.Select(x => conversorQuestoes.Converta(x)).ToList();
            }

            return lista;
        }
    }
}
