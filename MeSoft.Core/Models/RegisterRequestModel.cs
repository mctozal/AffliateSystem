namespace MeSoft.Core.Models
{
    public class RegisterRequestModel
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? ProfilePhotoUrl { get; set; }
        public required string Password { get; set; }

    }
}
