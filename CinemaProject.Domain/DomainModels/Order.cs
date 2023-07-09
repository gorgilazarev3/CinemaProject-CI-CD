using CinemaProject.Domain.Identity;
using CinemaProject.Domain.Relationships;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaProject.Domain.DomainModels
{
    public class Order : BaseEntity
    {
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public CinemaUser TicketHolder { get; set; }
        public List<TicketInOrder> TicketsInOrder { get; set; }
    }
}
