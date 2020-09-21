using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnoopyDomain
{
    public class Lot
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public int ThemeParkId { get; set; }

        public List<Row> Rows { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public Lot()
        {
            //this.CreatedBy = "Postman";
            //this.CreatedDate = DateTime.Now;
            this.Rows = new List<Row>();
        }
    }
}
