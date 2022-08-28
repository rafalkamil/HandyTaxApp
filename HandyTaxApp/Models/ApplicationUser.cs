using Microsoft.AspNetCore.Identity;

namespace HandyTaxApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string CompanyName { get; set; }

    }   
}
