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
            var employee = await _employeeRepository.GetById(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(employee);
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

            foreach (var employee in employees)
            {
                employeeDto.Add(new EmployeeDto
                {
                    Id = employee.Id,
                    UserId = employee.UserId,
                    WarehouseId = employee.WarehouseId,
                    WorkPhone = (int)employee.WorkPhone
                });
            }
            return Ok(employeeDto);
        }

        //api/Employees
        [HttpGet("GetEmployeesWithWarehouseInfo")]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetEmployeesWithWarehouseInfos()
        {
            var employees = await _employeeRepository.GetEmployeesWithWarehouseInfo();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employeeDto = new List<EmployeeWarehouseDto>();

            foreach (var employee in employees)
            {
                employeeDto.Add(new EmployeeWarehouseDto
                {
                    EmployeeId = employee.Id,
                    FirstName = employee.User.Firstname,
                    LastName = employee.User.Lastname,
                    WorkPhone = (int)employee.WorkPhone,
                    Email = employee.User.Email,
                    WarehouseInfoDto = new WarehouseInfoDto(employee.Warehouse.Address.StreetName)
                });
            }
            return Ok(employeeDto);
        }

        //api/Employees
        [HttpGet("GetEmployeesContactInfo")]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetEmployeesContactInfo()
        {
            var employees = await _employeeRepository.GetEmployeesContactInfo();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employeeDto = new List<EmployeeContactInfoDto>();

            foreach (var employee in employees)
            {
                employeeDto.Add(new EmployeeContactInfoDto
                {
                    EmployeeId = employee.Id,
                    FirstName = employee.User.Firstname,
                    LastName = employee.User.Lastname,
                    PhoneNumber = (int)employee.User.PhoneNumber,
                    WorkPhone = (int)employee.WorkPhone,
                    Email = employee.User.Email,
                    StreetName = employee.User.Address.StreetName,
                    HouseNumber = employee.User.Address.HouseNumber,
                    Floor = employee.User.Address.Floor,
                    Additional = employee.User.Address.Additional,
                    PostalCode = employee.User.Address.PostalCode.PostalCode1,
                    CityName = employee.User.Address.PostalCode.CityName,
                    Country = employee.User.Address.PostalCode.Country.Country1,
                    WareHouseId = employee.Warehouse.Id,
                    WareHouseType = employee.Warehouse.WarehouseType.Type
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