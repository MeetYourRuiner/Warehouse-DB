using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBClient.Models
{
    public class CompanyDetails
    {
        public string Name { get; set; }
        public string PostalCode { get; set; }
        public string Address { get; set; }
        public string INN { get; set; }
        public string KPP { get; set; }
    }
}
