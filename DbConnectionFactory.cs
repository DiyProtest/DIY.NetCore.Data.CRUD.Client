using System.Data;
using System.Data.SqlClient;

namespace DIY.NetCore.Data.CRUD.Client.Controllers
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        private readonly string connectionString;

        public DbConnectionFactory(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IDbConnection Connect()
        {
            return new SqlConnection(connectionString);
        }
    }
}
