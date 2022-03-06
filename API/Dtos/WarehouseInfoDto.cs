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

        public WarehouseInfoDto(Employee emp)
        {
            WarehouseId = emp.Warehouse.Id;
            WarehouseType = emp.Warehouse.WarehouseType.Type;
            WarehouseStreetName = emp.Warehouse.Address.StreetName;
            WarehouseHouseNumber = emp.Warehouse.Address.HouseNumber;
            WarehouseFloor = emp.Warehouse.Address.Floor;
            WarehouseAdditional = emp.Warehouse.Address.Additional;
            WarehousePostal = emp.Warehouse.Address.PostalCode.PostalCode1;
            WarehouseCity = emp.Warehouse.Address.PostalCode.CityName;
            WarehouseCountry = emp.Warehouse.Address.PostalCode.Country.Country1;
        }
    }
}
