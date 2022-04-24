using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FE.Identity.Models;
using FE.Identity.Services;

namespace FE.Identity.Controllers
{
    public class ServiciosController : Controller
    {
        private readonly IServiciosServices serviciosServices;

        public ServiciosController(IServiciosServices serviciosServices)
        {
            this.serviciosServices = serviciosServices;
        }



        // GET: Servicios
        public async Task<IActionResult> Index()
        {
            return View(serviciosServices.GetAll());
        }

        // GET: Servicios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servicios = serviciosServices.GetOneById((int)id);
            if (servicios == null)
            {
                return NotFound();
            }

            return View(servicios);
        }

        // GET: Servicios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Servicios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdServicio,DescripcionServicio")] Servicios servicios)
        {
            if (ModelState.IsValid)
            {
                serviciosServices.Insert(servicios);
                return RedirectToAction(nameof(Index));
            }
            return View(servicios);
        }

        // GET: Servicios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servicios =  serviciosServices.GetOneById((int)id);
            if (servicios == null)
            {
                return NotFound();
            }
            return View(servicios);
        }

        // POST: Servicios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdServicio,DescripcionServicio")] Servicios servicios)
        {
            if (id != servicios.IdServicio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    serviciosServices.Update(servicios);
                }
                catch (Exception ee)
                {
                    if (!ServiciosExists(servicios.IdServicio))
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
            return View(servicios);
        }

        // GET: Servicios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servicios = serviciosServices.GetOneById((int)id);
            if (servicios == null)
            {
                return NotFound();
            }

            return View(servicios);
        }

        // POST: Servicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var servicios = serviciosServices.GetOneById(id);
            serviciosServices.Delete(servicios);
            return RedirectToAction(nameof(Index));
        }

        private bool ServiciosExists(int id)
        {
            return (serviciosServices.GetOneById(id) != null);
        }
    }
}
