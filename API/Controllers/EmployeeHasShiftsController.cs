﻿using API.Dtos;
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
    public class EmployeeHasShiftsController : ControllerBase
    {
        private IEmployeeHasShiftRepository _employeeHasShiftRepository;
        public EmployeeHasShiftsController(IEmployeeHasShiftRepository employeeHasShiftRepository)
        {
            _employeeHasShiftRepository = employeeHasShiftRepository;
        }

        // GET: api/EmployeeHasShifts/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeHasShift(int id)
        {
            if (!await _employeeHasShiftRepository.entityExists(id))
                return NotFound();
            var EmployeeHasShift = await _employeeHasShiftRepository.GetById(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(EmployeeHasShift);
        }

        //api/EmployeeHasShifts
        [HttpGet]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetEmployeeHasShifts()
        {
            var EmployeeHasShifts = await _employeeHasShiftRepository.GetAllAsync();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var EmployeeHasShiftDto = new List<EmployeeShiftsDto>();

            foreach (var a in EmployeeHasShifts)
            {
                EmployeeHasShiftDto.Add(new EmployeeShiftsDto
                {
                    EmployeeId = a.EmployeeId,
                    FirstName = a.Employee.User.Firstname,
                    LastName = a.Employee.User.Lastname,
                    Email = a.Employee.User.Email,
                    ShiftDate = a.Date,
                    ShiftStart = a.Shifts.ShiftStart,
                    ShiftEnd = a.Shifts.ShiftEnd
                });
            }
            return Ok(EmployeeHasShiftDto);
        }

        //api/EmployeeHasShifts
        [HttpPost]
        public async Task<IActionResult> CreateEmployeeHasShift([FromBody] EmployeeHasShift EmployeeHasShiftToCreate)
        {
            if (EmployeeHasShiftToCreate == null)
            {
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _employeeHasShiftRepository.Insert(EmployeeHasShiftToCreate);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.GetBaseException().Message);
                return StatusCode(500, ModelState);
            }

            return CreatedAtAction("GetEmployeeHasShift", new { id = EmployeeHasShiftToCreate.Id }, EmployeeHasShiftToCreate);
        }


        //api/EmployeeHasShifts/id
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployeeHasShift(int id, [FromBody] EmployeeHasShift updateEmployeeHasShift)
        {
            if (updateEmployeeHasShift == null)
            {
                return BadRequest(ModelState);
            }
            if (id != updateEmployeeHasShift.Id)
            {
                return BadRequest(ModelState);
            }
            if (!await _employeeHasShiftRepository.entityExists(id))
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _employeeHasShiftRepository.Update(updateEmployeeHasShift);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.GetBaseException().Message);
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }


        // DELETE: api/EmployeeHasShifts/3
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeHasShift(int id)
        {
            if (!await _employeeHasShiftRepository.entityExists(id))
                return NotFound();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _employeeHasShiftRepository.Delete(id);
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
