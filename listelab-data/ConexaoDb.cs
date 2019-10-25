using MongoDB.Driver;
using System.Configuration;

namespace ListElab.Data
{
    public class ConexaoDb
    {
        /// <summary>
        /// Representa uma sessão no banco.
        /// </summary>
        public IClientSessionHandle Sessao { get; set; }

        public ConexaoDb()
        {
            string connectionString = ConfigurationManager.AppSettings["ConnectionString"];

            var client = new MongoClient(connectionString);
            Sessao = client.StartSession();
        }

        /// <summary>
        /// Cria uma conexão com o banco.
        /// </summary>
        /// <returns></returns>
        public IMongoDatabase ConexaoMongoDB()
        {
            string database = ConfigurationManager.AppSettings["DataBase"];
            return Sessao.Client.GetDatabase(database);
        }
    }
}
