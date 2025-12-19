using Internship.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Infrastructure.Data
{
    public class InternshipDbContext : DbContext
    {
        public InternshipDbContext(DbContextOptions<InternshipDbContext> options) : base(options)
        {

        }
        public DbSet<Internship.Domain.Models.Application> applications { get; set; }
        public DbSet<InternshipOffer> internshipOffers { get; set; }
        public DbSet<Student> students { get; set; }
        public DbSet<Evaluation> evaluations { get; set; }
        public DbSet<Company> companies { get; set; }
        public DbSet<Supervisor> supervisors { get; set; }
        public DbSet<Report> reports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
