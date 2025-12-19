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
    public class ApplicationConfig : IEntityTypeConfiguration<Internship.Domain.Models.Application>
    {
        public void Configure(EntityTypeBuilder<Internship.Domain.Models.Application> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.ApplicationDate)
                .IsRequired();
            builder.Property(a => a.Status)
                .IsRequired()
                .HasMaxLength(20)
                .HasDefaultValue("Pending");
            builder.HasOne(a => a.Student)
                .WithMany(s => s.Applications)
                .HasForeignKey(a => a.StudentId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(a => a.InternshipOffer)
                .WithMany(io => io.Applications)
                .HasForeignKey(a => a.InternshipOfferId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
