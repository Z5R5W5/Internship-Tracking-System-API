using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Application.Features.Student.Dtos
{
    public class StudentResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string UniversityId { get; set; } = string.Empty;
        public string Major { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

    }
}
