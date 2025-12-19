using Internship.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Infrastructure.Data.Configrations
{
    public class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(s => s.LastName).IsRequired().HasMaxLength(50);
            builder.Property(s => s.UniversityId).IsRequired().HasMaxLength(20);
            builder.Property(s => s.Major).IsRequired().HasMaxLength(100);
            builder.Property(s => s.Email).IsRequired().HasMaxLength(100);
            builder.HasMany(s => s.Applications)
                   .WithOne(a => a.Student)
                   .HasForeignKey(a => a.StudentId);
            builder.HasMany(s => s.Reports)
                   .WithOne(r => r.Student)
                   .HasForeignKey(r => r.StudentId);
            builder.HasOne(s => s.AcceptedInternship)
                   .WithMany(i => i.AcceptedStudents)
                   .HasForeignKey(s => s.AcceptedInternshipId)
                   .OnDelete(DeleteBehavior.SetNull);

        }
    }
}
