using API.Dtos;
using API.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using surstroem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderProductsController : ControllerBase
    {
        private IOrderProductRepository _orderProductRepository;
        public OrderProductsController(IOrderProductRepository orderProductRepository)
        {
            _orderProductRepository = orderProductRepository;
        }

        // GET: api/OrderProducts/1
        [HttpGet("{id}"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetOrderProduct(int id)
        {
            if (!await _orderProductRepository.entityExists(id))
                return NotFound();
            var product = await _orderProductRepository.GetById(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(product);
        }

        //api/OrderProduct
        [HttpGet, Authorize(Roles = "Normal, Admin")]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetOrderProducts()
        {
            var orderProducts = await _orderProductRepository.GetAllAsync();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(orderProducts);
        }

        //api/OrderProducts
        [HttpPost]
        public async Task<IActionResult> CreateOrderProduct([FromBody] OrderProduct creditCardToCreate)
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
                await _orderProductRepository.Insert(creditCardToCreate);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.GetBaseException().Message);
                return StatusCode(500, ModelState);
            }

            return CreatedAtAction("GetOrderProduct", new { id = creditCardToCreate.Id }, creditCardToCreate);
        }


        //api/OrderProducts/id
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrderProduct(int id, [FromBody] OrderProduct updateOrderProduct)
        {
            if (updateOrderProduct == null)
            {
                return BadRequest(ModelState);
            }
            if (id != updateOrderProduct.Id)
            {
                return BadRequest(ModelState);
            }
            if (!await _orderProductRepository.entityExists(id))
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _orderProductRepository.Update(updateOrderProduct);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.GetBaseException().Message);
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }


        // DELETE: api/OrderProducts/3
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderProduct(int id)
        {
            if (!await _orderProductRepository.entityExists(id))
                return NotFound();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _orderProductRepository.Delete(id);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.GetBaseException().Message);
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpGet("OrderProductsName/{id}")]
        public async Task<IActionResult> GetOrderProductWithName(int id) 
        {
            OrderProduct orderProduct = new OrderProduct();
            try
            {
                orderProduct = await _orderProductRepository.GetOrderProductWithName(id);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.GetBaseException().Message);
                return StatusCode(500, ModelState);
            }
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://localhost/api/Users/1");
            OrderProductDto dto = new OrderProductDto();
            var json = JsonConvert.DeserializeObject(response.ToString());
            dto.ProductName = 


            return Ok();
        }

        /*[HttpGet("GetUserContactInformations/{userId}")]
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
        }*/
    }
}