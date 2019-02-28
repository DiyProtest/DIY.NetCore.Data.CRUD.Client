namespace DIY.NetCore.Data.CRUD.Client.Controllers
{
    public class Client
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FriendlyName { get; set; }
        public string CellPhone { get; set; }
        public string OfficePhone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int? StateId { get; set; }
        public int? ZipCode { get; set; }
        public int? ExtendedZip { get; set; }
        public string Website { get; set; }
        public bool Active { get; set; }
    }
}
