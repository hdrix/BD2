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
    public class LugaresBusController : Controller
    {
        private readonly ProjectContext _context;

        public LugaresBusController(ProjectContext context)
        {
            _context = context;    
        }

        // GET: LugaresBus
        public async Task<IActionResult> Index()
        {
            var projectContext = _context.LugaresBus.Include(l => l.Bus);
            return View(await projectContext.ToListAsync());
        }

        // GET: LugaresBus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lugaresBus = await _context.LugaresBus
                .Include(l => l.Bus)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (lugaresBus == null)
            {
                return NotFound();
            }

            return View(lugaresBus);
        }

        // GET: LugaresBus/Create
        public IActionResult Create()
        {
            ViewData["BusID"] = new SelectList(_context.Bus, "ID", "ID");
            return View();
        }

        // POST: LugaresBus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,BusID,lugar,ocupado")] LugaresBus lugaresBus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lugaresBus);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["BusID"] = new SelectList(_context.Bus, "ID", "ID", lugaresBus.BusID);
            return View(lugaresBus);
        }

        // GET: LugaresBus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lugaresBus = await _context.LugaresBus.SingleOrDefaultAsync(m => m.ID == id);
            if (lugaresBus == null)
            {
                return NotFound();
            }
            ViewData["BusID"] = new SelectList(_context.Bus, "ID", "ID", lugaresBus.BusID);
            return View(lugaresBus);
        }

        // POST: LugaresBus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,BusID,lugar,ocupado")] LugaresBus lugaresBus)
        {
            if (id != lugaresBus.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lugaresBus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LugaresBusExists(lugaresBus.ID))
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
            ViewData["BusID"] = new SelectList(_context.Bus, "ID", "ID", lugaresBus.BusID);
            return View(lugaresBus);
        }

        // GET: LugaresBus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lugaresBus = await _context.LugaresBus
                .Include(l => l.Bus)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (lugaresBus == null)
            {
                return NotFound();
            }

            return View(lugaresBus);
        }

        // POST: LugaresBus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lugaresBus = await _context.LugaresBus.SingleOrDefaultAsync(m => m.ID == id);
            _context.LugaresBus.Remove(lugaresBus);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool LugaresBusExists(int id)
        {
            return _context.LugaresBus.Any(e => e.ID == id);
        }
    }
}
