using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace listelab_dominio.InterfaceDeServico
{
    public interface IServicoBearerAuthentication
    {
        Task<bool> IsValidUserAsync(string token);
    }
}
