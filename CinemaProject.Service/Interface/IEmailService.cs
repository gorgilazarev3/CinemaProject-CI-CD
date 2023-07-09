using CinemaProject.Domain.DomainModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaProject.Service.Interface
{
    public interface IEmailService
    {
        Task SendEmailAsync(List<EmailMessage> allMails);
    }
}
