using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lockers.Domain
{
    public class Student : BaseEntity
    {
        public string Name { get; set; }
        public string StudentId { get; set; }
        public string Grade { get; set; }
        public string Email { get; set; }

        public Student() { }

        public Student(string name, string studentId, string grade, string email)
        {
            Name = name;
            StudentId = studentId;
            Grade = grade;
            Email = email;
        }

        public override string GetDescription() =>
            $"Student {Name} - {Grade} - {Email}";

        public override bool Validate() =>
            !string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(StudentId);
    }
}
