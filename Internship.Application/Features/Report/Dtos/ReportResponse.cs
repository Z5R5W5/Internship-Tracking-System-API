using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Report.Dtos
{
    public class ReportResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime SubmissionDate { get; set; }
        public string ReportType { get; set; }
        public string StudrntName { get; set; }
    }
}
