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
        public int WarehouseTypeId { get; set; }

        public AddressDto Address { get; set; }

        public WarehouseDto()
        {

        }

        public WarehouseDto(Employee employee)
        {
            Id = employee.Warehouse.Id;
            WarehouseTypeId = employee.Warehouse.WarehouseTypeId;
        }
    }
}
