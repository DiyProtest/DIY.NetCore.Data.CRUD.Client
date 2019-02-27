namespace DIY.NetCore.Data.CRUD.Client.Controllers
{
    public class HealthCheckResponse
    {
        public bool IsConnected { get; set; }
        public long ConnectionLatency { get; set; }
    }
}
