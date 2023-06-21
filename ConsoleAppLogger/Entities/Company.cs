using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppLogger.Entities
{
    public class Company : BaseEntity
    {
        public string CompanyName { get; set; }
        public string Sector { get; set; }
        public string CompanyPhone { get; set; }
    }
}
