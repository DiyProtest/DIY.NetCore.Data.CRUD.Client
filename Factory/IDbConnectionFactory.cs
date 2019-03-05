using System.Data;

namespace DIY.NetCore.Data.CRUD.Client.Factory
{
    public interface IDbConnectionFactory
    {
        IDbConnection Connect();
    }
}