using Internship.Domain.Models.identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Domain.Models
{
    public class Report
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime SubmissionDate { get; set; }
        public string ReportType { get; set; } = "Weekly"; // Weekly, Monthly, Final

        public string StudentId { get; set; } = null!;
        public AppUser Student { get; set; } = null!;
    }
}
