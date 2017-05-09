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
    public class EstadosController : Controller
    {
        private readonly ProjectContext _context;

        public EstadosController(ProjectContext context)
        {
            _context = context;    
        }

        // GET: Estados
        public async Task<IActionResult> Index()
        {
            var projectContext = _context.Estado.Include(e => e.TipoEstado);
            return View(await projectContext.ToListAsync());
        }

        // GET: Estados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estado = await _context.Estado
                .Include(e => e.TipoEstado)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (estado == null)
            {
                return NotFound();
            }

            return View(estado);
        }

        // GET: Estados/Create
        public IActionResult Create()
        {
            ViewData["TipoEstadoID"] = new SelectList(_context.TipoEstado, "ID", "ID");
            return View();
        }

        // POST: Estados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Descrip,Nombre,TipoEstadoID")] Estado estado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estado);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["TipoEstadoID"] = new SelectList(_context.TipoEstado, "ID", "ID", estado.TipoEstadoID);
            return View(estado);
        }

        // GET: Estados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estado = await _context.Estado.SingleOrDefaultAsync(m => m.ID == id);
            if (estado == null)
            {
                return NotFound();
            }
            ViewData["TipoEstadoID"] = new SelectList(_context.TipoEstado, "ID", "ID", estado.TipoEstadoID);
            return View(estado);
        }

        // POST: Estados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Descrip,Nombre,TipoEstadoID")] Estado estado)
        {
            if (id != estado.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstadoExists(estado.ID))
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
            ViewData["TipoEstadoID"] = new SelectList(_context.TipoEstado, "ID", "ID", estado.TipoEstadoID);
            return View(estado);
        }

        // GET: Estados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estado = await _context.Estado
                .Include(e => e.TipoEstado)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (estado == null)
            {
                return NotFound();
            }

            return View(estado);
        }

        // POST: Estados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estado = await _context.Estado.SingleOrDefaultAsync(m => m.ID == id);
            _context.Estado.Remove(estado);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool EstadoExists(int id)
        {
            return _context.Estado.Any(e => e.ID == id);
        }
    }
}
