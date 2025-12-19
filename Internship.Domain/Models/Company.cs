using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Domain.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ContactEmail { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

   
        public ICollection<InternshipOffer> InternshipOffers { get; set; } = new List<InternshipOffer>();
    }
}
