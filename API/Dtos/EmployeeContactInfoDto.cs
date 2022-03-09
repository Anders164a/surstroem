using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class EmployeeContactInfoDto
    {
        public int EmployeeId { get; set; }
        public int WorkPhone { get; set; }

        public UserBasicInfoDto UserInfo { get; set; }
        public EmployeeAddressDto AddressInfo { get; set; }
        public WarehouseInfoDto WarehouseInfos { get; set; }
    }
}
