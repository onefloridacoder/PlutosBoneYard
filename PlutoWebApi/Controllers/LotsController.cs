using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlutoDomain;
using PlutoRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlutoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LotsController : ControllerBase
    {
        private readonly PlutoContext _context;

        public LotsController(PlutoContext context)
        {
            _context = context;
        }

        // GET: api/Lots
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lot>>> GetLots()
        {
            return await _context.Lots.ToListAsync();
        }

        // GET: api/Lots/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lot>> GetLot(int id)
        {
            var lot = await _context.Lots.FindAsync(id);

            if (lot == null)
            {
                return NotFound();
            }

            return lot;
        }

        // PUT: api/Lots/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLot(int id, Lot lot)
        {
            if (id != lot.Id)
            {
                return BadRequest();
            }

            _context.Entry(lot).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LotExists(id))
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

        // POST: api/Lots
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Lot>> PostLot(Lot lot)
        {
            _context.Lots.Add(lot);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLot", new { id = lot.Id }, lot);
        }

        // DELETE: api/Lots/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Lot>> DeleteLot(int id)
        {
            var lot = await _context.Lots.FindAsync(id);
            if (lot == null)
            {
                return NotFound();
            }

            _context.Lots.Remove(lot);
            await _context.SaveChangesAsync();

            return lot;
        }

        private bool LotExists(int id)
        {
            return _context.Lots.Any(e => e.Id == id);
        }
    }
}
