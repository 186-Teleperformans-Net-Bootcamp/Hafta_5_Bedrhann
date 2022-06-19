using Microsoft.AspNetCore.Identity;


namespace Hafta._5.Domain.Entities.Identity
{
    public class AppUser : IdentityUser<int>
    {
        public string Nickname { get; set; }
        public string City { get; set; }
        public int Age { get; set; }
    }
}
