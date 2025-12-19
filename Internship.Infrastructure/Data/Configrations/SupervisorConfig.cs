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
    public class SupervisorConfig : IEntityTypeConfiguration<Supervisor>
    {

        public void Configure(EntityTypeBuilder<Supervisor> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.FullName).IsRequired().HasMaxLength(100);
            builder.Property(s => s.Email).IsRequired().HasMaxLength(100);
            builder.Property(s => s.Role).IsRequired().HasMaxLength(20).HasDefaultValue("Academic");
            builder.HasOne(s => s.InternshipOffer)
                .WithMany(i => i.Supervisors)
                .HasForeignKey(s => s.InternshipOfferId);
            builder
                .HasMany(s => s.EvaluationsGiven)
                .WithOne(e => e.Supervisor)
                .HasForeignKey(e => e.SupervisorId);
        }
    }
    
}
