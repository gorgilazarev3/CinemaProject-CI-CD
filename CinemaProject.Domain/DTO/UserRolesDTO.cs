using CinemaProject.Domain.Identity;
using CinemaProject.Domain.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Collections;
using System.Collections.Generic;

namespace CinemaProject.Domain.DTO
{
    public class UserRolesDTO
    {
        public IEnumerable<UserRoleDTO> AllUsers { get; set; }
        public IEnumerable<IdentityRole> AllRoles { get; set; }
        public string SelectedRole { get; set; }
    }
}
