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

        public int SupervisorId { get; set; }
        public Supervisor Supervisor { get; set; } = null!;
        public int InternshipOfferId { get; set; }
        public InternshipOffer InternshipOffer { get; set; } = null!;

    }
}
