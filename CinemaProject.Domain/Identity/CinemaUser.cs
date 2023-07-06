using Microsoft.AspNetCore.Identity;

namespace CinemaProject.Domain.Identity
{
    public class CinemaUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        //TO INSERT SHOPPING CART
    }
}
