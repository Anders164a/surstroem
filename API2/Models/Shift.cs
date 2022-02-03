using System;
using System.Collections.Generic;

#nullable disable

namespace surstroem.Models
{
    public partial class Shift
    {
        public Shift()
        {
            EmployeeHasShifts = new HashSet<EmployeeHasShift>();
        }

        public int Id { get; set; }
        public int? DepartmentId { get; set; }
        public DateTime? ShiftStart { get; set; }
        public DateTime? ShiftEnd { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Department Department { get; set; }
        public virtual ICollection<EmployeeHasShift> EmployeeHasShifts { get; set; }
    }
}
