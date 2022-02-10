using API.Dtos;
using API.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using surstroem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserRepository _userRepository;
        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: api/Users/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            if (!await _userRepository.entityExists(id))
                return NotFound();
            var user = await _userRepository.GetById(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(user);
        }

        //api/User
        [HttpGet]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userRepository.GetAllAsync();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userDto = new List<UserDto>();

            foreach (var a in users)
            {
                userDto.Add(new UserDto
                {
                    Id = a.Id,
                    FirstName = a.Firstname,
                    LastName = a.Lastname,
                    Email = a.Email,
                    Password = a.Password,
                    PhoneNumber = (int)a.PhoneNumber,
                    AddressId = (int)a.AddressId
                });
            }
            return Ok(userDto);
        }

        //api/Users
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User userToCreate)
        {
            if (userToCreate == null)
            {
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _userRepository.Insert(userToCreate);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.GetBaseException().Message);
                return StatusCode(500, ModelState);
            }

            return CreatedAtAction("GetUser", new { id = userToCreate.Id }, userToCreate);
        }


        //api/Users/id
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCreditCard(int id, [FromBody] CreditCard updateCreditCard)
        {
            if (updateCreditCard == null)
            {
                return BadRequest(ModelState);
            }
            if (id != updateCreditCard.Id)
            {
                return BadRequest(ModelState);
            }
            if (!await _creditCardRepository.entityExists(id))
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _creditCardRepository.Update(updateCreditCard);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.GetBaseException().Message);
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }


        // DELETE: api/Users/3
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCreditCard(int id)
        {
            if (!await _creditCardRepository.entityExists(id))
                return NotFound();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _creditCardRepository.Delete(id);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.GetBaseException().Message);
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
