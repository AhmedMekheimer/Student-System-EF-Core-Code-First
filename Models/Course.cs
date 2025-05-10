using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.Models
{
    class Course
    {
        public string CourseId { get; set; }
        public string Name { get; set; } //Unicode
        public string? Description { get; set; }    //Unicode
        public DateOnly StartDate { get; set; } 
        public DateOnly EndDate { get; set; }
        public double Price { get; set; }
        public ICollection<Resource> Resources { get; } = new List<Resource>();
        public ICollection<Homework> Homeworks { get; } = new List<Homework>();
        public List<Student> Students { get; } = [];
    }
}
