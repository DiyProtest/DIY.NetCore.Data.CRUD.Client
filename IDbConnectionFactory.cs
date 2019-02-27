using System.Data;

namespace DIY.NetCore.Data.CRUD.Client.Controllers
{
    public interface IDbConnectionFactory
    {
        IDbConnection Connect();
    }
}