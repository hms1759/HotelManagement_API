using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
  
    public class OrderController : ControllerBase
    {
        private readonly HotelMSDBContext _context;
        private readonly IMapper _mapper;

        public OrderController(HotelMSDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Order
        [HttpGet]
        [Route("allOrder")]
        public async Task<ActionResult<IEnumerable<Order>>> GetDbOrder()
        {
            var OrderList = await _context.DbOrder.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<Order>>(OrderList));
        }

        // GET: api/Order/5
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _context.DbOrder.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<OrderViewModel>(order));
        }

        // PUT: api/Order/5
        //Edit password
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> EditOrder(int id, [FromBody] OrderViewModel model)
        {
            // var staff = _mapper.Map<Order>(model);
            var staff = _context.DbOrder.FirstOrDefault(x => x.id == id);
            if (staff == null)
            {
                return BadRequest("Staff with the Id not found");
            }

            _context.Entry(staff).State = EntityState.Modified;

          //  staff = model.

            await _context.SaveChangesAsync();
            return Ok(staff);

        }


        // POST: api/Order
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{creatOrder}")]
        public async Task<ActionResult<Order>> AddOrder([FromBody] OrderViewModel model)
        {
            model.Date = DateTime.UtcNow.ToLongDateString();

            var Order = _mapper.Map<Order>(model);
            _context.DbOrder.Add(Order);

            int count = await _context.SaveChangesAsync();
            if (count < 1)
            {
                return BadRequest();
            }

            return Ok(Order);


            //return CreatedAtAction("GetOrder", new { id = Order.Id }, Order);
        }

        // DELETE: api/Order/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var Order = await _context.DbOrder.FindAsync(id);
            if (Order == null)
            {
                return NotFound();
            }

            _context.DbOrder.Remove(Order);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //public bool OrderExists(int id)
        //{
        //    return _context.DbOrder.Any(e => e.Id == id);
        //}
    }
}
