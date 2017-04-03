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
    public class TipoEmpleadosController : Controller
    {
        private readonly ProjectContext _context;

        public TipoEmpleadosController(ProjectContext context)
        {
            _context = context;    
        }

        // GET: TipoEmpleados
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoEmpleados.ToListAsync());
        }

        // GET: TipoEmpleados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoEmpleado = await _context.TipoEmpleados
                .SingleOrDefaultAsync(m => m.ID == id);
            if (tipoEmpleado == null)
            {
                return NotFound();
            }

            return View(tipoEmpleado);
        }

        // GET: TipoEmpleados/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoEmpleados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nombre,Descrip")] TipoEmpleado tipoEmpleado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoEmpleado);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tipoEmpleado);
        }

        // GET: TipoEmpleados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoEmpleado = await _context.TipoEmpleados.SingleOrDefaultAsync(m => m.ID == id);
            if (tipoEmpleado == null)
            {
                return NotFound();
            }
            return View(tipoEmpleado);
        }

        // POST: TipoEmpleados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nombre,Descrip")] TipoEmpleado tipoEmpleado)
        {
            if (id != tipoEmpleado.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoEmpleado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoEmpleadoExists(tipoEmpleado.ID))
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
            return View(tipoEmpleado);
        }

        // GET: TipoEmpleados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoEmpleado = await _context.TipoEmpleados
                .SingleOrDefaultAsync(m => m.ID == id);
            if (tipoEmpleado == null)
            {
                return NotFound();
            }

            return View(tipoEmpleado);
        }

        // POST: TipoEmpleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoEmpleado = await _context.TipoEmpleados.SingleOrDefaultAsync(m => m.ID == id);
            _context.TipoEmpleados.Remove(tipoEmpleado);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool TipoEmpleadoExists(int id)
        {
            return _context.TipoEmpleados.Any(e => e.ID == id);
        }
    }
}
