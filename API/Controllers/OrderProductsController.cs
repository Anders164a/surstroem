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
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text;

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
        
                [HttpGet("GetWithName/{id}")]
        public async Task<IActionResult> GetOrderProductWithName(int id) 
        {
            OrderProduct orderProduct;
            OrderProductDto orderProductDto = new OrderProductDto();
            ProductDto product = new ProductDto();
            //DogDto dog = new DogDto(){};
            HttpClient client = new HttpClient();
            try
            {
                orderProduct = await _orderProductRepository.GetById(id);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.GetBaseException().Message);
                return StatusCode(500, ModelState);
            }
            string url = "http://10.130.54.110/api/product/1";// + orderProduct.ProductsId;
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadAsAsync<ProductDto>();
            }
            orderProductDto.Id = orderProduct.Id;
            orderProductDto.OrderId = orderProduct.OrderId;
            orderProductDto.Price = orderProduct.Price;
            orderProductDto.Quantity = orderProduct.Quantity;
            orderProductDto.ProductName = product.Title;
            orderProductDto.ProductColor = product.ColorId;

            return Ok(orderProductDto);
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
    }
}
