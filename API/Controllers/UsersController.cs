using API.Dtos;
using API.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using surstroem.Data;
using surstroem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

            return Ok(users);
        }

        [HttpGet("GetUsersByAdressId/{addressId}")]
        public async Task<IActionResult> GetUsersByAddress(int addressId)
        {
            ICollection<User> users;

            users = await _userRepository.GetUsersByAddressId(addressId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(users);
        }

        [HttpGet("GetUserContactInformations/{userId}")]
        public async Task<IActionResult> GetUserContactInformationById(int userId)
        {
            if (!await _userRepository.entityExists(userId))
                return NotFound();
            var chosenUser = await _userRepository.GetUserContactInformation(userId);

            var userDto = new UserContactInfoDto();

            userDto.FirstName = chosenUser.Firstname;
            userDto.LastName = chosenUser.Lastname;
            userDto.Email = chosenUser.Email;
            userDto.PhoneNumber = (int)chosenUser.PhoneNumber;
            userDto.StreetName = chosenUser.Address.StreetName;
            userDto.HouseNumber = chosenUser.Address.HouseNumber;
            userDto.Floor = chosenUser.Address.Floor;
            userDto.Additional = chosenUser.Address.Additional;
            userDto.PostalCode = chosenUser.Address.PostalCode.PostalCode1;
            userDto.CityName = chosenUser.Address.PostalCode.CityName;
            userDto.Country = chosenUser.Address.PostalCode.Country.Country1;


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(userDto);
        }

        //api/Users
        [HttpPost]
        public async Task<IActionResult> CreateUser(string password, [FromBody] User userToCreate)
        {
            if (userToCreate == null)
            {
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //kode til hash
            CreatePasswordHash(password, out string passwordHash, out string passwordSalt);

            userToCreate.PasswordHash = passwordHash;
            userToCreate.PasswordSalt = passwordSalt;

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
        public async Task<IActionResult> UpdateUser(int id, string newPassword, [FromBody] User updateUser)
        {
            if (updateUser == null)
            {
                return BadRequest(ModelState);
            }
            if (id != updateUser.Id)
            {
                return BadRequest(ModelState);
            }
            if (!await _userRepository.entityExists(id))
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //kode til hash
            CreatePasswordHash(newPassword, out string passwordHash, out string passwordSalt);

            updateUser.PasswordHash = passwordHash;
            updateUser.PasswordSalt = passwordSalt;
            try
            {
                await _userRepository.Update(updateUser);
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
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (!await _userRepository.entityExists(id))
                return NotFound();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _userRepository.Delete(id);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.GetBaseException().Message);
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        //api/Users/id
        [HttpPut("ChangeUserPassword/{userId}")]
        public async Task<IActionResult> ChangeUserPassword(int userId, string password)
        {

            //kode til hash
            CreatePasswordHash(password, out string passwordHash, out string passwordSalt);

            try
            {
                await _userRepository.PutNewUserPassword(userId, passwordHash, passwordSalt);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.GetBaseException().Message);
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        //api/Users/id
        [HttpPut("ChangeUserAddress/{userId}")]
        public async Task<IActionResult> ChangeUserAddress(int userId, int addressId)
        {
            try
            {
                await _userRepository.PutNewUserAddress(userId, addressId);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.GetBaseException().Message);
                return StatusCode(500, ModelState);
            }

            return Ok("AddressId changed to " + addressId);
        }

        //api/Users/id
        [HttpPut("ChangeUserInfo/{userId}")]
        public async Task<IActionResult> ChangeUserInfo(int userId, string firstName, string lastName, string email, int phoneNumber)
        {
            try
            {
                await _userRepository.PutNewUserInfo(userId, firstName, lastName, email, phoneNumber);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.GetBaseException().Message);
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        private void CreatePasswordHash(string password, out string passwordHash, out string passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                var salt = hmac.Key;
                var hash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                // From byte array to string
                passwordHash = System.Text.Encoding.UTF8.GetString(hash, 0, hash.Length);
                passwordSalt = System.Text.Encoding.UTF8.GetString(salt, 0, salt.Length);
            }
        }
    }
}
