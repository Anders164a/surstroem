﻿using API.Dtos;
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
    public class EmployeesController : ControllerBase
    {
        private IEmployeeRepository _employeeRepository;
        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        // GET: api/Employees/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            if (!await _employeeRepository.entityExists(id))
                return NotFound();
            var product = await _employeeRepository.GetById(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(product);
        }

        //api/Employees
        [HttpGet]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _employeeRepository.GetAllAsync();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employeeDto = new List<EmployeeDto>();

            foreach (var a in employees)
            {
                employeeDto.Add(new EmployeeDto
                {
                    Id = a.Id,
                    UserId = a.UserId,
                    WarehouseId = a.WarehouseId,
                    WorkPhone = (int)a.WorkPhone
                });
            }
            return Ok(employeeDto);
        }

                //api/Employees
                [HttpPost]
                public async Task<IActionResult> CreateEmployee([FromBody] Employee EmployeeToCreate)
                {
                    if (EmployeeToCreate == null)
                    {
                        return BadRequest(ModelState);
                    }
                    if (!ModelState.IsValid)
                    {
                        return BadRequest(ModelState);
                    }

                    try
                    {
                        await _employeeRepository.Insert(EmployeeToCreate);
                    }
                    catch (Exception e)
                    {
                        ModelState.AddModelError("", e.GetBaseException().Message);
                        return StatusCode(500, ModelState);
                    }

                    return CreatedAtAction("GetEmployee", new { id = EmployeeToCreate.Id }, EmployeeToCreate);
                }


                //api/Employees/id
                [HttpPut("{id}")]
                public async Task<IActionResult> UpdateEmployee(int id, [FromBody] Employee updateEmployee)
                {
                    if (updateEmployee == null)
                    {
                        return BadRequest(ModelState);
                    }
                    if (id != updateEmployee.Id)
                    {
                        return BadRequest(ModelState);
                    }
                    if (!await _employeeRepository.entityExists(id))
                    {
                        return NotFound();
                    }
                    if (!ModelState.IsValid)
                    {
                        return BadRequest(ModelState);
                    }

                    try
                    {
                        await _employeeRepository.Update(updateEmployee);
                    }
                    catch (Exception e)
                    {
                        ModelState.AddModelError("", e.GetBaseException().Message);
                        return StatusCode(500, ModelState);
                    }

                    return NoContent();
                }


                // DELETE: api/Employees/3
                [HttpDelete("{id}")]
                public async Task<IActionResult> DeleteEmployee(int id)
                {
                    if (!await _employeeRepository.entityExists(id))
                        return NotFound();
                    if (!ModelState.IsValid)
                        return BadRequest(ModelState);

                    try
                    {
                        await _employeeRepository.Delete(id);
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