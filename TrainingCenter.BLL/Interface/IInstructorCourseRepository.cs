using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.DAL.Entities;

namespace TrainingCenter.BLL.Interface
{
   public  interface IInstructorCourseRepository
    {
        IEnumerable<InstructorCourse> Get();

        void Create(InstructorCourse obj);
        void Update(InstructorCourse obj);
        void Delete(InstructorCourse obj);
        //InstructorCourse GetById(int id);
    }
}
