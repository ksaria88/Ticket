using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AtencionCliente.Data;
using AtencionCliente.Models;

namespace AtencionCliente.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColaController : ControllerBase
    {
        private readonly AtencionClienteContext _context;

        public ColaController(AtencionClienteContext context)
        {
            _context = context;
        }

        // GET: api/Cola
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cola>>> GetCola()
        {
          if (_context.Cola == null)
          {
              return NotFound();
          }
            return await _context.Cola.ToListAsync();
        }

        // GET: api/Cola/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cola>> GetCola(int id)
        {
          if (_context.Cola == null)
          {
              return NotFound();
          }
            var cola = await _context.Cola.FindAsync(id);

            if (cola == null)
            {
                return NotFound();
            }

            return cola;
        }

        // PUT: api/Cola/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCola(int id, Cola cola)
        {
            if (id != cola.IdCola)
            {
                return BadRequest();
            }

            _context.Entry(cola).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColaExists(id))
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

        // POST: api/Cola
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cola>> PostCola(Cola cola)
        {
          if (_context.Cola == null)
          {
              return Problem("Entity set 'AtencionClienteContext.Cola'  is null.");
          }
            _context.Cola.Add(cola);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCola", new { id = cola.IdCola }, cola);
        }

        // DELETE: api/Cola/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCola(int id)
        {
            if (_context.Cola == null)
            {
                return NotFound();
            }
            var cola = await _context.Cola.FindAsync(id);
            if (cola == null)
            {
                return NotFound();
            }

            _context.Cola.Remove(cola);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ColaExists(int id)
        {
            return (_context.Cola?.Any(e => e.IdCola == id)).GetValueOrDefault();
        }
    }
}
