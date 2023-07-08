using CinemaProject.Domain.Identity;
using CinemaProject.Repository.Interface;
using CinemaProject.Service.Interface;
using System.Collections.Generic;

namespace CinemaProject.Service.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public CinemaUser Add(CinemaUser entity)
        {
            return _userRepository.Insert(entity);
        }

        public CinemaUser Delete(CinemaUser entity)
        {
            return _userRepository.Delete(entity);
        }

        public IEnumerable<CinemaUser> FindAllUsers()
        {
            return _userRepository.GetAll();
        }

        public CinemaUser GetUserById(string id)
        {
            return _userRepository.Get(id);
        }

        public CinemaUser Update(CinemaUser entity)
        {
            return _userRepository.Update(entity);
        }
    }
}
