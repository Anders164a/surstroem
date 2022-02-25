using surstroem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Service.Interfaces
{
    public interface IEmployeeHasShiftRepository : IGenericRepository<EmployeeHasShift>
    {
        Task<EmployeeHasShift> GetAllShiftsByEmployeeId(int employeeId);
    }
}
