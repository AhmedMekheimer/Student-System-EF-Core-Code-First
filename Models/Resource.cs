using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.Models
{
    public enum ResourceType
    {
        Video,
        Presentation,
        Document,
        Other
    }
    class Resource
    {

        public string ResourceId { get; set; }
        public string Name { get; set; }  //Unicode
        public string Url { get; set; } //not uniocode
        public ResourceType Type { get; set; }
        public string CourseId { get; set; }    //FK property
        public Course Course { get; set; } = null!; //A resource must refer to a course, easier in joins

    }
}
