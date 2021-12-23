using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.BLL.Models;
using TrainingCenter.DAL.Entities;

namespace TrainingCenter.BLL.Mapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Instructor, InstructorVM>();
            CreateMap<InstructorVM, Instructor>();

            CreateMap<Course, CourseVM>();
            CreateMap<CourseVM, Course>();

            CreateMap<Student, StudentVM>();
            CreateMap<StudentVM, Student>();

            CreateMap<StudentCourse, StudentCourseVM>();
            CreateMap<StudentCourseVM, StudentCourse>();

            CreateMap<InstructorCourse, InstructorCourseVM>();
            CreateMap<InstructorCourseVM, InstructorCourse>();
        }
    }
}
