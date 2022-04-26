using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using FE.Identity.Models;
using FE.Identity.Services;

namespace FE.Identity.Controllers
{
    public class GastosController : Controller
    {
        private readonly IGastosServices gastosServices;

        public GastosController(IGastosServices gastosServices)
        {
            this.gastosServices = gastosServices;
        }


        // GET: Gastos
        public async Task<IActionResult> Index()
        {
            return View(gastosServices.GetAll());
        }

        // GET: Gastos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gastos = gastosServices.GetOneById((int)id);
            if (gastos == null)
            {
                return NotFound();
            }

            return View(gastos);
        }

        // GET: Gastos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gastos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdGasto,DescripcionGasto,FechaGasto,MontoGasto")] Gastos gastos)
        {
            if (ModelState.IsValid)
            {
                gastosServices.Insert(gastos);
                return RedirectToAction(nameof(Index));
            }
            return View(gastos);
        }

        // GET: Gastos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gastos = gastosServices.GetOneById((int)id);
            if (gastos == null)
            {
                return NotFound();
            }
            return View(gastos);
        }

        // POST: Gastos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdGasto,DescripcionGasto,FechaGasto,MontoGasto")] Gastos gastos)
        {
            if (id != gastos.IdGasto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    gastosServices.Update(gastos);
                }
                catch (Exception ee)
                {
                    if (!GastosExists(gastos.IdGasto))
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
            return View(gastos);
        }

        // GET: Gastos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gastos = gastosServices.GetOneById((int)id);
            if (gastos == null)
            {
                return NotFound();
            }

            return View(gastos);
        }

        // POST: Gastos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gastos = gastosServices.GetOneById(id);
            gastosServices.Delete(gastos);
            return RedirectToAction(nameof(Index));
        }

        private bool GastosExists(int id)
        {
            return (gastosServices.GetOneById(id) != null);
        }
    }
}
