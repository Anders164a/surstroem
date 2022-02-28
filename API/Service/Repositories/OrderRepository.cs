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
    public class OrderRepository : GenericRepository<Order, surstroemContext>, IOrderRepository
    {
        public OrderRepository(surstroemContext dbcontext)
            : base(dbcontext)
        {

        }
    }
}
