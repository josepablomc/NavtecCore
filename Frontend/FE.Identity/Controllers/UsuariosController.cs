using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using FE.Identity.Services;
using FE.Identity.Models;

namespace FE.Identity.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IRolesServices rolesServices;
        private readonly IUsuariosServices usuariosServices;

        public UsuariosController(IRolesServices _rolesServices, IUsuariosServices _usuariosServices)
        {
            this.rolesServices = _rolesServices;
            this.usuariosServices = _usuariosServices;
        }



        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            return View(await usuariosServices.GetAllAsync());
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarios = await usuariosServices.GetOneByIdAsync((int)id);
            if (usuarios == null)
            {
                return NotFound();
            }

            return View(usuarios);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            ViewData["IdRol"] = new SelectList(rolesServices.GetAll(), "IdRol", "Rol");
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUsuario,IdRol,NombreCompleto,CorreoUsuario,ClaveUsuario")] Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                usuariosServices.Insert(usuarios);
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdRol"] = new SelectList(rolesServices.GetAll(), "IdRol", "Rol", usuarios.IdRol);
            return View(usuarios);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarios = usuariosServices.GetOneById((int)id);
            if (usuarios == null)
            {
                return NotFound();
            }
            ViewData["IdRol"] = new SelectList(rolesServices.GetAll(), "IdRol", "Rol", usuarios.IdRol);
            return View(usuarios);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUsuario,IdRol,NombreCompleto,CorreoUsuario,ClaveUsuario")] Usuarios usuarios)
        {
            if (id != usuarios.IdUsuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    usuariosServices.Update(usuarios);
                }
                catch (Exception ee)
                {
                    if (!UsuariosExists(usuarios.IdUsuario))
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
            ViewData["IdRol"] = new SelectList(rolesServices.GetAll(), "IdRol", "Rol", usuarios.IdRol);
            return View(usuarios);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarios = usuariosServices.GetOneByIdAsync((int)id);
            if (usuarios == null)
            {
                return NotFound();
            }

            return View(usuarios);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuarios = usuariosServices.GetOneById((int)id);
            usuariosServices.Update(usuarios);
            return RedirectToAction(nameof(Index));
        }

        private bool UsuariosExists(int id)
        {
            return ((usuariosServices.GetOneById((int)id) != null));
        }
    }
}
