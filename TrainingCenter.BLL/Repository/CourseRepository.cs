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
  public  class CourseRepository : ICourseRepository
    {
        TrainingCenterDbContext db;
        public CourseRepository(TrainingCenterDbContext db)
        {
            this.db = db;
        }
        public void Create(Course obj)
        {
            db.Course.Add(obj);
            db.SaveChanges();
        }

        public void Delete(Course obj)
        {
            db.Course.Remove(obj);
            db.SaveChanges();
        }

        public IEnumerable<Course> Get()
        {
            var data = db.Course.Select(s => s);
            return data;
        }

        public Course GetById(int id)
        {
            var data = db.Course.Where(s => s.Id == id).FirstOrDefault();

            return data;
        }

        public void Update(Course obj)
        {
            db.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
