using surstroem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class UserBasicInfoDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }

        public UserBasicInfoDto()
        {

        }

        public UserBasicInfoDto(Employee employee)
        {
            Id = employee.User.Id;
            FirstName = employee.User.Firstname;
            LastName = employee.User.Lastname;
            Email = employee.User.Email;
            PhoneNumber = (int)employee.User.PhoneNumber;
        }
    }
}
