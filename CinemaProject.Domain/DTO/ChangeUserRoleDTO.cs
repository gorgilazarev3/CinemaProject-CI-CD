using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace CinemaProject.Domain.DTO
{
    public class ChangeUserRoleDTO
    {
        public string UserId { get; set; }
        public string CurrentRole { get; set; }
        public string SelectedRole { get; set; }
        public IEnumerable<IdentityRole> AllRoles { get; set; }
    }
}
