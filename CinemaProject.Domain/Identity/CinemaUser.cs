using CinemaProject.Domain.DomainModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace CinemaProject.Domain.Identity
{
    public class CinemaUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public virtual ShoppingCart ShoppingCart { get; set; }
    }
}
