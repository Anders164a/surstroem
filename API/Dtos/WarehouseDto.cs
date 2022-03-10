using surstroem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class WarehouseDto
    {
        public int Id { get; set; }

        public WarehouseTypeDto WarehouseType { get; set; }
        public AddressDto Address { get; set; }

        public WarehouseDto()
        {

        }

        public WarehouseDto(Employee employee)
        {
            Id = employee.Warehouse.Id;
            WarehouseType = new WarehouseTypeDto(employee.Warehouse);
            Address = new AddressDto(employee.Warehouse);
        }

        public WarehouseDto(Shift shift)
        {
            Id = shift.Warehouse.Id;
            WarehouseType = new WarehouseTypeDto(shift.Warehouse);
            Address = new AddressDto(shift.Warehouse);
        }
    }
}
