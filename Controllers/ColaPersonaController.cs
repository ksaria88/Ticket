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
    public class ColaPersonaController : ControllerBase
    {
        private readonly AtencionClienteContext _context;

        public ColaPersonaController(AtencionClienteContext context)
        {
            _context = context;
        }

        // GET: api/ColaPersona
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ColaPersona>>> GetColaPersona()
        {
          if (_context.ColaPersona == null)
          {
              return NotFound();
          }
            return await _context.ColaPersona.ToListAsync();
        }

        // GET: api/ColaPersona/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ColaPersona>> GetColaPersona(int id)
        {
          if (_context.ColaPersona == null)
          {
              return NotFound();
          }
            var colaPersona = await _context.ColaPersona.FindAsync(id);

            if (colaPersona == null)
            {
                return NotFound();
            }

            return colaPersona;
        }

        // PUT: api/ColaPersona/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutColaPersona(int id, ColaPersona colaPersona)
        {
            if (id != colaPersona.IdColaPersona)
            {
                return BadRequest();
            }

            _context.Entry(colaPersona).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColaPersonaExists(id))
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

        // POST: api/ColaPersona
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ColaPersona>> PostColaPersona(ColaPersona colaPersona)
        {
          if (_context.ColaPersona == null)
          {
              return Problem("Entity set 'AtencionClienteContext.ColaPersona'  is null.");
          }
            _context.ColaPersona.Add(colaPersona);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetColaPersona", new { id = colaPersona.IdColaPersona }, colaPersona);
        }

        // DELETE: api/ColaPersona/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteColaPersona(int id)
        {
            if (_context.ColaPersona == null)
            {
                return NotFound();
            }
            var colaPersona = await _context.ColaPersona.FindAsync(id);
            if (colaPersona == null)
            {
                return NotFound();
            }

            _context.ColaPersona.Remove(colaPersona);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ColaPersonaExists(int id)
        {
            return (_context.ColaPersona?.Any(e => e.IdColaPersona == id)).GetValueOrDefault();
        }
    }
}
