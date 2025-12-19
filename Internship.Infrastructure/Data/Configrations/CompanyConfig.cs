using Internship.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Infrastructure.Data.Configrations
{
    public class CompanyConfig : IEntityTypeConfiguration<Company>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(c => c.Address)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(c => c.ContactEmail)
                .IsRequired()
                .HasMaxLength(100);
            builder.HasMany(c => c.InternshipOffers)
                .WithOne(io => io.Company)
                .HasForeignKey(io => io.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
