using CinemaProject.Domain.Identity;
using System.Collections.Generic;

namespace CinemaProject.Service.Interface
{
    public interface IUserService
    {
        public IEnumerable<CinemaUser> FindAllUsers();
        public CinemaUser GetUserById(string id);
        public CinemaUser Add(CinemaUser entity);
        public CinemaUser Delete(CinemaUser entity);
        public CinemaUser Update(CinemaUser entity);
    }
}
