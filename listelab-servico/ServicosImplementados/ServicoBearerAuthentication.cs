using ListElab.Data.Repositorios;
using ListElab.Dominio.Conceitos.UsuarioObj;
using ListElab.Dominio.InterfaceDeServico;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ListElab.Servico.ServicosImplementados
{
    public class ServicoBearerAuthentication : IServicoBearerAuthentication
    {
        private IRepositorio<Usuario> _repositorio;

        private const string salt = "listelab";

        private string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private int GetNextWeekday(DateTime start, DayOfWeek day)
        {
            // The (... + 7) % 7 ensures we end up with a value in the range [0, 6]
            int daysToAdd = ((int)day - (int)start.DayOfWeek + 7) % 7;
            return start.AddDays(daysToAdd).Day;
        }

        private string GetCurrentToken(Usuario usuario)
        {
            string currentToken = ComputeSha256Hash(usuario.Email + GetNextWeekday(DateTime.Now, DayOfWeek.Friday) + salt);
            return currentToken;
        }

        public string EfetueLogin(string email, string password)
        {
            string saltedPassword = password + salt;
            string hash = ComputeSha256Hash(saltedPassword);

            var usuario = Repositorio().ConsulteUm(x => x.Email.Equals(email) && x.Password.Equals(hash));

            if (usuario != null && usuario.Password.Equals(hash))
            {
                if (usuario.Token == null || !usuario.Token.Equals(GetCurrentToken(usuario)))
                {
                    usuario.Token = GetCurrentToken(usuario);
                    Repositorio().Atualize(x => x.Id.Equals(usuario.Id), usuario);
                }

                return usuario.Token;
            }
            else
            {
                throw new Exception("Usuário ou senha inválido");
            }
        }

        public async Task<bool> IsValidUserAsync(string token)
        {
            Usuario usuario = Repositorio().ConsulteUm(x => x.Token.Equals(token));
            bool isValidUser = usuario != null && usuario.Token.Equals(token) && usuario.Token.Equals(GetCurrentToken(usuario));
            return isValidUser;
        }

        public string GetRole(string token)
        {
            string role = Repositorio().ConsulteUm(x => x.Token.Equals(token)).Role.ToString();
            role = role ?? "-1";
            return role;
        }

        private IRepositorio<Usuario> Repositorio()
        {
            return _repositorio ?? (_repositorio = new Repositorio<Usuario>());
        }


    }
}
