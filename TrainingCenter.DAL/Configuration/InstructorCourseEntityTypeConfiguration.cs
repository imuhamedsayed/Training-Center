using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.DAL.Entities;

namespace TrainingCenter.DAL.Configuration
{
   public class InstructorCourseEntityTypeConfiguration : IEntityTypeConfiguration<InstructorCourse>
    {

        public void Configure(EntityTypeBuilder<InstructorCourse> builder)
        {
            builder.HasKey(sc => new { sc.InstructorId, sc.CourseId});
        }
    }
}
