using FE.Identity.Models;
using FE.Identity.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FE.Identity.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClientesServices clientesServices;

        public ClientesController(IClientesServices _clientesServices)
        {
            this.clientesServices = _clientesServices;
        }


        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            return View(clientesServices.GetAll());
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientes = clientesServices.GetOneById((int)id);
            if (clientes == null)
            {
                return NotFound();
            }

            return View(clientes);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCliente,NombreCliente,CorreoCliente,TelefonoCliente")] Clientes clientes)
        {
            if (ModelState.IsValid)
            {
                clientesServices.Insert(clientes);
                return RedirectToAction(nameof(Index));
            }
            return View(clientes);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientes = clientesServices.GetOneById((int)id);
            if (clientes == null)
            {
                return NotFound();
            }
            return View(clientes);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCliente,NombreCliente,CorreoCliente,TelefonoCliente")] Clientes clientes)
        {
            if (id != clientes.IdCliente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    clientesServices.Update(clientes);
                }
                catch (Exception ee)
                {
                    if (!ClientesExists(clientes.IdCliente))
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
            return View(clientes);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientes = clientesServices.GetOneById((int)id);
            if (clientes == null)
            {
                return NotFound();
            }

            return View(clientes);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clientes = clientesServices.GetOneById(id);
            clientesServices.Delete(clientes);
            return RedirectToAction(nameof(Index));
        }

        private bool ClientesExists(int id)
        {
            return (clientesServices.GetOneById(id) != null);
        }
    }
}
