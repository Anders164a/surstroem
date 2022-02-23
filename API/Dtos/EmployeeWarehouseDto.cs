using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class EmployeeWarehouseDto
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int WorkPhone { get; set; }
        public string Email { get; set; }
        public int Warehouse { get; set; }
        public string WarehouseStreetName { get; set; }
        public string WarehouseHouseNumber { get; set; }
        public string WarehouseFloor { get; set; }
        public string WarehouseAdditional { get; set; }
        public string WarehousePostal { get; set; }
        public string WarehouseCity { get; set; }
        public string WarehouseCountry { get; set; }
    }
}
