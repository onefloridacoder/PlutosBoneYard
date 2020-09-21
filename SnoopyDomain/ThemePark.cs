using System.Collections.Generic;
using System;

namespace SnoopyDomain
{
    public class ThemePark   
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Lot> Lots { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public ThemePark()
        {
            this.Lots = new List<Lot>();
        }
    }
}
