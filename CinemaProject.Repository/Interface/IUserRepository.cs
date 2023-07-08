using CinemaProject.Domain.Identity;
using System.Collections.Generic;

namespace CinemaProject.Repository.Interface
{
    public interface IUserRepository
    {
        public IEnumerable<CinemaUser> GetAll();
        public CinemaUser Get(string id);
        public CinemaUser Insert(CinemaUser entity);
        public CinemaUser Delete(CinemaUser entity);
        public CinemaUser Update(CinemaUser entity);
    }
}
