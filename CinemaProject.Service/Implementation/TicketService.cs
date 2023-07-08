using CinemaProject.Domain.DomainModels;
using CinemaProject.Repository.Interface;
using CinemaProject.Service.Interface;
using System;
using System.Collections.Generic;

namespace CinemaProject.Service.Implementation
{
    public class TicketService : ITicketService
    {
        private readonly IRepository<Ticket> _ticketRepository;

        public TicketService(IRepository<Ticket> ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public Ticket AddNewTicket(Ticket entity)
        {
            return _ticketRepository.Insert(entity);
        }

        public Ticket DeleteTicket(Guid? id)
        {
            var ticket = GetTicketById(id);
            return _ticketRepository.Delete(ticket);
        }

        public IEnumerable<Ticket> GetAllTickets()
        {
            return _ticketRepository.GetAll();
        }

        public Ticket GetTicketById(Guid? id)
        {
            return _ticketRepository.Get(id);
        }

        public bool TicketExists(Guid ticketId)
        {
            return _ticketRepository.Get(ticketId) != null;
        }

        public Ticket UpdeteTicket(Ticket entity)
        {
           return _ticketRepository.Update(entity);
        }
    }
}
