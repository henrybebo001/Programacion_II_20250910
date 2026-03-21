using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SystemAdminAPI.DTOs
{
    public class CreateAdminDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;
    }
}
