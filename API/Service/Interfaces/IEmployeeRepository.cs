using surstroem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Service.Interfaces
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Task<ICollection<Employee>> GetEmployeesWithWarehouseInfo();
        Task<ICollection<Employee>> GetEmployeesContactInfo();
    }
}
