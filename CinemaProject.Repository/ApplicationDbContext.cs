using CinemaProject.Domain.DomainModels;
using CinemaProject.Domain.Identity;
using CinemaProject.Domain.Relationships;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaProject.Repository
{
    public class ApplicationDbContext : IdentityDbContext<CinemaUser>
    {

        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<CinemaUser> CinemaUsers { get; set; }
        public virtual DbSet<TicketInShoppingCart> TicketsInShoppingCarts { get; set; }
        public virtual DbSet<TicketInOrder> TicketsInOrders { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        
        

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
