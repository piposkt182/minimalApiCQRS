namespace MinimalApi.Dto
{
    public class CreateUserDto
    {
        public int Dni { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Email { get; set; }
        public int GenderId { get; set; }
        public string CountryId { get; set; }

        public AddressDto Address { get; set; } = null!;
    }
}
