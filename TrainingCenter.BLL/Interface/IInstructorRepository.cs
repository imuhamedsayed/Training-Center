using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.DAL.Entities;

namespace TrainingCenter.BLL.Interface
{
    public interface IInstructorRepository
    {
        IEnumerable<Instructor> Get();

        void Create(Instructor obj);
        void Update(Instructor obj);
        void Delete(Instructor obj);
        Instructor GetById(int id);
    }
}
