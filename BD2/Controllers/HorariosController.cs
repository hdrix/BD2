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
    public class HorariosController : Controller
    {
        private readonly ProjectContext _context;

        public HorariosController(ProjectContext context)
        {
            _context = context;    
        }

        // GET: Horarios
        public async Task<IActionResult> Index()
        {
            var projectContext = _context.Horario.Include(h => h.Estado);
            return View(await projectContext.ToListAsync());
        }

        // GET: Horarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horario = await _context.Horario
                .Include(h => h.Estado)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (horario == null)
            {
                return NotFound();
            }

            return View(horario);
        }

        // GET: Horarios/Create
        public IActionResult Create()
        {
            ViewData["EstadoID"] = new SelectList(_context.Estado, "ID", "ID");
            return View();
        }

        // POST: Horarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,inicial,final,EstadoID")] Horario horario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(horario);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["EstadoID"] = new SelectList(_context.Estado, "ID", "ID", horario.EstadoID);
            return View(horario);
        }

        // GET: Horarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horario = await _context.Horario.SingleOrDefaultAsync(m => m.ID == id);
            if (horario == null)
            {
                return NotFound();
            }
            ViewData["EstadoID"] = new SelectList(_context.Estado, "ID", "ID", horario.EstadoID);
            return View(horario);
        }

        // POST: Horarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,inicial,final,EstadoID")] Horario horario)
        {
            if (id != horario.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(horario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HorarioExists(horario.ID))
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
            ViewData["EstadoID"] = new SelectList(_context.Estado, "ID", "ID", horario.EstadoID);
            return View(horario);
        }

        // GET: Horarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horario = await _context.Horario
                .Include(h => h.Estado)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (horario == null)
            {
                return NotFound();
            }

            return View(horario);
        }

        // POST: Horarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var horario = await _context.Horario.SingleOrDefaultAsync(m => m.ID == id);
            _context.Horario.Remove(horario);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool HorarioExists(int id)
        {
            return _context.Horario.Any(e => e.ID == id);
        }
    }
}
