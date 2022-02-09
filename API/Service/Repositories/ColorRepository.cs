using API.Service.Interfaces;
using API.Service.Interfaces;
using API.Service.Repositories;
using surstroem.Data;
using surstroem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Service.Repositories
{
    public class ColorRepository : GenericRepository<Color, surstroemContext>, IColorRepository
    {
        public ColorRepository(surstroemContext dbcontext)
            : base(dbcontext)
        {

        }
    }
}
