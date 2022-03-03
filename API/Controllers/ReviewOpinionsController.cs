using API.Dtos;
using API.Service.Interfaces;
using API.Service.Repositories;
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
    public class ReviewOpinionsController : ControllerBase
    {
        private IReviewOpinionRepository _reviewOpinionRepository;
        public ReviewOpinionsController(IReviewOpinionRepository reviewOpinionRepository)
        {
            _reviewOpinionRepository = reviewOpinionRepository;
        }

        // GET: api/ReviewOpinions/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReviewOpinion(int id)
        {
            if (!await _reviewOpinionRepository.entityExists(id))
                return NotFound();
            var product = await _reviewOpinionRepository.GetById(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(product);
        }

        //api/ReviewOpinions
        [HttpGet]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetReviewOpinions()
        {
            var ReviewOpinions = await _reviewOpinionRepository.GetAllAsync();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(ReviewOpinions);
        }

        //api/ReviewOpinions
        [HttpPost]
        public async Task<IActionResult> CreateReviewOpinion([FromBody] ReviewOpinion ReviewOpinionsToCreate)
        {
            if (ReviewOpinionsToCreate == null)
            {
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _reviewOpinionRepository.Insert(ReviewOpinionsToCreate);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.GetBaseException().Message);
                return StatusCode(500, ModelState);
            }

            return CreatedAtAction("GetReviewOpinions", new { id = ReviewOpinionsToCreate.Id }, ReviewOpinionsToCreate);
        }


        //api/ReviewOpinions/id
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReviewOpinion(int id, [FromBody] ReviewOpinion updateReviewOpinion)
        {
            if (updateReviewOpinion == null)
            {
                return BadRequest(ModelState);
            }
            if (id != updateReviewOpinion.Id)
            {
                return BadRequest(ModelState);
            }
            if (!await _reviewOpinionRepository.entityExists(id))
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _reviewOpinionRepository.Update(updateReviewOpinion);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.GetBaseException().Message);
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }


        // DELETE: api/ReviewOpinions/3
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReviewOpinion(int id)
        {
            if (!await _reviewOpinionRepository.entityExists(id))
                return NotFound();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _reviewOpinionRepository.Delete(id);
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