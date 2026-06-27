using Internship.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Infrastructure.Identity.Configrations
{
    public class ReportConfig : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.HasKey(r=>r.Id);
            builder.Property(r => r.Title).IsRequired();
            builder.Property(r => r.Content).IsRequired();
            builder.Property(r => r.SubmissionDate).IsRequired();
            builder.Property(r=>r.ReportType)
                .IsRequired()
                .HasMaxLength(20)
                .HasDefaultValue("Weekly");
            
            builder.HasOne(r => r.Student)
                .WithMany(u => u.Reports)
                .HasForeignKey(r => r.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
