namespace MovieRental_WebSystem.Models
{
    public class Movie
    {
        public int Code { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Year { get; set; }
        public double Price { get; set; }
        public bool IsRented { get; set; }

    }
}
