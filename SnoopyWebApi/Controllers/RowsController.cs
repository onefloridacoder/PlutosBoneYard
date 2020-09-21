﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SnoopyDomain;
using SnoopyRepository;

namespace SnoopyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RowsController : ControllerBase
    {
        private readonly SnoopyContext _context;

        public RowsController(SnoopyContext context)
        {
            _context = context;
        }

        // GET: api/Rows
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Row>>> GetRows()
        {
            return await _context.Rows.ToListAsync();
        }

        // GET: api/Rows/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Row>> GetRow(int id)
        {
            var row = await _context.Rows.FindAsync(id);

            if (row == null)
            {
                return NotFound();
            }

            return row;
        }

        // PUT: api/Rows/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRow(int id, Row row)
        {
            if (id != row.Id)
            {
                return BadRequest();
            }

            _context.Entry(row).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RowExists(id))
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

        // POST: api/Rows
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Row>> PostRow(Row row)
        {
            _context.Rows.Add(row);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRow", new { id = row.Id }, row);
        }

        //[HttpPost]
        //public async Task<ActionResult<Row>> PostRows(Row[] rows)
        //{
        //    _context.Rows.Add(rows[0]);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetRow", new { id = rows[0].Id }, rows[0]);
        //}

        // DELETE: api/Rows/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Row>> DeleteRow(int id)
        {
            var row = await _context.Rows.FindAsync(id);
            if (row == null)
            {
                return NotFound();
            }

            _context.Rows.Remove(row);
            await _context.SaveChangesAsync();

            return row;
        }

        private bool RowExists(int id)
        {
            return _context.Rows.Any(e => e.Id == id);
        }
    }
}
