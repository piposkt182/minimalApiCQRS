
namespace Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public int Dni { get; set; }
        public string? Name { get; set; }
        public string? lastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Email { get; set; }
        public int GenderId { get; set; }
        public int CountryId { get; set; }
    }
}
