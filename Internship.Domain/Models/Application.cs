using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Domain.Models
{
    public class Application
    {
        public int Id { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string Status { get; set; } = "Pending"; // Pending, Accepted, Rejected
        public int StudentId { get; set; }
        public Student Student { get; set; } = null!;
        public int InternshipOfferId { get; set; }
        public InternshipOffer InternshipOffer { get; set; } = null!;
    }
}
