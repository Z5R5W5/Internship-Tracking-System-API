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
    public class ApplicationConfig : IEntityTypeConfiguration<Domain.Models.Application>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.Application> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.ApplicationDate)
                .IsRequired();
            builder.Property(a => a.Status)
                .IsRequired()
                .HasMaxLength(20)
                .HasDefaultValue("Pending");
            builder.HasOne(a => a.Student)
                 .WithMany(u => u.Applications)
                 .HasForeignKey(a => a.StudentId)
                 .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(a => a.InternshipOffer)
                .WithMany(io => io.Applications)
                .HasForeignKey(a => a.InternshipOfferId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
