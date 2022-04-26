using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using FE.Identity.Models;
using FE.Identity.Services;

namespace FE.Identity.Controllers
    //Falta agregar el connection al server del backend
{
    public class CotizacionesController : Controller
    {
        private readonly IServiciosServices serviciosServices;
        private readonly ICotizacionesServices cotizacionesServices;

        public CotizacionesController(IServiciosServices _serviciosServices, ICotizacionesServices _cotizacionesServices)
        {
            this.serviciosServices = _serviciosServices;
            this.cotizacionesServices = _cotizacionesServices;
        }



        // GET: Cotizaciones
        public async Task<IActionResult> Index()
        {
            return View(await cotizacionesServices.GetAllAsync());
        }

        // GET: Cotizaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cotizaciones = await cotizacionesServices.GetOneByIdAsync((int)id);
            if (cotizaciones == null)
            {
                return NotFound();
            }

            return View(cotizaciones);
        }

        // GET: Cotizaciones/Create
        public IActionResult Create()
        {
            ViewData["IdServicio"] = new SelectList(serviciosServices.GetAll(), "IdServicio", "DescripcionServicio");
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
                cotizacionesServices.Insert(cotizaciones);
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdServicio"] = new SelectList(serviciosServices.GetAll(), "IdServicio", "DescripcionServicio", cotizaciones.IdServicio);
            return View(cotizaciones);
        }

        // GET: Cotizaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cotizaciones = cotizacionesServices.GetOneById((int)id);
            if (cotizaciones == null)
            {
                return NotFound();
            }
            ViewData["IdServicio"] = new SelectList(serviciosServices.GetAll(), "IdServicio", "DescripcionServicio", cotizaciones.IdServicio);
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
                    cotizacionesServices.Update(cotizaciones);
                }
                catch (Exception ee)
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
            ViewData["IdServicio"] = new SelectList(serviciosServices.GetAll(), "IdServicio", "DescripcionServicio", cotizaciones.IdServicio);
            return View(cotizaciones);
        }

        // GET: Cotizaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cotizaciones = cotizacionesServices.GetOneByIdAsync((int)id);
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
            var cotizaciones =  cotizacionesServices.GetOneById((int)id);
            cotizacionesServices.Update(cotizaciones);
            return RedirectToAction(nameof(Index));
        }

        private bool CotizacionesExists(int id)
        {
            return ((cotizacionesServices.GetOneById((int)id) != null));
        }
    }
}
