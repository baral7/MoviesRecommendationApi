namespace MovieRecommendation.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Rating { get; set; }
        public DateTime releaseDate { get; set; }
        public string DirectedBy { get; set; }
        public string LeadActor { get; set; }
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }


    }

}
