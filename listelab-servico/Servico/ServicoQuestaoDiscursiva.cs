using listelab_data.Repositorios;
using listelab_dominio.Conceitos;
using listelab_dominio.Conceitos.QuestaoObj;
using listelab_dominio.Conceitos.RespostaObj;
using listelab_dominio.InterfaceDeServico;
using listelab_servico.Validacoes;

namespace listelab_servico.Servico
{
    public class ServicoQuestaoDiscursiva : ServicoPadrao<QuestaoDiscursiva>, IServicoQuestaoDiscursiva
    {
        private IRepositorio<QuestaoDiscursiva> _repositorio;
        private ValidacoesQuestaoDiscursiva _validador;

        /// <summary>
        /// Retorna o repositório de questões discursivas.
        /// </summary>
        /// <returns>Uma instância do repositório.</returns>
        protected override IRepositorio<QuestaoDiscursiva> Repositorio()
        {
            return _repositorio ?? (_repositorio = new Repositorio<QuestaoDiscursiva>());
        }

        /// <summary>
        /// Retorna uma instância do validador de questões discursivas.
        /// </summary>
        /// <returns>Uma instância do validador.</returns>
        protected override ValidadorPadrao<QuestaoDiscursiva> Validador()
        {
            return _validador ?? (_validador = new ValidacoesQuestaoDiscursiva());
        }
    }
}
