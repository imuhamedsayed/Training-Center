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
    public class StudentRepository : IStudentRepository
    {
        TrainingCenterDbContext db;
        public StudentRepository(TrainingCenterDbContext db)
        {
            this.db = db;
        }
        public void Create(Student obj)
        {
            db.Student.Add(obj);
            db.SaveChanges();
        }

        public void Delete(Student obj)
        {
            db.Student.Remove(obj);
            db.SaveChanges();
        }

        public IEnumerable<Student> Get()
        {
            var data = db.Student.Select(s => s);
            return data;
        }

        public Student GetById(int id)
        {
            var data = db.Student.Where(s => s.Id == id).FirstOrDefault();

            return data;
        }

        public void Update(Student obj)
        {
            db.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
