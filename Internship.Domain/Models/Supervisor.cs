using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Domain.Models
{
    public class Supervisor
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = "Academic"; // Academic or Company

        public int InternshipOfferId { get; set; }
        public InternshipOffer InternshipOffer { get; set; } = null!;

        public ICollection<Evaluation> EvaluationsGiven { get; set; } = new List<Evaluation>();

    }
}
