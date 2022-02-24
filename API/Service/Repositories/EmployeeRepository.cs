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
    public class EmployeeRepository : GenericRepository<Employee, surstroemContext>, IEmployeeRepository
    {
        public EmployeeRepository(surstroemContext dbcontext)
            : base(dbcontext)
        {

        }

        public async Task<ICollection<Employee>> GetEmployeesWithWarehouseInfo()
        {
            return await _dbcontext.Set<Employee>()
                .Include(e => e.User)
                .Include(c => c.Warehouse)
                .Include(s => s.Warehouse.WarehouseType)
                .Include(f => f.Warehouse.Address)
                .Include(a => a.Warehouse.Address.PostalCode)
                .Include(w => w.Warehouse.Address.PostalCode.Country)
                //.AsSplitQuery()
                .ToListAsync();
        }
    }
}
