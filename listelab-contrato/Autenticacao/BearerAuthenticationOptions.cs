using Microsoft.AspNetCore.Authentication;

namespace ListElab.Contrato.Autenticacao
{
    public class BearerAuthenticationOptions : AuthenticationSchemeOptions
    {
        public string Realm { get; set; }

        public BearerAuthenticationOptions()
        {
        }
    }
}
