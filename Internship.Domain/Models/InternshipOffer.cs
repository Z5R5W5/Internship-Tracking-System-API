using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Internship.Domain.Models
{
    public class InternshipOffer
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int RequiredStudentsCount { get; set; }
        public bool IsActive { get; set; }        
        public int CompanyId { get; set; }
        public Company Company { get; set; } = null!;

        public ICollection<Application> Applications { get; set; } = new List<Application>();

        public ICollection<Evaluation> Evaluations { get; set; } = new List<Evaluation>();

        public ICollection<Supervisor> Supervisors { get; set; } = new List<Supervisor>();

        public ICollection<Student> AcceptedStudents { get; set; } = new List<Student>();
    }
}
