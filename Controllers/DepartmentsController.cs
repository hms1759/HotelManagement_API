using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApplication.Models;

namespace MyApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly HotelMSDBContext _context;

        private readonly IMapper _mapper;


        public DepartmentsController(HotelMSDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Departments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetDbDepartment()
        {
            var department = await _context.DbDepartment.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<DepartmentViewModel>>(department));
        }

        // GET: api/Departments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetDepartment(int id)
        {
            var employee = await _context.DbDepartment.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<DepartmentViewModel>(employee));
        }




        // PUT: api/Departments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartment(int id, Department department)
        {
            if (id != department.Id)
            {
                return BadRequest();
            }

            _context.Entry(department).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Departments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Department>> PostDepartment([FromBody]  DepartmentViewModel model)
        {
            var department = _mapper.Map<Department>(model);
            _context.DbDepartment.Add(department);

            int count = await _context.SaveChangesAsync();
            if (count < 1)
            {
                return BadRequest();
            }

            return Ok(department);

        }

        // DELETE: api/Departments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var department = await _context.DbDepartment.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }

            _context.DbDepartment.Remove(department);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DepartmentExists(int id)
        {
            return _context.DbDepartment.Any(e => e.Id == id);
        }
    }
}
