using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FE.Services;
using FE.Models;

namespace FE.Controllers
{
    public class RolesController : Controller
    {
        private readonly IRolesServices rolesServices;

        public RolesController(IRolesServices rolesServices)
        {
            this.rolesServices = rolesServices;
        }



        // GET: Roles
        public async Task<IActionResult> Index()
        {
            return View(rolesServices.GetAll());
        }

        // GET: Roles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roles = rolesServices.GetOneById((int)id);
            if (roles == null)
            {
                return NotFound();
            }

            return View(roles);
        }

        // GET: Roles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRol,Rol")] Roles roles)
        {
            if (ModelState.IsValid)
            {
                rolesServices.Insert(roles);
                return RedirectToAction(nameof(Index));
            }
            return View(roles);
        }

        // GET: Roles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roles = rolesServices.GetOneById((int)id);
            if (roles == null)
            {
                return NotFound();
            }
            return View(roles);
        }

        // POST: Roles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRol,Rol")] Roles roles)
        {
            if (id != roles.IdRol)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    rolesServices.Update(roles);
                }
                catch (Exception ee)
                {
                    if (!RolesExists(roles.IdRol))
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
            return View(roles);
        }

        // GET: Roles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roles = rolesServices.GetOneById((int)id);
            if (roles == null)
            {
                return NotFound();
            }

            return View(roles);
        }

        // POST: Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roles = rolesServices.GetOneById(id);
            rolesServices.Delete(roles);
            return RedirectToAction(nameof(Index));
        }

        private bool RolesExists(int id)
        {
            return (rolesServices.GetOneById(id) != null);
        }
    }
}
