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
    public class EncomiendaBusesController : Controller
    {
        private readonly ProjectContext _context;

        public EncomiendaBusesController(ProjectContext context)
        {
            _context = context;    
        }

        // GET: EncomiendaBuses
        public async Task<IActionResult> Index()
        {
            var projectContext = _context.EncomiendaBus.Include(e => e.Bus).Include(e => e.Encomienda).Include(e => e.Estado);
            return View(await projectContext.ToListAsync());
        }

        // GET: EncomiendaBuses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var encomiendaBus = await _context.EncomiendaBus
                .Include(e => e.Bus)
                .Include(e => e.Encomienda)
                .Include(e => e.Estado)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (encomiendaBus == null)
            {
                return NotFound();
            }

            return View(encomiendaBus);
        }

        // GET: EncomiendaBuses/Create
        public IActionResult Create()
        {
            ViewData["BusID"] = new SelectList(_context.Bus, "ID", "ID");
            ViewData["EncomiendaID"] = new SelectList(_context.Encomienda, "ID", "ID");
            ViewData["EstadoID"] = new SelectList(_context.Estado, "ID", "ID");
            return View();
        }

        // POST: EncomiendaBuses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,BusID,EncomiendaID,EstadoID")] EncomiendaBus encomiendaBus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(encomiendaBus);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["BusID"] = new SelectList(_context.Bus, "ID", "ID", encomiendaBus.BusID);
            ViewData["EncomiendaID"] = new SelectList(_context.Encomienda, "ID", "ID", encomiendaBus.EncomiendaID);
            ViewData["EstadoID"] = new SelectList(_context.Estado, "ID", "ID", encomiendaBus.EstadoID);
            return View(encomiendaBus);
        }

        // GET: EncomiendaBuses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var encomiendaBus = await _context.EncomiendaBus.SingleOrDefaultAsync(m => m.ID == id);
            if (encomiendaBus == null)
            {
                return NotFound();
            }
            ViewData["BusID"] = new SelectList(_context.Bus, "ID", "ID", encomiendaBus.BusID);
            ViewData["EncomiendaID"] = new SelectList(_context.Encomienda, "ID", "ID", encomiendaBus.EncomiendaID);
            ViewData["EstadoID"] = new SelectList(_context.Estado, "ID", "ID", encomiendaBus.EstadoID);
            return View(encomiendaBus);
        }

        // POST: EncomiendaBuses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,BusID,EncomiendaID,EstadoID")] EncomiendaBus encomiendaBus)
        {
            if (id != encomiendaBus.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(encomiendaBus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EncomiendaBusExists(encomiendaBus.ID))
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
            ViewData["BusID"] = new SelectList(_context.Bus, "ID", "ID", encomiendaBus.BusID);
            ViewData["EncomiendaID"] = new SelectList(_context.Encomienda, "ID", "ID", encomiendaBus.EncomiendaID);
            ViewData["EstadoID"] = new SelectList(_context.Estado, "ID", "ID", encomiendaBus.EstadoID);
            return View(encomiendaBus);
        }

        // GET: EncomiendaBuses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var encomiendaBus = await _context.EncomiendaBus
                .Include(e => e.Bus)
                .Include(e => e.Encomienda)
                .Include(e => e.Estado)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (encomiendaBus == null)
            {
                return NotFound();
            }

            return View(encomiendaBus);
        }

        // POST: EncomiendaBuses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var encomiendaBus = await _context.EncomiendaBus.SingleOrDefaultAsync(m => m.ID == id);
            _context.EncomiendaBus.Remove(encomiendaBus);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool EncomiendaBusExists(int id)
        {
            return _context.EncomiendaBus.Any(e => e.ID == id);
        }
    }
}
