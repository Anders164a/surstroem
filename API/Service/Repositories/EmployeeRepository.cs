﻿using API.Service.Interfaces;
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

        public async Task<ICollection<Employee>> GetEmployeesByWarehouse(int warehouseId)
        {
            return await _dbcontext.Employees.Where(c => c.WarehouseId == warehouseId)
                /*                .Include(c => c.Title)
                                .Include(c => c.Checked)
                                .Include(c => c.ShoppinglistId)*/
                .ToListAsync();
        }
    }
}
