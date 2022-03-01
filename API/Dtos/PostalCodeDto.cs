using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class PostalCodeDto
    {
        public int Id { get; set; }
        public string Postal { get; set; }
        public string City { get; set; }
        public int CountryId { get; set; }
    }
}
