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
    public class VisitorController : ControllerBase
    {
        private readonly HotelMSDBContext _context;

        private readonly IMapper _mapper;


        public VisitorController(HotelMSDBContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        // GET: api/CashAdvances
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CashAdvance>>> GetDbCashAdvance()
        {
            var collectorlist = await _context.DbCashAdvance.OrderByDescending(x=> x.requestDate).Where(x=> x.requestStatus.Contains("Pending")).ToListAsync();
            return Ok(_mapper.Map<IEnumerable<CashAdvanceViewModel>>(collectorlist));
        }
        
        // GET: api/CashAdvances/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CashAdvance>> GetCashAdvance(int id)
        {

            var cashCollector = await _context.DbCashAdvance.FindAsync(id);

            if (cashCollector == null)
            {
                return NotFound();
            }
            //await _context.DbCashAdvance.Where(x => x.department == cashCollector.department).FirstOrDefault();

            var HOd = _context.DbDepartment.Where(x => x.Name == cashCollector.department).FirstAsync();
            cashCollector.approvedBY = HOd.ToString();
            //  var cashCollector = await _context.DbCashAdvance.FindAsync(id);
            cashCollector.approvedDate = DateTime.UtcNow.ToString();
            cashCollector.requestStatus = "Approved";
            _context.Entry(cashCollector).State = EntityState.Modified;
            return Ok(_mapper.Map<CashAdvanceViewModel>(cashCollector));
        }

      

        // PUT: api/CashAdvances/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCashAdvance(int id )
        {

            

                var cashCollector = await _context.DbCashAdvance.FindAsync(id);

            cashCollector.approvedDate = DateTime.UtcNow.ToString();
            cashCollector.requestStatus = "Approved";
            _context.Entry(cashCollector).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CashAdvanceExists(id))
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

        // POST: api/CashAdvances
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CashAdvance>> PostCashAdvance([FromBody]CashAdvanceViewModel model)
        {
            var cashrequest = _mapper.Map<CashAdvance>(model);

          
            cashrequest.requestDate = DateTime.UtcNow.ToString();
            cashrequest.requestStatus = "Pending";

            _context.DbCashAdvance.Add(cashrequest);

            int count = await _context.SaveChangesAsync();
            if (count < 1)
            {

                return BadRequest("not saved");
            }

            return Ok(cashrequest);
        }

        // DELETE: api/CashAdvances/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCashAdvance(int id)
        {
            var cashAdvance = await _context.DbCashAdvance.FindAsync(id);
            if (cashAdvance == null)
            {
                return NotFound();
            }

            _context.DbCashAdvance.Remove(cashAdvance);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CashAdvanceExists(int id)
        {
            return _context.DbCashAdvance.Any(e => e.Id == id);
        }
    }
}
