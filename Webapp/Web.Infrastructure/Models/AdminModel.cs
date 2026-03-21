using System;
using System.Collections.Generic;

namespace Web.Domain.Models
{
    public class AdminModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;
    }

}

