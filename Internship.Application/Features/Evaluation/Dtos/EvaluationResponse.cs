using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Evaluation.Dtos
{
    public class EvaluationResponse
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public string Comments { get; set; } = string.Empty;
        public DateTime EvaluationDate { get; set; }
        public string SupervisorName { get; set; } = string.Empty;
        public string InternshipOfferTitle { get; set; } = string.Empty;
    }
}
