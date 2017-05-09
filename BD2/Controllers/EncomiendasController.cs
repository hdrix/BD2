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
    public class EncomiendasController : Controller
    {
        private readonly ProjectContext _context;

        public EncomiendasController(ProjectContext context)
        {
            _context = context;    
        }

        // GET: Encomiendas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Encomienda.ToListAsync());
        }

        // GET: Encomiendas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var encomienda = await _context.Encomienda
                .SingleOrDefaultAsync(m => m.ID == id);
            if (encomienda == null)
            {
                return NotFound();
            }

            return View(encomienda);
        }

        // GET: Encomiendas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Encomiendas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nombre,Descrip")] Encomienda encomienda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(encomienda);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(encomienda);
        }

        // GET: Encomiendas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var encomienda = await _context.Encomienda.SingleOrDefaultAsync(m => m.ID == id);
            if (encomienda == null)
            {
                return NotFound();
            }
            return View(encomienda);
        }

        // POST: Encomiendas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nombre,Descrip")] Encomienda encomienda)
        {
            if (id != encomienda.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(encomienda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EncomiendaExists(encomienda.ID))
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
            return View(encomienda);
        }

        // GET: Encomiendas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var encomienda = await _context.Encomienda
                .SingleOrDefaultAsync(m => m.ID == id);
            if (encomienda == null)
            {
                return NotFound();
            }

            return View(encomienda);
        }

        // POST: Encomiendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var encomienda = await _context.Encomienda.SingleOrDefaultAsync(m => m.ID == id);
            _context.Encomienda.Remove(encomienda);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool EncomiendaExists(int id)
        {
            return _context.Encomienda.Any(e => e.ID == id);
        }
    }
}
