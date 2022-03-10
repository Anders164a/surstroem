﻿using surstroem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class ShiftInfoDto
    {
        public int Id { get; set; }
        public DateTime ShiftStart { get; set; }
        public DateTime ShiftEnd { get; set; }

        //public WarehouseDto Warehouse { get; set; }

        public ShiftInfoDto()
        {

        }

        public ShiftInfoDto(EmployeeHasShift employeeHasShift)
        {
            Id = employeeHasShift.Shifts.Id;
            ShiftStart = employeeHasShift.Shifts.ShiftStart;
            ShiftEnd = employeeHasShift.Shifts.ShiftEnd;
            //Warehouse = new WarehouseDto(employeeHasShift.Shifts);
        }
    }
}
