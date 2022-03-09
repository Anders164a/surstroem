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

        public UserBasicInfoDto User { get; set; }
        public WarehouseDto Warehouse { get; set; }

        public EmployeeDto()
        {

        }
    }
}
