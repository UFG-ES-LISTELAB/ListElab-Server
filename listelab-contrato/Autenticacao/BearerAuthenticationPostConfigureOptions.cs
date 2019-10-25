using Microsoft.Extensions.Options;
using System;

namespace ListElab.Contrato.Autenticacao
{
    public class BearerAuthenticationPostConfigureOptions : IPostConfigureOptions<BearerAuthenticationOptions>
    {
        public void PostConfigure(string name, BearerAuthenticationOptions options)
        {
            if (string.IsNullOrEmpty(options.Realm))
            {
                throw new InvalidOperationException("Realm must be provided in options");
            }
        }
    }
}
