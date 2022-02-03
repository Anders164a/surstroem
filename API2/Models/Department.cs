using System;
using System.Collections.Generic;

#nullable disable

namespace surstroem.Models
{
    public partial class Department
    {
        public Department()
        {
            Shifts = new HashSet<Shift>();
            Warehouses = new HashSet<Warehouse>();
        }

        public int Id { get; set; }
        public int? AddressId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<Shift> Shifts { get; set; }
        public virtual ICollection<Warehouse> Warehouses { get; set; }
    }
}
