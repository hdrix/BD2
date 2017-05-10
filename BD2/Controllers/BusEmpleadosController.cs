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
    public class BusEmpleadosController : Controller
    {
        private readonly ProjectContext _context;

        public BusEmpleadosController(ProjectContext context)
        {
            _context = context;    
        }

        // GET: BusEmpleados
        public async Task<IActionResult> Index()
        {
            var projectContext = _context.BusEmpleado.Include(b => b.Bus).Include(b => b.Empleado);
            return View(await projectContext.ToListAsync());
        }

        // GET: BusEmpleados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var busEmpleado = await _context.BusEmpleado
                .Include(b => b.Bus)
                .Include(b => b.Empleado)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (busEmpleado == null)
            {
                return NotFound();
            }

            return View(busEmpleado);
        }

        // GET: BusEmpleados/Create
        public IActionResult Create()
        {
            ViewData["BusID"] = new SelectList(_context.Bus, "ID", "ID");
            ViewData["EmpleadoID"] = new SelectList(_context.Empleados, "ID", "ID");
            return View();
        }

        // POST: BusEmpleados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,BusID,EmpleadoID")] BusEmpleado busEmpleado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(busEmpleado);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["BusID"] = new SelectList(_context.Bus, "ID", "ID", busEmpleado.BusID);
            ViewData["EmpleadoID"] = new SelectList(_context.Empleados, "ID", "ID", busEmpleado.EmpleadoID);
            return View(busEmpleado);
        }

        // GET: BusEmpleados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var busEmpleado = await _context.BusEmpleado.SingleOrDefaultAsync(m => m.ID == id);
            if (busEmpleado == null)
            {
                return NotFound();
            }
            ViewData["BusID"] = new SelectList(_context.Bus, "ID", "ID", busEmpleado.BusID);
            ViewData["EmpleadoID"] = new SelectList(_context.Empleados, "ID", "ID", busEmpleado.EmpleadoID);
            return View(busEmpleado);
        }

        // POST: BusEmpleados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,BusID,EmpleadoID")] BusEmpleado busEmpleado)
        {
            if (id != busEmpleado.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(busEmpleado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BusEmpleadoExists(busEmpleado.ID))
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
            ViewData["BusID"] = new SelectList(_context.Bus, "ID", "ID", busEmpleado.BusID);
            ViewData["EmpleadoID"] = new SelectList(_context.Empleados, "ID", "ID", busEmpleado.EmpleadoID);
            return View(busEmpleado);
        }

        // GET: BusEmpleados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var busEmpleado = await _context.BusEmpleado
                .Include(b => b.Bus)
                .Include(b => b.Empleado)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (busEmpleado == null)
            {
                return NotFound();
            }

            return View(busEmpleado);
        }

        // POST: BusEmpleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var busEmpleado = await _context.BusEmpleado.SingleOrDefaultAsync(m => m.ID == id);
            _context.BusEmpleado.Remove(busEmpleado);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool BusEmpleadoExists(int id)
        {
            return _context.BusEmpleado.Any(e => e.ID == id);
        }
    }
}
