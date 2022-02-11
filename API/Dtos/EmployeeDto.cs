using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int WarehouseId { get; set; }
        public int WorkPhone { get; set; }
    }
}
