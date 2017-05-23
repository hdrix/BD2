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
    public class BusEncomiendasController : Controller
    {
        private readonly ProjectContext _context;

        public BusEncomiendasController(ProjectContext context)
        {
            _context = context;    
        }

        // GET: BusEncomiendas
        public async Task<IActionResult> Index()
        {
            var projectContext = _context.BusEncomienda.Include(b => b.Bus).Include(b => b.Encomienda).Include(b => b.Estado);
            return View(await projectContext.ToListAsync());
        }

        // GET: BusEncomiendas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var busEncomienda = await _context.BusEncomienda
                .Include(b => b.Bus)
                .Include(b => b.Encomienda)
                .Include(b => b.Estado)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (busEncomienda == null)
            {
                return NotFound();
            }

            return View(busEncomienda);
        }

        // GET: BusEncomiendas/Create
        public IActionResult Create()
        {
            ViewData["BusID"] = new SelectList(_context.Bus, "ID", "ID");
            ViewData["EncomiendaID"] = new SelectList(_context.Encomienda, "ID", "ID");
            ViewData["EstadoID"] = new SelectList(_context.Estado, "ID", "ID");
            return View();
        }

        // POST: BusEncomiendas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nombre,EncomiendaID,BusID,EstadoID")] BusEncomienda busEncomienda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(busEncomienda);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["BusID"] = new SelectList(_context.Bus, "ID", "ID", busEncomienda.BusID);
            ViewData["EncomiendaID"] = new SelectList(_context.Encomienda, "ID", "ID", busEncomienda.EncomiendaID);
            ViewData["EstadoID"] = new SelectList(_context.Estado, "ID", "ID", busEncomienda.EstadoID);
            return View(busEncomienda);
        }

        // GET: BusEncomiendas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var busEncomienda = await _context.BusEncomienda.SingleOrDefaultAsync(m => m.ID == id);
            if (busEncomienda == null)
            {
                return NotFound();
            }
            ViewData["BusID"] = new SelectList(_context.Bus, "ID", "ID", busEncomienda.BusID);
            ViewData["EncomiendaID"] = new SelectList(_context.Encomienda, "ID", "ID", busEncomienda.EncomiendaID);
            ViewData["EstadoID"] = new SelectList(_context.Estado, "ID", "ID", busEncomienda.EstadoID);
            return View(busEncomienda);
        }

        // POST: BusEncomiendas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nombre,EncomiendaID,BusID,EstadoID")] BusEncomienda busEncomienda)
        {
            if (id != busEncomienda.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(busEncomienda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BusEncomiendaExists(busEncomienda.ID))
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
            ViewData["BusID"] = new SelectList(_context.Bus, "ID", "ID", busEncomienda.BusID);
            ViewData["EncomiendaID"] = new SelectList(_context.Encomienda, "ID", "ID", busEncomienda.EncomiendaID);
            ViewData["EstadoID"] = new SelectList(_context.Estado, "ID", "ID", busEncomienda.EstadoID);
            return View(busEncomienda);
        }

        // GET: BusEncomiendas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var busEncomienda = await _context.BusEncomienda
                .Include(b => b.Bus)
                .Include(b => b.Encomienda)
                .Include(b => b.Estado)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (busEncomienda == null)
            {
                return NotFound();
            }

            return View(busEncomienda);
        }

        // POST: BusEncomiendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var busEncomienda = await _context.BusEncomienda.SingleOrDefaultAsync(m => m.ID == id);
            _context.BusEncomienda.Remove(busEncomienda);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool BusEncomiendaExists(int id)
        {
            return _context.BusEncomienda.Any(e => e.ID == id);
        }
    }
}
