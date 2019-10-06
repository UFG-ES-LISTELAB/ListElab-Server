using System;
using listelab_contrato.RequestObject;
using listelab_dominio;
using listelab_dominio.Conceitos;
using listelab_dominio.Conceitos.Filtro;
using listelab_dominio.Conceitos.Questao;
using listelab_dominio.Conceitos.Resposta;
using listelab_dominio.InterfaceDeServico;
using Microsoft.AspNetCore.Mvc;

namespace listelab_contrato.Controllers
{
    /// <summary>
    /// Api para o conceito de questão discursiva.
    /// </summary>
    public class QuestaoDiscursivaController : ControladorPadrao<Questao<Discursiva>, IServicoQuestaoDiscursiva, FiltroQuestao>
    {
    }
}
