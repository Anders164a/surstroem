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
    public class OrderProductRepository : GenericRepository<OrderProduct, surstroemContext>, IOrderProductRepository
    {
        public OrderProductRepository(surstroemContext dbcontext)
            : base(dbcontext)
        {

        }
    }
}
