﻿using Microsoft.AspNetCore.Mvc;
using surstroem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class AddressDto
    {
        public int Id { get; set; }
        public string StreetName { get; set; }
        public string HouseNumber { get; set; }
        public string Floor { get; set; }
        public string Additional { get; set; }

        public PostalCodeDto PostalCodeDto { get; set; }

        public AddressDto()
        {

        }

        public AddressDto(User user)
        {
            Id = user.Address.Id;
            StreetName = user.Address.StreetName;
            HouseNumber = user.Address.HouseNumber;
            Floor = user.Address.Floor;
            Additional = user.Address.Additional;
        }
    }
}
