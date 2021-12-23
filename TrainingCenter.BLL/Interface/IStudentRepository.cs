using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.DAL.Entities;

namespace TrainingCenter.BLL.Interface
{
  public  interface IStudentRepository
    {
        IEnumerable<Student> Get();

        void Create(Student obj);
        void Update(Student obj);
        void Delete(Student obj);
        Student GetById(int id);
    }
}
