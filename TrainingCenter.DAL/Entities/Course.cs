using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCenter.DAL.Entities
{
   public  class Course
    {
        
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }

        public ICollection<InstructorCourse> InstructorCourse { get; set; }
        public ICollection<StudentCourse> StudentCourse { get; set; }
    }
}
