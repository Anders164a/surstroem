using API.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using surstroem.Data;
using surstroem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Service.Repositories
{
    public class EmployeeHasShiftRepository : GenericRepository<EmployeeHasShift, surstroemContext>, IEmployeeHasShiftRepository
    {
        public EmployeeHasShiftRepository(surstroemContext dbcontext)
            : base(dbcontext)
        {

        }

        public async Task<EmployeeHasShift> GetAllShiftsByEmployeeId(int employeeId)
        {
            return await _dbcontext.EmployeeHasShifts.Where(c => c.EmployeeId == employeeId)
                        .Include(e => e.Employee)
                        .Include(q => q.Employee.User)
                        .Include(s => s.Shifts)
                        .FirstOrDefaultAsync();
        }
    }
}
