using System;
using System.Collections.Generic;

#nullable disable

namespace surstroem.Models
{
    public partial class Warehouse
    {
        public Warehouse()
        {
            Stocks = new HashSet<Stock>();
        }

        public int Id { get; set; }
        public int? DepartmentId { get; set; }
        public int? WarehouseTypeId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Department Department { get; set; }
        public virtual WarehouseType WarehouseType { get; set; }
        public virtual ICollection<Stock> Stocks { get; set; }
    }
}
