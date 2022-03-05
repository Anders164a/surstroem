using surstroem.Models;
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
        
        public WarehouseInfoDto WarehouseInfos { get; set; }
    }
}
