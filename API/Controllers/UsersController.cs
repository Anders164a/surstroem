using API.Dtos;
using API.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
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

        /*        // GET: api/CreditCards/1
                [HttpGet("{id}")]
                public async Task<IActionResult> GetCreditCard(int id)
                {
                    if (!await _creditCardRepository.entityExists(id))
                        return NotFound();
                    var product = await _creditCardRepository.GetById(id);

                    if (!ModelState.IsValid)
                        return BadRequest(ModelState);

                    return Ok(product);
                }*/

        //api/Address
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
        /*
                //api/CreditCards
                [HttpPost]
                public async Task<IActionResult> CreateCreditCard([FromBody] CreditCard creditCardToCreate)
                {
                    if (creditCardToCreate == null)
                    {
                        return BadRequest(ModelState);
                    }
                    if (!ModelState.IsValid)
                    {
                        return BadRequest(ModelState);
                    }

                    try
                    {
                        await _creditCardRepository.Insert(creditCardToCreate);
                    }
                    catch (Exception e)
                    {
                        ModelState.AddModelError("", e.GetBaseException().Message);
                        return StatusCode(500, ModelState);
                    }

                    return CreatedAtAction("GetCreditCard", new { id = creditCardToCreate.Id }, creditCardToCreate);
                }


                //api/CreditCards/id
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


                // DELETE: api/CreditCards/3
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
                }*/
    }
}
