using System.Collections.Generic;
using System.Threading.Tasks;
using ClientModel = DIY.NetCore.Data.CRUD.Client.Models.Client;

namespace DIY.NetCore.Data.CRUD.Client.Repository
{
    public interface IClientRepository
    {
        Task<HealthCheckResponse> HealthCheck();
        Task<RepositoryResponse<IEnumerable<ClientModel>>> GetAllAsync();
        Task<RepositoryResponse<ClientModel>> GetByIdAsync(int id);
        Task<RepositoryResponse<bool>> ActivateAsync(int id);
        Task<RepositoryResponse<bool>> DeactivateAsync(int id);
        Task<RepositoryResponse<int>> CreateAsync(ClientModel client);
        Task<RepositoryResponse<bool>> UpdateAsync(ClientModel client);
        Task<RepositoryResponse<IEnumerable<ClientModel>>> GetInactiveClientsAsync();
    }
}