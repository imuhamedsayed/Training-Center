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
    public class InstructorRepository : IInstructorRepository
    {
        TrainingCenterDbContext db;
        public InstructorRepository(TrainingCenterDbContext db)
        {
            this.db = db;
        }
        public void Create(Instructor obj)
        {
            db.Instructor.Add(obj);
            db.SaveChanges();
        }

        public void Delete(Instructor obj)
        {
            db.Instructor.Remove(obj);
            db.SaveChanges();
        }

        public IEnumerable<Instructor> Get()
        {
            var data = db.Instructor.Select(s => s);
            return data;
        }

        public Instructor GetById(int id)
        {
            var data = db.Instructor.Where(s => s.Id == id).FirstOrDefault();

            return data;
        }

        public void Update(Instructor obj)
        {
            db.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
