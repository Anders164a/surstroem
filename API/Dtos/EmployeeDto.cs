using surstroem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public int WorkPhone { get; set; }

        public UserDto User { get; set; }
        public WarehouseDto Warehouse { get; set; }

        public EmployeeDto()
        {

        }

        public EmployeeDto(EmployeeHasShift employeeHasShift)
        {
            Id = employeeHasShift.Employee.Id;
            WorkPhone = (int)employeeHasShift.Employee.WorkPhone;
            User = new UserDto(employeeHasShift.Employee);
            Warehouse = new WarehouseDto(employeeHasShift.Employee);
        }
    }
}
