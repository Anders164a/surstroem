using API2.Dtos;
using API2.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        private IColorRepository _colorRepository;
        public ColorController(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
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

        //api/Colors
        [HttpGet]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetColors()
        {
            var colors = await _colorRepository.GetAllAsync();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var colorDto = new List<ColorDto>();

            foreach (var color in colors)
            {
                colorDto.Add(new ColorDto
                {
                    Name = color.Name
                });
            }
            return Ok(colorDto);
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
