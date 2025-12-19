using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Application.Dtos
{
    public class ApplicationResponse
    {
        public int Id { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string Status { get; set; } = null!;
        public string StudentName { get; set; } = null!;
        public string InternshipOfferTitle { get; set; } = null!;

    }
}
