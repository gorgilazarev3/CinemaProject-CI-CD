using System.Collections.Generic;
using System;
using CinemaProject.Domain.DomainModels;

namespace CinemaProject.Service.Interface
{
    public interface ITicketService
    {
        IEnumerable<Ticket> GetAllTickets();
        Ticket GetTicketById(Guid? id);
        Ticket AddNewTicket(Ticket entity);
        Ticket UpdeteTicket(Ticket entity);
        Ticket DeleteTicket(Guid? id);
        bool TicketExists(Guid ticketId);
    }
}
