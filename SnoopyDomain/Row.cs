using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnoopyDomain
{
    public class Row
    {
        public int Id { get; set; }
        public int LotId { get; set; }
        public string Name { get; set; }
        public int Available { get; set; }
        public int Occupied { get; set; }
        public bool Active { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

        public Row()
        {
            
        }
    }
}
