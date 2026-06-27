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
    public class EvaluationConfig : IEntityTypeConfiguration<Evaluation>
    {
        public void Configure(EntityTypeBuilder<Evaluation> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Score)
                .IsRequired();
            builder.Property(e => e.Comments)
                .IsRequired()
                .HasMaxLength(500);
            builder.Property(e => e.EvaluationDate)
                .IsRequired();
            builder.HasOne(e => e.Supervisor)
                .WithMany(u => u.GivenEvaluations)
                .HasForeignKey(e => e.SupervisorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Student)
                .WithMany(u => u.ReceivedEvaluations)
                .HasForeignKey(e => e.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(e => e.InternshipOffer)
                .WithMany(io => io.Evaluations)
                .HasForeignKey(e => e.InternshipOfferId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
