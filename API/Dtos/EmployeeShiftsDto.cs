using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class EmployeeShiftsDto
    {
        public int EmployeeId { get; set; }
        public DateTime ShiftDate { get; set; }
        public UserDto User { get; set; }
        public ShiftDto Shift { get; set; }
    }
}
