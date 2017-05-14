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
    public class PasswordEmpleadosController : Controller
    {
        private readonly ProjectContext _context;

        public PasswordEmpleadosController(ProjectContext context)
        {
            _context = context;    
        }

        // GET: PasswordEmpleados
        public async Task<IActionResult> Index()
        {
            var projectContext = _context.PasswordEmpleados.Include(p => p.Empleado).Include(p => p.Passwords);
            return View(await projectContext.ToListAsync());
        }

        // GET: PasswordEmpleados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passwordEmpleados = await _context.PasswordEmpleados
                .Include(p => p.Empleado)
                .Include(p => p.Passwords)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (passwordEmpleados == null)
            {
                return NotFound();
            }

            return View(passwordEmpleados);
        }

        // GET: PasswordEmpleados/Create
        public IActionResult Create()
        {
            ViewData["EmpleadoID"] = new SelectList(_context.Empleados, "ID", "ID");
            ViewData["PasswordsID"] = new SelectList(_context.Passwords, "ID", "ID");
            return View();
        }

        // POST: PasswordEmpleados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,PasswordsID,EmpleadoID,enable,fecha_Modificado")] PasswordEmpleados passwordEmpleados)
        {
            if (ModelState.IsValid)
            {
                _context.Add(passwordEmpleados);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["EmpleadoID"] = new SelectList(_context.Empleados, "ID", "ID", passwordEmpleados.EmpleadoID);
            ViewData["PasswordsID"] = new SelectList(_context.Passwords, "ID", "ID", passwordEmpleados.PasswordsID);
            return View(passwordEmpleados);
        }

        // GET: PasswordEmpleados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passwordEmpleados = await _context.PasswordEmpleados.SingleOrDefaultAsync(m => m.ID == id);
            if (passwordEmpleados == null)
            {
                return NotFound();
            }
            ViewData["EmpleadoID"] = new SelectList(_context.Empleados, "ID", "ID", passwordEmpleados.EmpleadoID);
            ViewData["PasswordsID"] = new SelectList(_context.Passwords, "ID", "ID", passwordEmpleados.PasswordsID);
            return View(passwordEmpleados);
        }

        // POST: PasswordEmpleados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,PasswordsID,EmpleadoID,enable,fecha_Modificado")] PasswordEmpleados passwordEmpleados)
        {
            if (id != passwordEmpleados.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(passwordEmpleados);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PasswordEmpleadosExists(passwordEmpleados.ID))
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
            ViewData["EmpleadoID"] = new SelectList(_context.Empleados, "ID", "ID", passwordEmpleados.EmpleadoID);
            ViewData["PasswordsID"] = new SelectList(_context.Passwords, "ID", "ID", passwordEmpleados.PasswordsID);
            return View(passwordEmpleados);
        }

        // GET: PasswordEmpleados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passwordEmpleados = await _context.PasswordEmpleados
                .Include(p => p.Empleado)
                .Include(p => p.Passwords)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (passwordEmpleados == null)
            {
                return NotFound();
            }

            return View(passwordEmpleados);
        }

        // POST: PasswordEmpleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var passwordEmpleados = await _context.PasswordEmpleados.SingleOrDefaultAsync(m => m.ID == id);
            _context.PasswordEmpleados.Remove(passwordEmpleados);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool PasswordEmpleadosExists(int id)
        {
            return _context.PasswordEmpleados.Any(e => e.ID == id);
        }
    }
}
