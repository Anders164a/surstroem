using surstroem.Models;
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

        public CountryDto Country { get; set; }


        public PostalCodeDto() { }

        public PostalCodeDto (Address address) 
        {
            Id = address.PostalCode.Id;
            Postal = address.PostalCode.PostalCode1;
            City = address.PostalCode.CityName;
            Country = new CountryDto(address.PostalCode);
        }

        public PostalCodeDto(Employee employee)
        {
            Id = employee.User.Address.PostalCode.Id;
            Postal = employee.User.Address.PostalCode.PostalCode1;
            City = employee.User.Address.PostalCode.CityName;
            Country = new CountryDto(employee);
        }
    }
}
