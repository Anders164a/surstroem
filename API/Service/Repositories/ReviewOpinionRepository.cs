using API.Service.Interfaces;
using surstroem.Data;
using surstroem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Service.Repositories
{
    public class ReviewOpinionRepository : GenericRepository<ReviewOpinion, surstroemContext>, IReviewOpinionRepository
    {
        public ReviewOpinionRepository(surstroemContext dbcontext)
            : base(dbcontext)
        {

        }
    }
}