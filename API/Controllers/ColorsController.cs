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
    public class ColorsController : ControllerBase
    {
        private IColorRepository _colorRepository;
        public ColorsController(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
        }

/*        // GET: api/Colors/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetColor(int id)
        {
            if (!await _colorRepository.entityExists(id))
                return NotFound();
            var product = await _colorRepository.GetById(id);

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
        //api/Colors
        [HttpPost]
        public async Task<IActionResult> CreateColor([FromBody] Color colorToCreate)
        {
            if (colorToCreate == null)
            {
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _colorRepository.Insert(colorToCreate);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.GetBaseException().Message);
                return StatusCode(500, ModelState);
            }

            return CreatedAtAction("GetColor", new { id = colorToCreate.Id }, colorToCreate);
        }

        */
        //api/Colors/id
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateColor(int id, [FromBody] Color updateColor)
        {
            if (updateColor == null)
            {
                return BadRequest(ModelState);
            }
            if (id != updateColor.Id)
            {
                return BadRequest(ModelState);
            }
            if (!await _colorRepository.entityExists(id))
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _colorRepository.Update(updateColor);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.GetBaseException().Message);
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        /*
        // DELETE: api/Colors/3
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteColor(int id)
        {
            if (!await _colorRepository.entityExists(id))
                return NotFound();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _colorRepository.Delete(id);
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
