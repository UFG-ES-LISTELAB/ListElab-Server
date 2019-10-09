using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace listelab_contrato.Authentication
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
