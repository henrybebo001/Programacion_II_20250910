using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lockers.Domain
{
    public enum LockerStatus { Available, Assigned, UnderMaintenance }

    public class Locker : BaseEntity
    {
        public string Number { get; set; }
        public string Location { get; set; }
        public string Size { get; set; }
        public LockerStatus Status { get; set; }

        public Locker() { }

        public Locker(string number, string location, string size)
        {
            Number = number;
            Location = location;
            Size = size;
            Status = LockerStatus.Available;
        }

        public override string GetDescription() =>
            $"Locker {Number} - {Location} - {Size} - {Status}";

        public override bool Validate() =>
            !string.IsNullOrEmpty(Number) && !string.IsNullOrEmpty(Location);
    }
}
