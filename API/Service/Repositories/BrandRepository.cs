using API.Service.Interfaces;
using surstroem.Data;
using surstroem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Service.Repositories
{
    public class BrandRepository : GenericRepository<Brand, surstroemContext>, IBrandRepository
    {
        public BrandRepository(surstroemContext dbcontext)
            : base(dbcontext)
        {

        }
    }
}
