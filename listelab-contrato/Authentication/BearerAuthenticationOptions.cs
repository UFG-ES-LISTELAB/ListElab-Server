using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace listelab_contrato.Authentication
{
    public class BearerAuthenticationOptions : AuthenticationSchemeOptions
    {
        public string Realm { get; set; }

        public BearerAuthenticationOptions()
        {
        }
    }
}
