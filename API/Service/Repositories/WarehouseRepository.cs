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
    public class WarehouseRepository : GenericRepository<Warehouse, surstroemContext>, IWarehouseRepository
    {
        public WarehouseRepository(surstroemContext dbcontext)
            : base(dbcontext)
        {

        }

        public async Task<ICollection<Employee>> GetEmployeesByWarehouse(int warehouseId)
        {
            return await _dbcontext.Employees.Where(c => c.WarehouseId == warehouseId)
                               .Include(c => c.Id)
                                .Include(c => c.WarehouseId)
                                .Include(c => c.WarehouseId)
                .ToListAsync();
        }
    }
}
