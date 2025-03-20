namespace MeSoft.Blazor.Models
{
    public class RegisterViewModel
    {
        public  string FirstName { get; set; }
        public  string LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? ProfilePhotoUrl { get; set; }
        public  string Password { get; set; }

    }
}
