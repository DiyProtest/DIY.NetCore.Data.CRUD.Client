using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Dapper;
using DIY.NetCore.Data.CRUD.Client.Controllers;

namespace DIY.NetCore.Data.CRUD.Client.Repository
{
    public class ClientRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public ClientRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        internal async Task<HealthCheckResponse> HealthCheck()
        {
            using (var connection = _connectionFactory.Connect())
            {
                var timer = new Stopwatch();
                timer.Start();

                try
                {
                    var count = await connection.ExecuteScalarAsync<int>($"SELECT COUNT(Id) FROM Client");

                    timer.Stop();
                    return new HealthCheckResponse
                    {
                        ConnectionLatency = timer.ElapsedMilliseconds,
                        IsConnected = true
                    };
                }
                catch (Exception ex)
                {
                    timer.Stop();
                    return new HealthCheckResponse
                    {
                        Error = true,
                        Exception = ex
                    };
                }
            }
        }

        internal Task ActivateAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
