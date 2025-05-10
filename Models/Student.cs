using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.Models
{
    class Student
    {
        public string StudentId { get; set; }
        public string Name { get; set; } //Unicode
        public string? PhoneNumber { get; set; } //Not unicode
        public DateTime RegisteredOn { get; set; }
        public DateOnly? Birthday { get; set; } //'?' To make it not required 
        public ICollection<Homework> Homeworks { get; } = new List<Homework>();
        public List<Course> Courses { get; } = [];
    }
}
