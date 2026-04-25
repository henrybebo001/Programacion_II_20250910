using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lockers.Domain
{
    public enum IncidentType { Damage, LostKey, Complaint, Other }

    public class Incident : BaseEntity
    {
        public IncidentType Type { get; set; }
        public string Description { get; set; }
        public int AssignmentId { get; set; }
        public Assignment Assignment { get; set; }

        public Incident() { }

        public Incident(IncidentType type, string description, int assignmentId)
        {
            Type = type;
            Description = description;
            AssignmentId = assignmentId;
        }

        public override string GetDescription() =>
            $"Incident {Type} - {Description}";

        public override bool Validate() =>
            !string.IsNullOrEmpty(Description) && AssignmentId > 0;
    }
}
