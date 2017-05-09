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
    public class ClienteEncomiendasController : Controller
    {
        private readonly ProjectContext _context;

        public ClienteEncomiendasController(ProjectContext context)
        {
            _context = context;    
        }

        // GET: ClienteEncomiendas
        public async Task<IActionResult> Index()
        {
            var projectContext = _context.ClienteEncomienda.Include(c => c.Cliente).Include(c => c.Encomienda).Include(c => c.Estado);
            return View(await projectContext.ToListAsync());
        }

        // GET: ClienteEncomiendas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteEncomienda = await _context.ClienteEncomienda
                .Include(c => c.Cliente)
                .Include(c => c.Encomienda)
                .Include(c => c.Estado)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (clienteEncomienda == null)
            {
                return NotFound();
            }

            return View(clienteEncomienda);
        }

        // GET: ClienteEncomiendas/Create
        public IActionResult Create()
        {
            ViewData["ClienteID"] = new SelectList(_context.Cliente, "ID", "ID");
            ViewData["EncomiendaID"] = new SelectList(_context.Encomienda, "ID", "ID");
            ViewData["EstadoID"] = new SelectList(_context.Estado, "ID", "ID");
            return View();
        }

        // POST: ClienteEncomiendas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Fecha,ClienteID,EncomiendaID,EstadoID")] ClienteEncomienda clienteEncomienda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clienteEncomienda);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["ClienteID"] = new SelectList(_context.Cliente, "ID", "ID", clienteEncomienda.ClienteID);
            ViewData["EncomiendaID"] = new SelectList(_context.Encomienda, "ID", "ID", clienteEncomienda.EncomiendaID);
            ViewData["EstadoID"] = new SelectList(_context.Estado, "ID", "ID", clienteEncomienda.EstadoID);
            return View(clienteEncomienda);
        }

        // GET: ClienteEncomiendas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteEncomienda = await _context.ClienteEncomienda.SingleOrDefaultAsync(m => m.ID == id);
            if (clienteEncomienda == null)
            {
                return NotFound();
            }
            ViewData["ClienteID"] = new SelectList(_context.Cliente, "ID", "ID", clienteEncomienda.ClienteID);
            ViewData["EncomiendaID"] = new SelectList(_context.Encomienda, "ID", "ID", clienteEncomienda.EncomiendaID);
            ViewData["EstadoID"] = new SelectList(_context.Estado, "ID", "ID", clienteEncomienda.EstadoID);
            return View(clienteEncomienda);
        }

        // POST: ClienteEncomiendas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Fecha,ClienteID,EncomiendaID,EstadoID")] ClienteEncomienda clienteEncomienda)
        {
            if (id != clienteEncomienda.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clienteEncomienda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteEncomiendaExists(clienteEncomienda.ID))
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
            ViewData["ClienteID"] = new SelectList(_context.Cliente, "ID", "ID", clienteEncomienda.ClienteID);
            ViewData["EncomiendaID"] = new SelectList(_context.Encomienda, "ID", "ID", clienteEncomienda.EncomiendaID);
            ViewData["EstadoID"] = new SelectList(_context.Estado, "ID", "ID", clienteEncomienda.EstadoID);
            return View(clienteEncomienda);
        }

        // GET: ClienteEncomiendas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteEncomienda = await _context.ClienteEncomienda
                .Include(c => c.Cliente)
                .Include(c => c.Encomienda)
                .Include(c => c.Estado)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (clienteEncomienda == null)
            {
                return NotFound();
            }

            return View(clienteEncomienda);
        }

        // POST: ClienteEncomiendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clienteEncomienda = await _context.ClienteEncomienda.SingleOrDefaultAsync(m => m.ID == id);
            _context.ClienteEncomienda.Remove(clienteEncomienda);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ClienteEncomiendaExists(int id)
        {
            return _context.ClienteEncomienda.Any(e => e.ID == id);
        }
    }
}
