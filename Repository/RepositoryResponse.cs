using System;

namespace DIY.NetCore.Data.CRUD.Client.Repository
{
    public class RepositoryResponse<T>
    {
        public T Result { get; set; }
        public Exception Exception { get; set; }
        public bool Successful { get; set; }
    }
}
