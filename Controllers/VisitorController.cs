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
using MyApplication.Models.ModelDbContext;
using MyApplication.validation;
using MyApplication.VeiwModel;

namespace MyApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorController : ControllerBase
    {
        private readonly HotelMSDBContext _context;
        private readonly IMapper _mapper;

        public VisitorController(HotelMSDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Employees
        [HttpGet]
        [Route("allVisitor")]
        public async Task<ActionResult<IEnumerable<Visitor>>> GetDbVisitor()
        {
            var VisitorList = await _context.DbVisitor.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<VisitorViewModel>>(VisitorList));
        }

        // GET: api/Employees/5
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Visitor>> Getvisitor(int id)
        {
            var employee = await _context.DbVisitor.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<VisitorViewModel>(employee));
        }

        // PUT: api/Employees/5
        //Edit password
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> EditVisitor(int id, [FromBody] VisitorViewModel model)
        {
            // var staff = _mapper.Map<Visitor>(model);
            var staff = _context.DbVisitor.FirstOrDefault(x => x.Id == id);
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
        [HttpPost("{creatVisitor}")]
        public async Task<ActionResult<Visitor>> AddVisitor([FromBody] VisitorViewModel model)
        {
            var check = _context.DbVisitor.FirstOrDefault(x => x.Email == model.Email);
            if (check != null)
            {
                return BadRequest("emaill is already in use");
            }

            var validPhone = Regex.IsMatch(model.Phone, Validation.IsPhoneNumber) || Regex.IsMatch(model.Phone, Validation.IsPhoneNumberAlt);
            if (validPhone != true)
            {

                return BadRequest("input a valid Phone number");
            }

            var validEmail = Regex.IsMatch(model.Email, Validation.IsEmail);
            if (validEmail != true)
            {

                return BadRequest("input a valid Email");
            }


            var visitor = _mapper.Map<Visitor>(model);
            _context.DbVisitor.Add(visitor);

            int count = await _context.SaveChangesAsync();
            if (count < 1)
            {
                return BadRequest();
            }

            return Ok(visitor);


            //return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVisitor(int id)
        {
            var visitor = await _context.DbVisitor.FindAsync(id);
            if (visitor == null)
            {
                return NotFound();
            }

            _context.DbVisitor.Remove(visitor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //public bool EmployeeExists(int id)
        //{
        //    return _context.DbVisitor.Any(e => e.Id == id);
        //}
    }
}
