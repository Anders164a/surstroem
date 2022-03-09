using surstroem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }

        public AddressDto Address { get; set; }

        public UserDto()
        {

        }

        public UserDto(Employee employee)
        {
            Id = employee.User.Id;
            FirstName = employee.User.Firstname;
            LastName = employee.User.Lastname;
            Email = employee.User.Email;
            PhoneNumber = (int)employee.User.PhoneNumber;
            Address = new AddressDto(employee.User);
        }
    }
}
