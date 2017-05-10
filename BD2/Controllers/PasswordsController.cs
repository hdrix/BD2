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
    public class PasswordsController : Controller
    {
        private readonly ProjectContext _context;

        public PasswordsController(ProjectContext context)
        {
            _context = context;    
        }

        // GET: Passwords
        public async Task<IActionResult> Index()
        {
            return View(await _context.Passwords.ToListAsync());
        }

        // GET: Passwords/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passwords = await _context.Passwords
                .SingleOrDefaultAsync(m => m.ID == id);
            if (passwords == null)
            {
                return NotFound();
            }

            return View(passwords);
        }

        // GET: Passwords/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Passwords/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Fecha,Secret")] Passwords passwords)
        {
            if (ModelState.IsValid)
            {
                _context.Add(passwords);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(passwords);
        }

        // GET: Passwords/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passwords = await _context.Passwords.SingleOrDefaultAsync(m => m.ID == id);
            if (passwords == null)
            {
                return NotFound();
            }
            return View(passwords);
        }

        // POST: Passwords/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Fecha,Secret")] Passwords passwords)
        {
            if (id != passwords.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(passwords);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PasswordsExists(passwords.ID))
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
            return View(passwords);
        }

        // GET: Passwords/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passwords = await _context.Passwords
                .SingleOrDefaultAsync(m => m.ID == id);
            if (passwords == null)
            {
                return NotFound();
            }

            return View(passwords);
        }

        // POST: Passwords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var passwords = await _context.Passwords.SingleOrDefaultAsync(m => m.ID == id);
            _context.Passwords.Remove(passwords);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool PasswordsExists(int id)
        {
            return _context.Passwords.Any(e => e.ID == id);
        }
    }
}
