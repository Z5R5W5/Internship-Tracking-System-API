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
    public class internshipOfferConfig : IEntityTypeConfiguration<InternshipOffer>
    {
        public void Configure(EntityTypeBuilder<InternshipOffer> builder)
        {
            builder.HasKey(io => io.Id);
            builder.Property(io => io.Title)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(io => io.Description)
                .IsRequired()
                .HasMaxLength(1000);
            builder.Property(io => io.Location)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(io => io.StartDate)
                .IsRequired();
            builder.Property(io => io.EndDate)
                .IsRequired();
            builder.HasOne(io => io.Company)
                .WithMany(c => c.InternshipOffers)
                .HasForeignKey(io => io.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(io => io.Applications)
                .WithOne(a => a.InternshipOffer)
                .HasForeignKey(a => a.InternshipOfferId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(io => io.Evaluations)
                .WithOne(e => e.InternshipOffer)
                .HasForeignKey(e => e.InternshipOfferId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
