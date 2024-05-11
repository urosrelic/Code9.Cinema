namespace Code9.API.Models
{
    public class AddCinemaRequest
    {
        public string? Name { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public int NumberOfAuditoriums { get; set; }
    }
}
