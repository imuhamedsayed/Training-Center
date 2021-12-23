using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCenter.DAL.Entities
{
    public class Instructor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public int  Salary { get; set; }

        public ICollection<InstructorCourse> InstructorCourse { get; set; }

    }
}
