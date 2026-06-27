using Internship.Domain.Models.identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Domain.Models
{
    public class Evaluation
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public string Comments { get; set; } = string.Empty;
        public DateTime EvaluationDate { get; set; }

        // Supervisor
        public string SupervisorId { get; set; } = string.Empty;
        public AppUser Supervisor { get; set; } = null!;

        // Student
        public string StudentId { get; set; } = string.Empty;
        public AppUser Student { get; set; } = null!;
        
        public int InternshipOfferId { get; set; }
        public InternshipOffer InternshipOffer { get; set; } = null!;

    }
}
