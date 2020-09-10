using System;

namespace PlutoDomain
{
    public class User
    {
        public string Id { get; set; }
        public string  WorkplaceCode { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdatedBy { get; set; }

    }
}
