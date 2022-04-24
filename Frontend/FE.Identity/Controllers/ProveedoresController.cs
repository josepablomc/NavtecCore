using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FE.Identity.Models;
using FE.Identity.Services;
using System;

namespace FE.Identity.Controllers
{
    public class ProveedoresController : Controller
    {
        private readonly IProveedoresServices proveedoresServices;

        public ProveedoresController(IProveedoresServices proveedorServices)
        {
            this.proveedoresServices = proveedorServices;
        }


        // GET: Proveedores
        public async Task<IActionResult> Index()
        {
            return View(proveedoresServices.GetAll());
        }

        // GET: Proveedores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proveedores = proveedoresServices.GetOneById((int)id);
            if (proveedores == null)
            {
                return NotFound();
            }

            return View(proveedores);
        }

        // GET: Proveedores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Proveedores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProveedor,NombreProveedor,TelefonoProveedor,DescripcionProveedor")] Proveedores proveedores)
        {
            if (ModelState.IsValid)
            {
                proveedoresServices.Insert(proveedores);
                return RedirectToAction(nameof(Index));
            }
            return View(proveedores);
        }

        // GET: Proveedores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proveedores = proveedoresServices.GetOneById((int)id);
            if (proveedores == null)
            {
                return NotFound();
            }
            return View(proveedores);
        }

        // POST: Proveedores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProveedor,NombreProveedor,TelefonoProveedor,DescripcionProveedor")] Proveedores proveedores)
        {
            if (id != proveedores.IdProveedor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    proveedoresServices.Update(proveedores);
                }
                catch (Exception ee)
                {
                    if (!ProveedoresExists(proveedores.IdProveedor))
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
            return View(proveedores);
        }

        // GET: Proveedores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proveedores = proveedoresServices.GetOneById((int)id);
            if (proveedores == null)
            {
                return NotFound();
            }

            return View(proveedores);
        }

        // POST: Proveedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var proveedores = proveedoresServices.GetOneById(id);
            proveedoresServices.Delete(proveedores);
            return RedirectToAction(nameof(Index));
        }

        private bool ProveedoresExists(int id)
        {
            return (proveedoresServices.GetOneById(id) != null);
        }
    }
}
