using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lockers.Application.DTOs
{
    public class IncidentDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public int AssignmentId { get; set; }
    }
}
