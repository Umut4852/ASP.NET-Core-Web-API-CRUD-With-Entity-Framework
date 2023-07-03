namespace ASP.NET_Core_Web_API_CRUD.Models
{
    public class UpdatePersonRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }
        public string Address { get; set; }
    }
}
