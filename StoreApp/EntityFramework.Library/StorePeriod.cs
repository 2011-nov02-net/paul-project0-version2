using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFramework.Library
{
    public partial class StorePeriod
    {
        public int Id { get; set; }
        public int? StoreId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual Store Store { get; set; }
    }
}
