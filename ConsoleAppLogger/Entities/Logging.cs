using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppLogger.Entities
{
    public class Logging : BaseEntity
    {
        public string Description { get; set; }
        public int UserId { get; set; }
        public int CorporateId { get; set; }
        public int LogTypeId { get; set; }

    }
}
