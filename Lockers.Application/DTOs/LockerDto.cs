using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lockers.Application.DTOs
{
    public class LockerDto
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Location { get; set; }
        public string Size { get; set; }
        public string Status { get; set; }
    }
}
