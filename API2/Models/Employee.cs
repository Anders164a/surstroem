﻿using System;
using System.Collections.Generic;

#nullable disable

namespace surstroem.Models
{
    public partial class Employee
    {
        public Employee()
        {
            EmployeeHasShifts = new HashSet<EmployeeHasShift>();
        }

        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? DepartmentId { get; set; }
        public int? WorkPhone { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<EmployeeHasShift> EmployeeHasShifts { get; set; }
    }
}
