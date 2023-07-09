using System.Threading.Tasks;

namespace CinemaProject.Service.Interface
{
    public interface IBackgroundEmailSender
    {
        Task DoWork();
    }
}
