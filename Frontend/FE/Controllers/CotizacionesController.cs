using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FE.Models;

namespace FE.Controllers
    //Falta agregar el connection al server del backend
{
    public class CotizacionesController : Controller
    {
        private readonly NavtecCoreContext _context;

        public CotizacionesController(NavtecCoreContext context)
        {
            _context = context;
        }

        // GET: Cotizaciones
        public async Task<IActionResult> Index()
        {
            var navtecCoreContext = _context.Cotizaciones.Include(c => c.IdServicioNavigation);
            return View(await navtecCoreContext.ToListAsync());
        }

        // GET: Cotizaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cotizaciones = await _context.Cotizaciones
                .Include(c => c.IdServicioNavigation)
                .FirstOrDefaultAsync(m => m.IdCotizacion == id);
            if (cotizaciones == null)
            {
                return NotFound();
            }

            return View(cotizaciones);
        }

        // GET: Cotizaciones/Create
        public IActionResult Create()
        {
            ViewData["IdServicio"] = new SelectList(_context.Servicios, "IdServicio", "DescripcionServicio");
            return View();
        }

        // POST: Cotizaciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCotizacion,IdServicio,FechaCotizacion,NombreCliente,PrecioCotizacion")] Cotizaciones cotizaciones)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cotizaciones);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdServicio"] = new SelectList(_context.Servicios, "IdServicio", "DescripcionServicio", cotizaciones.IdServicio);
            return View(cotizaciones);
        }

        // GET: Cotizaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cotizaciones = await _context.Cotizaciones.FindAsync(id);
            if (cotizaciones == null)
            {
                return NotFound();
            }
            ViewData["IdServicio"] = new SelectList(_context.Servicios, "IdServicio", "DescripcionServicio", cotizaciones.IdServicio);
            return View(cotizaciones);
        }

        // POST: Cotizaciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCotizacion,IdServicio,FechaCotizacion,NombreCliente,PrecioCotizacion")] Cotizaciones cotizaciones)
        {
            if (id != cotizaciones.IdCotizacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cotizaciones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CotizacionesExists(cotizaciones.IdCotizacion))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdServicio"] = new SelectList(_context.Servicios, "IdServicio", "DescripcionServicio", cotizaciones.IdServicio);
            return View(cotizaciones);
        }

        // GET: Cotizaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cotizaciones = await _context.Cotizaciones
                .Include(c => c.IdServicioNavigation)
                .FirstOrDefaultAsync(m => m.IdCotizacion == id);
            if (cotizaciones == null)
            {
                return NotFound();
            }

            return View(cotizaciones);
        }

        // POST: Cotizaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cotizaciones = await _context.Cotizaciones.FindAsync(id);
            _context.Cotizaciones.Remove(cotizaciones);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CotizacionesExists(int id)
        {
            return _context.Cotizaciones.Any(e => e.IdCotizacion == id);
        }
    }
}
