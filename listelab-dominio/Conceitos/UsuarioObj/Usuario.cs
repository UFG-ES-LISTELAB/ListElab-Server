using listelab_dominio.CustomAttributes;
using listelab_dominio.Enumeradores;
using MongoDB.Bson;

namespace listelab_dominio.Conceitos.UsuarioObj
{

    [Colecao(Nome = "usuario")]
    public class Usuario
    {
        /// <summary>
        /// Id do usuário.
        /// </summary>
        public ObjectId Id { get; set; }
        
        /// <summary>
        /// Email do usuário.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Senha do usuário.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Nome do usuário.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Token do usuário.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Permissão do usuário.
        /// </summary>
        public EnumPapelDeAcesso Role { get; set; }
    }
}
