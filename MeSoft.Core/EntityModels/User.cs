using MeSoft.Shared.EntityBase;
using MeSoft.Shared.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MeSoft.Core.EntityModels
{
    public class User : EntityBase
    {

        [Required]
        public required string FirstName { get; set; }
        [Required]
        public required string LastName { get; set; }
        [Required]
        public required string Email { get; set; }
        public string? Phone { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? ProfilePhotoUrl { get; set; }

        [Required]
        public UserRole Role { get; set; }
        [Required]
        public required string PasswordHash { get; set; }
    }


}
