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
    public class BusesDestinosController : Controller
    {
        private readonly ProjectContext _context;

        public BusesDestinosController(ProjectContext context)
        {
            _context = context;    
        }

        // GET: BusesDestinos
        public async Task<IActionResult> Index()
        {
            var projectContext = _context.BusDestinos.Include(b => b.Bus).Include(b => b.Destino).Include(b => b.Horario);
            return View(await projectContext.ToListAsync());
        }

        // GET: BusesDestinos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var busDestinos = await _context.BusDestinos
                .Include(b => b.Bus)
                .Include(b => b.Destino)
                .Include(b => b.Horario)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (busDestinos == null)
            {
                return NotFound();
            }

            return View(busDestinos);
        }

        // GET: BusesDestinos/Create
        public IActionResult Create()
        {
            ViewData["BusID"] = new SelectList(_context.Bus, "ID", "ID");
            ViewData["DestinoID"] = new SelectList(_context.Destino, "ID", "ID");
            ViewData["HorarioID"] = new SelectList(_context.Horario, "ID", "ID");
            return View();
        }

        // POST: BusesDestinos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Fecha,Estado,HorarioID,BusID,DestinoID")] BusDestinos busDestinos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(busDestinos);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["BusID"] = new SelectList(_context.Bus, "ID", "ID", busDestinos.BusID);
            ViewData["DestinoID"] = new SelectList(_context.Destino, "ID", "ID", busDestinos.DestinoID);
            ViewData["HorarioID"] = new SelectList(_context.Horario, "ID", "ID", busDestinos.HorarioID);
            return View(busDestinos);
        }

        // GET: BusesDestinos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var busDestinos = await _context.BusDestinos.SingleOrDefaultAsync(m => m.ID == id);
            if (busDestinos == null)
            {
                return NotFound();
            }
            ViewData["BusID"] = new SelectList(_context.Bus, "ID", "ID", busDestinos.BusID);
            ViewData["DestinoID"] = new SelectList(_context.Destino, "ID", "ID", busDestinos.DestinoID);
            ViewData["HorarioID"] = new SelectList(_context.Horario, "ID", "ID", busDestinos.HorarioID);
            return View(busDestinos);
        }

        // POST: BusesDestinos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Fecha,Estado,HorarioID,BusID,DestinoID")] BusDestinos busDestinos)
        {
            if (id != busDestinos.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(busDestinos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BusDestinosExists(busDestinos.ID))
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
            ViewData["BusID"] = new SelectList(_context.Bus, "ID", "ID", busDestinos.BusID);
            ViewData["DestinoID"] = new SelectList(_context.Destino, "ID", "ID", busDestinos.DestinoID);
            ViewData["HorarioID"] = new SelectList(_context.Horario, "ID", "ID", busDestinos.HorarioID);
            return View(busDestinos);
        }

        // GET: BusesDestinos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var busDestinos = await _context.BusDestinos
                .Include(b => b.Bus)
                .Include(b => b.Destino)
                .Include(b => b.Horario)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (busDestinos == null)
            {
                return NotFound();
            }

            return View(busDestinos);
        }

        // POST: BusesDestinos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var busDestinos = await _context.BusDestinos.SingleOrDefaultAsync(m => m.ID == id);
            _context.BusDestinos.Remove(busDestinos);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool BusDestinosExists(int id)
        {
            return _context.BusDestinos.Any(e => e.ID == id);
        }
    }
}
