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
    class InstructorEntityTypeConfiguration : IEntityTypeConfiguration<Instructor>
    {
       

        public void Configure(EntityTypeBuilder<Instructor> builder)
        {

        }
    
}
}
