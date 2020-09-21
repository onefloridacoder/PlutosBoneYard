using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SnoopyDomain;
using SnoopyRepository;

namespace SnoopyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThemeParksController : ControllerBase
    {
        private readonly SnoopyContext _context;

        public ThemeParksController(SnoopyContext context)
        {
            _context = context;
        }

        // GET: api/ThemeParks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ThemePark>>> GetThemeParks()
        {
            return await _context.ThemeParks.ToListAsync();
        }

        // GET: api/ThemeParks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ThemePark>> GetThemePark(int id)
        {
            var themePark = await _context.ThemeParks.FindAsync(id);

            if (themePark == null)
            {
                return NotFound();
            }

            return themePark;
        }

        // PUT: api/ThemeParks/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutThemePark(int id, ThemePark themePark)
        {
            if (id != themePark.Id)
            {
                return BadRequest();
            }

            _context.Entry(themePark).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThemeParkExists(id))
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

        // POST: api/ThemeParks
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ThemePark>> PostThemePark(ThemePark themePark)
        {
            _context.ThemeParks.Add(themePark);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetThemePark", new { id = themePark.Id }, themePark);
        }

        // DELETE: api/ThemeParks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ThemePark>> DeleteThemePark(int id)
        {
            var themePark = await _context.ThemeParks.FindAsync(id);
            if (themePark == null)
            {
                return NotFound();
            }

            _context.ThemeParks.Remove(themePark);
            await _context.SaveChangesAsync();

            return themePark;
        }

        private bool ThemeParkExists(int id)
        {
            return _context.ThemeParks.Any(e => e.Id == id);
        }
    }
}
