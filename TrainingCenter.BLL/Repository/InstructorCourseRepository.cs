using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.BLL.Interface;
using TrainingCenter.DAL.Database;
using TrainingCenter.DAL.Entities;

namespace TrainingCenter.BLL.Repository
{
    public class InstructorCourseRepository : IInstructorCourseRepository
    {
        TrainingCenterDbContext db;
        public InstructorCourseRepository(TrainingCenterDbContext db)
        {
            this.db = db;
        }
        public void Create(InstructorCourse obj)
        {
            db.InstructorCourse.Add(obj);
            db.SaveChanges();
        }

        public void Delete(InstructorCourse obj)
        {
            db.InstructorCourse.Remove(obj);
            db.SaveChanges();
        }

        public IEnumerable<InstructorCourse> Get()
        {
            var data = db.InstructorCourse.Include(a => a.Course).Include(a => a.Instructor).Select(s => s);
            return data;
        }

        //public InstructorCourse GetById(int id)
        //{
        //    var data = db.InstructorCourse.Include(a => a.Course).Include(a => a.Instructor).Where(s => s. == id).FirstOrDefault(); */

        //    return data;
        //}

        public void Update(InstructorCourse obj)
        {
            db.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
