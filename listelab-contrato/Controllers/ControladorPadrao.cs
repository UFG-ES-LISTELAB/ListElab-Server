using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using listelab_dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace listelab_contrato.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControladorPadrao<T> : ControllerBase 
    {
        protected T Servico = FabricaGenerica.Crie<T>();
    }
}