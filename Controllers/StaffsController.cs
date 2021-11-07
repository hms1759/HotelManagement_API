using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApplication.Models;
using MyApplication.validation;

namespace MyApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffsController : ControllerBase
    {
        private readonly HotelMSDBContext _context;
        private readonly IMapper _mapper;

        public StaffsController(HotelMSDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Employees
        [HttpGet]
        [Route("allStaffs")]
        public async Task<ActionResult<IEnumerable<Staffs>>> GetDbEmployee()
        {
            var staffsList = await _context.DbStaff.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<staffsViewModel>>(staffsList));
        }

        // GET: api/Employees/5
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Staffs>> GetEmployee(int id)
        {
            var employee = await _context.DbStaff.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<StaffViewModel>(employee));
        }

        // PUT: api/Employees/5
        //Edit password
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> PutEmployee(int id, [FromBody] staffUpdateViewModel model)
        {
           // var staff = _mapper.Map<Staffs>(model);
            var staff = _context.DbStaff.FirstOrDefault(x => x.Id == id);
            if (staff == null)
            {
                return BadRequest("Staff with the Id not found");
            }
            staff.Password = model.Password;
            _context.Entry(staff).State = EntityState.Modified;

          
                await _context.SaveChangesAsync();
            return Ok(staff);

        }
    

        // POST: api/Employees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{addStaff}")]
        public async Task<ActionResult<Staffs>> AddStaff([FromBody]staffsViewModel model)
        {
            var check = _context.DbStaff.FirstOrDefault(x => x.Email == model.Email);
            if(check != null)
            {
                return BadRequest("emaill is already in use");
            }

            var validPhone = Regex.IsMatch(model.Phone, Validation.IsPhoneNumber) || Regex.IsMatch(model.Phone, Validation.IsPhoneNumberAlt);
            if (validPhone != true)
            {

                return BadRequest("input a valid Phone number");
            }

            var validEmail = Regex.IsMatch(model.Email, Validation.IsEmail);
            if (validEmail!= true)
            {

                return BadRequest("input a valid Email");
            }

         
            var staff = _mapper.Map<Staffs>(model);
            _context.DbStaff.Add(staff);

           int count = await _context.SaveChangesAsync();
            if (count < 1 )
            {
                return BadRequest();
            }

            return Ok(staff);


            //return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _context.DbStaff.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.DbStaff.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //public bool EmployeeExists(int id)
        //{
        //    return _context.DbStaff.Any(e => e.Id == id);
        //}
    }
}
