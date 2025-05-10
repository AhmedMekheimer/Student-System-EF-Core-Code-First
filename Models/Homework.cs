using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.Models
{
    public enum ContentType
    {
        Application,
        pdf,
        zip
    }
    class Homework
    {
        public string HomeworkId { get; set; }
        public string Content { get; set; }
        public ContentType Type { get; set; }
        public DateTime SubmissionTime { get; set; }
        public string CourseId { get; set; }    //FK property
        public Course Course { get; set; } = null!; //A Homework must refer to a course, easier in joins
        public string StudentId { get; set; }    //FK property
        public Student Student { get; set; } = null!; //A Homework must refer to a student, easier in joins
    }
}
