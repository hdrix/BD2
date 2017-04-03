using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BD2.CL;
using BD2.Model;

namespace BD2.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly ProjectContext _context;

        public EmpleadosController(ProjectContext context)
        {
            _context = context;    
        }

        // GET: Empleados
        public async Task<IActionResult> Index()
        {
            var projectContext = _context.Empleados.Include(e => e.TipoEmpleado);
            return View(await projectContext.ToListAsync());
        }

        // GET: Empleados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados
                .Include(e => e.TipoEmpleado)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // GET: Empleados/Create
        public IActionResult Create()
        {
            ViewData["TipoEmpleadoID"] = new SelectList(_context.TipoEmpleados, "ID", "ID");
            return View();
        }

        // POST: Empleados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TipoEmpleadoID,Nombre,Apellido,Edad")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empleado);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["TipoEmpleadoID"] = new SelectList(_context.TipoEmpleados, "ID", "ID", empleado.TipoEmpleadoID);
            return View(empleado);
        }

        // GET: Empleados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados.SingleOrDefaultAsync(m => m.ID == id);
            if (empleado == null)
            {
                return NotFound();
            }
            ViewData["TipoEmpleadoID"] = new SelectList(_context.TipoEmpleados, "ID", "ID", empleado.TipoEmpleadoID);
            return View(empleado);
        }

        // POST: Empleados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,TipoEmpleadoID,Nombre,Apellido,Edad")] Empleado empleado)
        {
            if (id != empleado.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empleado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadoExists(empleado.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["TipoEmpleadoID"] = new SelectList(_context.TipoEmpleados, "ID", "ID", empleado.TipoEmpleadoID);
            return View(empleado);
        }

        // GET: Empleados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados
                .Include(e => e.TipoEmpleado)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empleado = await _context.Empleados.SingleOrDefaultAsync(m => m.ID == id);
            _context.Empleados.Remove(empleado);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool EmpleadoExists(int id)
        {
            return _context.Empleados.Any(e => e.ID == id);
        }
    }
}
