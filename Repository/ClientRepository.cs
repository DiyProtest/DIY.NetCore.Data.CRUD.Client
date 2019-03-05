using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using ClientModel = DIY.NetCore.Data.CRUD.Client.Models.Client;
using DIY.NetCore.Data.CRUD.Client.Factory;

namespace DIY.NetCore.Data.CRUD.Client.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public ClientRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<HealthCheckResponse> HealthCheck()
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

        public async Task<RepositoryResponse<IEnumerable<ClientModel>>> GetAllAsync()
        {
            using (var connection = _connectionFactory.Connect())
            {
                try
                {
                    var result = await connection.QueryAsync<ClientModel>("SELECT * FROM Client WHERE Active = 1");
                    return new RepositoryResponse<IEnumerable<ClientModel>>
                    {
                        Successful = true,
                        Result = result
                    };
                }
                catch (Exception ex)
                {
                    return new RepositoryResponse<IEnumerable<ClientModel>>
                    {
                        Successful = true,
                        Exception = ex
                    };
                }
            }
        }

        public async Task<RepositoryResponse<ClientModel>> GetByIdAsync(int id)
        {
            using (var connection = _connectionFactory.Connect())
            {
                try
                {
                    var result = await connection.GetAsync<ClientModel>(id);
                    return new RepositoryResponse<ClientModel>
                    {
                        Result = result,
                        Successful = true
                    };
                }
                catch (Exception ex)
                {
                    return new RepositoryResponse<ClientModel>
                    {
                        Successful = false,
                        Exception = ex
                    };
                }
            }
        }

        public async Task<RepositoryResponse<bool>> ActivateAsync(int id)
        {
            using (var connection = _connectionFactory.Connect())
            {
                try
                {
                    var result = await connection.ExecuteAsync("UPDATE Client Set Active = 1 where Id = @id", id);
                    return new RepositoryResponse<bool>
                    {
                        Result = result == 1,
                        Successful = true
                    };
                }
                catch (Exception ex)
                {
                    return new RepositoryResponse<bool>
                    {
                        Successful = false,
                        Exception = ex
                    };
                }
            }
        }

        public async Task<RepositoryResponse<bool>> DeactivateAsync(int id)
        {
            using (var connection = _connectionFactory.Connect())
            {
                try
                {
                    var result = await connection.ExecuteAsync("UPDATE Client Set Active = 0 where Id = @id", id);
                    return new RepositoryResponse<bool>
                    {
                        Result = result == 1,
                        Successful = true
                    };
                }
                catch (Exception ex)
                {
                    return new RepositoryResponse<bool>
                    {
                        Successful = false,
                        Exception = ex
                    };
                }
            }
        }

        public async Task<RepositoryResponse<int>> CreateAsync(ClientModel client)
        {
            using (var connection = _connectionFactory.Connect())
            {
                try
                {
                    var result = await connection.InsertAsync(client);
                    return new RepositoryResponse<int>
                    {
                        Result = result,
                        Successful = true
                    };
                }
                catch (Exception ex)
                {
                    return new RepositoryResponse<int>
                    {
                        Successful = false,
                        Exception = ex
                    };
                }
            }
        }

        public async Task<RepositoryResponse<bool>> UpdateAsync(ClientModel client)
        {
            using (var connection = _connectionFactory.Connect())
            {
                try
                {
                    var result = await connection.UpdateAsync(client);
                    return new RepositoryResponse<bool>
                    {
                        Result = result,
                        Successful = true
                    };
                }
                catch (Exception ex)
                {
                    return new RepositoryResponse<bool>
                    {
                        Successful = false,
                        Exception = ex
                    };
                }
            }
        }

        public async Task<RepositoryResponse<IEnumerable<ClientModel>>> GetInactiveClientsAsync()
        {
            using (var connection = _connectionFactory.Connect())
            {
                try
                {
                    var result = await connection.QueryAsync<ClientModel>("SELECT * FROM Client WHERE Active = 0");
                    return new RepositoryResponse<IEnumerable<ClientModel>>
                    {
                        Result = result,
                        Successful = true
                    };
                }
                catch (Exception ex)
                {
                    return new RepositoryResponse<IEnumerable<ClientModel>>
                    {
                        Successful = false,
                        Exception = ex
                    };
                }
            }
        }
    }
}
