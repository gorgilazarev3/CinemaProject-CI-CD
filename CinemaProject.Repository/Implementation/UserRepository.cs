using CinemaProject.Domain.Identity;
using CinemaProject.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CinemaProject.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {

        private readonly ApplicationDbContext _context;
        private DbSet<CinemaUser> entities;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
            entities = context.Set<CinemaUser>();
        }

        public CinemaUser Delete(CinemaUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _context.Remove(entity);
            _context.SaveChanges();
            return entity;
        }

        public CinemaUser Get(string id)
        {
            return entities.Include(u => u.ShoppingCart).ThenInclude(sc => sc.TicketsInShoppingCart).ThenInclude(tsc => tsc.Ticket).ThenInclude(t => t.Movie).SingleOrDefault(u => u.Id == id);
            //return entities.SingleOrDefault(u => u.Id == id);
        }

        public IEnumerable<CinemaUser> GetAll()
        {
            return entities.AsEnumerable();
        }

        public CinemaUser Insert(CinemaUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _context.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public CinemaUser Update(CinemaUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _context.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
