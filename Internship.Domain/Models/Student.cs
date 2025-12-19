using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Internship.Domain.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string UniversityId { get; set; } = string.Empty;
        public string Major { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;


        public ICollection<Application> Applications { get; set; } = new List<Application>();

        public ICollection<Report> Reports { get; set; } = new List<Report>();

        public int? AcceptedInternshipId { get; set; }
        public InternshipOffer? AcceptedInternship { get; set; }
    }
}
