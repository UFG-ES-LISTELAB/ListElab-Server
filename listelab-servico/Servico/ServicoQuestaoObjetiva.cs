using ListElab.Data.Repositorios;
using ListElab.Dominio.Conceitos.QuestaoObj;
using ListElab.Dominio.Conceitos.RespostaObj;
using ListElab.Dominio.InterfaceDeServico;
using ListElab.Servico.Validacoes;
namespace ListElab.Servico.Servico
{
    public class ServicoQuestaoObjetiva : ServicoPadrao<Questao<Objetiva>>, IServicoQuestaoObjetiva
    {
        private IRepositorio<Questao<Objetiva>> _repositorio;
        private ValidacoesQuestaoObjetiva _validador;

        /// <summary>
        /// Retorna o repositório de questões discursivas.
        /// </summary>
        /// <returns>Uma instância do repositório.</returns>
        protected override IRepositorio<Questao<Objetiva>> Repositorio()
        {
            return _repositorio ?? (_repositorio = new Repositorio<Questao<Objetiva>>());
        }

        /// <summary>
        /// Retorna uma instância do validador de questões discursivas.
        /// </summary>
        /// <returns>Uma instância do validador.</returns>
        protected override ValidadorPadrao<Questao<Objetiva>> Validador()
        {
            return _validador ?? (_validador = new ValidacoesQuestaoObjetiva());
        }
    }
}
