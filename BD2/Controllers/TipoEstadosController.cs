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
    public class TipoEstadosController : Controller
    {
        private readonly ProjectContext _context;

        public TipoEstadosController(ProjectContext context)
        {
            _context = context;    
        }

        // GET: TipoEstados
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoEstado.ToListAsync());
        }

        // GET: TipoEstados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoEstado = await _context.TipoEstado
                .SingleOrDefaultAsync(m => m.ID == id);
            if (tipoEstado == null)
            {
                return NotFound();
            }

            return View(tipoEstado);
        }

        // GET: TipoEstados/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoEstados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nombre,Descrip")] TipoEstado tipoEstado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoEstado);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tipoEstado);
        }

        // GET: TipoEstados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoEstado = await _context.TipoEstado.SingleOrDefaultAsync(m => m.ID == id);
            if (tipoEstado == null)
            {
                return NotFound();
            }
            return View(tipoEstado);
        }

        // POST: TipoEstados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nombre,Descrip")] TipoEstado tipoEstado)
        {
            if (id != tipoEstado.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoEstado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoEstadoExists(tipoEstado.ID))
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
            return View(tipoEstado);
        }

        // GET: TipoEstados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoEstado = await _context.TipoEstado
                .SingleOrDefaultAsync(m => m.ID == id);
            if (tipoEstado == null)
            {
                return NotFound();
            }

            return View(tipoEstado);
        }

        // POST: TipoEstados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoEstado = await _context.TipoEstado.SingleOrDefaultAsync(m => m.ID == id);
            _context.TipoEstado.Remove(tipoEstado);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool TipoEstadoExists(int id)
        {
            return _context.TipoEstado.Any(e => e.ID == id);
        }
    }
}
