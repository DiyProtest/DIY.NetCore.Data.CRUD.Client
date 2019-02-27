using System;

namespace DIY.NetCore.Data.CRUD.Client.Controllers
{
    internal class InternalServerErrorResponse
    {
        public Exception Exception { get; internal set; }
    }
}