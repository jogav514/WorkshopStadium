using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stadium.Api.Data;
using Stadium.Shared.Entities;

namespace Stadium.Api.Controllers
{

    [ApiController]
    [Route("/api/Tickets")]
    public class TicketsController : ControllerBase
    {
        private readonly DataContext _context;

        public TicketsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Tickets.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult> Post(Ticket ticket)
        {
            _context.Add(ticket);
            await _context.SaveChangesAsync();
            return Ok(ticket);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var country = await _context.Tickets.FirstOrDefaultAsync(x => x.Id == id);
            if (country is null)
            {
                return NotFound();
            }

            return Ok(country);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Ticket ticket)
        {
            _context.Update(ticket);
            await _context.SaveChangesAsync();
            return Ok(ticket);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var afectedRows = await _context.Tickets
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();

            if (afectedRows == 0)
            {
                return NotFound();
            }

            return NoContent();
        }


    }

}

