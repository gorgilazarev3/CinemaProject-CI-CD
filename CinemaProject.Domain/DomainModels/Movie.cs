namespace CinemaProject.Domain.DomainModels
{
    public class Movie : BaseEntity
    {
        public string Name { get; set; }
        public MovieCategory Category { get; set; }
        public string ImageURL { get; set; }
    }
}
