using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogInController : ControllerBase
    {
        private readonly HotelMSDBContext _context;
        private readonly IMapper _mapper;

        public LogInController(HotelMSDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<ActionResult<Department>> GetEmployee(Department mail)
        {
            var employee = await _context.DbDepartment.FindAsync(mail.hodName);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<staffsViewModel>(employee));
        }
    }
}
