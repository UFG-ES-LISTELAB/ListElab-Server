using System.Threading.Tasks;

namespace ListElab.Dominio.InterfaceDeServico
{
    public interface IServicoBearerAuthentication
    {
        Task<bool> IsValidUserAsync(string token);
    }
}
