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

        public WarehouseInfoDto(Warehouse warehouse)
        {
            WarehouseId = warehouse.Id;
            WarehouseType = warehouse.WarehouseType.Type;
            WarehouseStreetName = warehouse.Address.StreetName;
            WarehouseHouseNumber = warehouse.Address.HouseNumber;
            WarehouseFloor = warehouse.Address.Floor;
            WarehouseAdditional = warehouse.Address.Additional;
            WarehousePostal = warehouse.Address.PostalCode.PostalCode1;
            WarehouseCity = warehouse.Address.PostalCode.CityName;
            WarehouseCountry = warehouse.Address.PostalCode.Country.Country1;
        }
    }
}
