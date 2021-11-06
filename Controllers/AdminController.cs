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
    public class AdminController : ControllerBase
    {
        private readonly HotelMSDBContext _context;

        private readonly IMapper _mapper;


        public AdminController(HotelMSDBContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        // GET: api/CashAdvances
     
        // GET: api/CashAdvances
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CashAdvance>>> GetDbCashAdvance_all()
        {
            var collectorlist = await _context.DbCashAdvance.OrderByDescending(x=> x.requestDate).ToListAsync();
            return Ok(_mapper.Map<IEnumerable<CashAdvanceViewModel>>(collectorlist));
        }

    

      

      

    }
}
