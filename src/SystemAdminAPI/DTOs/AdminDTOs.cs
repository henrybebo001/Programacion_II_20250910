using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SystemAdminAPI.DTOs
{
    public class CreateAdminDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
