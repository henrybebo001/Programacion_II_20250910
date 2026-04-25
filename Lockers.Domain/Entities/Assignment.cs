using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lockers.Domain
{
    public class Assignment : BaseEntity
    {
        public int LockerId { get; set; }
        public Locker Locker { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }

        public Assignment() { }

        public Assignment(int lockerId, int studentId, DateTime startDate, DateTime endDate)
        {
            LockerId = lockerId;
            StudentId = studentId;
            StartDate = startDate;
            EndDate = endDate;
            IsActive = true;
        }

        // Sobrecarga 1
        public void Renew()
        {
            EndDate = EndDate.AddMonths(1);
        }

        // Sobrecarga 2
        public void Renew(int extraDays)
        {
            EndDate = EndDate.AddDays(extraDays);
        }

        // Sobrecarga 3
        public void Renew(DateTime newEndDate)
        {
            EndDate = newEndDate;
        }

        public override string GetDescription() =>
            $"Assignment - Locker {LockerId} - Student {StudentId} - {StartDate:d} to {EndDate:d}";

        public override bool Validate() =>
            LockerId > 0 && StudentId > 0 && EndDate > StartDate;
    }
}
