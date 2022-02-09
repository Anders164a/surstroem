using System;
using System.Collections.Generic;

#nullable disable

namespace surstroem.Models
{
    public partial class WarehouseType
    {
        public WarehouseType()
        {
            Warehouses = new HashSet<Warehouse>();
        }

        public int Id { get; set; }
        public string Type { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<Warehouse> Warehouses { get; set; }
    }
}
