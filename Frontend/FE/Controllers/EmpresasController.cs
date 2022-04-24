using FE.Models;
using FE.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Threading.Tasks;

namespace FE.Controllers
{
    public class EmpresasController : Controller
    {
        private readonly IClientesServices clientesServices;
        private readonly IEmpresasServices empresasServices;

        public EmpresasController(IClientesServices clientesServices, IEmpresasServices empresasServices)
        {
            this.clientesServices = clientesServices;
            this.empresasServices = empresasServices;
        }


        // GET: Empresas
        public async Task<IActionResult> Index()
        {

            return View(await empresasServices.GetAllAsync());
        }

        // GET: Empresas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresas = await empresasServices.GetOneByIdAsync((int)id);
            if (empresas == null)
            {
                return NotFound();
            }

            return View(empresas);
        }

        // GET: Empresas/Create
        public IActionResult Create()
        {
            ViewData["IdCliente"] = new SelectList(clientesServices.GetAll(), "IdCliente", "CorreoCliente");
            return View();
        }

        // POST: Empresas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEmpresa,IdCliente,NombreEmpresa,TelefonoEmpresa,CedulaJuridica")] Empresas empresas)
        {
            if (ModelState.IsValid)
            {
                empresasServices.Insert(empresas);
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCliente"] = new SelectList(clientesServices.GetAll(), "IdCliente", "CorreoCliente", empresas.IdCliente);
            return View(empresas);
        }

        // GET: Empresas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresas = empresasServices.GetOneById((int)id);
            if (empresas == null)
            {
                return NotFound();
            }
            ViewData["IdCliente"] = new SelectList(clientesServices.GetAll(), "IdCliente", "CorreoCliente", empresas.IdCliente);
            return View(empresas);
        }

        // POST: Empresas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEmpresa,IdCliente,NombreEmpresa,TelefonoEmpresa,CedulaJuridica")] Empresas empresas)
        {
            if (id != empresas.IdEmpresa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    empresasServices.Update(empresas);
                }
                catch (Exception ee)
                {
                    if (!EmpresasExists(empresas.IdEmpresa))
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
            ViewData["IdCliente"] = new SelectList(clientesServices.GetAll(), "IdCliente", "CorreoCliente", empresas.IdCliente);
            return View(empresas);
        }

        // GET: Empresas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresas = empresasServices.GetOneByIdAsync((int)id);
            if (empresas == null)
            {
                return NotFound();
            }

            return View(empresas);
        }

        // POST: Empresas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empresas = empresasServices.GetOneById((int)id);
            empresasServices.Update(empresas);
            return RedirectToAction(nameof(Index));
        }

        private bool EmpresasExists(int id)
        {
            return ((empresasServices.GetOneById((int)id) != null));
        }
    }
}
