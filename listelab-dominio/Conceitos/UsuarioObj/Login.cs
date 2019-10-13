using System;
using System.Collections.Generic;
using System.Text;

namespace listelab_dominio.Conceitos.UsuarioObj
{
    public class Login
    {
        /// <summary>
        /// Email do usuário.
        /// </summary>
        public string Email { get; set; }
        
        /// <summary>
        /// Senha do usuário.
        /// </summary>
        public string Password { get; set; }
    }
}
