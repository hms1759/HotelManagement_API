using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApplication.Models;
using MyApplication.VeiwModel;
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

        [HttpPost]

        [Route("login")]
        public async Task<ActionResult<Staffs>> LogmeIn(loginviewmodel log)
        {

            if(log.username == "admin" && log.password =="microsoft" )
            {
                return Ok(log);
            }

            var staff =  _context.DbStaff.FirstOrDefault(x => x.Email == log.username && x.Password == log.password);

            if (staff != null)
            {

                return Ok(_mapper.Map<staffsViewModel>(staff));

            }
            
            var visitor = _context.DbVisitor.FirstOrDefault(x => x.Email == log.username && x.Password == log.password);

            if (visitor != null)
            {

                return Ok(_mapper.Map<VisitorViewModel>(visitor));

            }
            else
            {

                return NotFound();
            }

        }
    }
}
