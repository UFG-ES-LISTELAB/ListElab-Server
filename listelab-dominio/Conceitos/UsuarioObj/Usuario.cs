using listelab_dominio.Abstrato;
using listelab_dominio.CustomAttributes;
using listelab_dominio.Enumeradores;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace listelab_dominio.Conceitos.UsuarioObj
{

    [Colecao(Nome = "usuario")]
    public class Usuario
    {
        public ObjectId Id { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Token { get; set; }

        public EnumPapelDeAcesso Role { get; set; }
    }
}
