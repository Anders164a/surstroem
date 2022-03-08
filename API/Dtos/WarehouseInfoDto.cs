using surstroem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class WarehouseInfoDto
    {
        public int WarehouseId { get; set; }
        public string WarehouseStreetName { get; set; }
        public string WarehouseHouseNumber { get; set; }
        public string WarehouseFloor { get; set; }
        public string WarehouseAdditional { get; set; }
        public string WarehousePostal { get; set; }
        public string WarehouseCity { get; set; }
        public string WarehouseCountry { get; set; }
        public string WarehouseType { get; set; }

        public WarehouseInfoDto()
        {

        }

        public WarehouseInfoDto(Employee employee)
        {
            WarehouseId = employee.Warehouse.Id;
            WarehouseType = employee.Warehouse.WarehouseType.Type;
            WarehouseStreetName = employee.Warehouse.Address.StreetName;
            WarehouseHouseNumber = employee.Warehouse.Address.HouseNumber;
            WarehouseFloor = employee.Warehouse.Address.Floor;
            WarehouseAdditional = employee.Warehouse.Address.Additional;
            WarehousePostal = employee.Warehouse.Address.PostalCode.PostalCode1;
            WarehouseCity = employee.Warehouse.Address.PostalCode.CityName;
            WarehouseCountry = employee.Warehouse.Address.PostalCode.Country.Country1;
        }
    }
}
