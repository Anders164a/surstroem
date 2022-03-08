﻿using surstroem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class CountryDto
    {
        public int Id { get; set; }
        public string Country { get; set; }

        public CountryDto() { }

        public CountryDto(PostalCode postal) 
        {
            Id = postal.Country.Id;
            Country = postal.Country.Country1;
        }

        public CountryDto(Employee employee)
        {
            Id = employee.User.Address.PostalCode.Country.Id;
            Country = employee.User.Address.PostalCode.Country.Country1;
        }
    }
}
