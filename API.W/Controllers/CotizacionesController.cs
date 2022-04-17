using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.W.Models;

namespace API.W.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CotizacionesController : ControllerBase
    {
        private readonly NavtecCoreContext _context;

        public CotizacionesController(NavtecCoreContext context)
        {
            _context = context;
        }

        // GET: api/Cotizaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cotizaciones>>> GetCotizaciones()
        {
            return await _context.Cotizaciones.ToListAsync();
        }

        // GET: api/Cotizaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cotizaciones>> GetCotizaciones(int id)
        {
            var cotizaciones = await _context.Cotizaciones.FindAsync(id);

            if (cotizaciones == null)
            {
                return NotFound();
            }

            return cotizaciones;
        }

        // PUT: api/Cotizaciones/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCotizaciones(int id, Cotizaciones cotizaciones)
        {
            if (id != cotizaciones.IdCotizacion)
            {
                return BadRequest();
            }

            _context.Entry(cotizaciones).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CotizacionesExists(id))
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

        // POST: api/Cotizaciones
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Cotizaciones>> PostCotizaciones(Cotizaciones cotizaciones)
        {
            _context.Cotizaciones.Add(cotizaciones);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCotizaciones", new { id = cotizaciones.IdCotizacion }, cotizaciones);
        }

        // DELETE: api/Cotizaciones/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cotizaciones>> DeleteCotizaciones(int id)
        {
            var cotizaciones = await _context.Cotizaciones.FindAsync(id);
            if (cotizaciones == null)
            {
                return NotFound();
            }

            _context.Cotizaciones.Remove(cotizaciones);
            await _context.SaveChangesAsync();

            return cotizaciones;
        }

        private bool CotizacionesExists(int id)
        {
            return _context.Cotizaciones.Any(e => e.IdCotizacion == id);
        }
    }
}
