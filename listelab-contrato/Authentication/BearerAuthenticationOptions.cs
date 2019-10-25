using Microsoft.AspNetCore.Authentication;

namespace ListElab.Contrato.Authentication
{
    public class BearerAuthenticationOptions : AuthenticationSchemeOptions
    {
        public string Realm { get; set; }

        public BearerAuthenticationOptions()
        {
        }
    }
}
