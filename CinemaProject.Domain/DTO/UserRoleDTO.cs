using CinemaProject.Domain.Identity;

namespace CinemaProject.Domain.ViewModels
{
    public class UserRoleDTO
    {
        public CinemaUser User { get; set; }
        public string SelectedRole { get; set; }
        public string CurrentRole { get; set; }
    }
}
