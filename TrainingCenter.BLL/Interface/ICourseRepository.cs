using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.DAL.Entities;

namespace TrainingCenter.BLL.Interface
{
    public interface ICourseRepository
    {
        IEnumerable<Course> Get();

        void Create(Course obj);
        void Update(Course obj);
        void Delete(Course obj);
        Course GetById(int id);
    }
}
