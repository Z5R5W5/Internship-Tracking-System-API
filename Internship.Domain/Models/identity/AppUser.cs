using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Domain.Models.identity
{
    public class AppUser : IdentityUser
    {
       public string DisplayName { get; set; } = string.Empty;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UniversityId { get; set; } 
        public string? Major { get; set; }
        public string? Address { get; set; } = string.Empty;
        public int? AcceptedInternshipId { get; set; }
        // Student
        public ICollection<Application> Applications { get; set; }
            = new List<Application>();

        public ICollection<Report> Reports { get; set; }
            = new List<Report>();

        // Company
        public ICollection<InternshipOffer> CreatedOffers { get; set; }
            = new List<InternshipOffer>();

        // Supervisor
        public ICollection<Evaluation> GivenEvaluations { get; set; }
            = new List<Evaluation>();

        // Student
        public ICollection<Evaluation> ReceivedEvaluations { get; set; }
            = new List<Evaluation>();
    }
}
