using surstroem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class ShiftDto
    {
        public int Id { get; set; }
        public int WarehouseId { get; set; }
        public DateTime ShiftStart { get; set; }
        public DateTime ShiftEnd { get; set; }

        public ShiftDto()
        {
                
        }

        public ShiftDto(EmployeeHasShift employeeHasShift)
        {
            Id = employeeHasShift.Id;
            ShiftStart = employeeHasShift.Shifts.ShiftStart;
            ShiftEnd = employeeHasShift.Shifts.ShiftEnd;
        }

        public ShiftDto(Warehouse warehouse)
        {

        }
    }
}
