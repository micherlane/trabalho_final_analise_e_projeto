#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using micherlane.Models;

namespace micherlane.Controllers
{
    public class NotaDaVendasController : Controller
    {
        private readonly MyDbContext _context;

        public NotaDaVendasController(MyDbContext context)
        {
            _context = context;
        }

        // GET: NotaDaVendas
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.NotaDaVenda.Include(n => n.Cliente).Include(n => n.TipoDePagamento).Include(n => n.Vendedor);
            return View(await myDbContext.ToListAsync());
        }

        // GET: NotaDaVendas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notaDaVenda = await _context.NotaDaVenda
                .Include(n => n.Cliente)
                .Include(n => n.TipoDePagamento)
                .Include(n => n.Vendedor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (notaDaVenda == null)
            {
                return NotFound();
            }

            return View(notaDaVenda);
        }

        // GET: NotaDaVendas/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Nome");
            ViewData["TipoDePagamentoId"] = new SelectList(_context.TipoDePagamento, "Id", "Discriminator");
            ViewData["VendedorId"] = new SelectList(_context.Vendedor, "Id", "Nome");
            return View();
        }

        // POST: NotaDaVendas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Data,Tipo,Devolvido,VendedorId,TipoDePagamentoId,ClienteId")] NotaDaVenda notaDaVenda)
        {

            _context.Add(notaDaVenda);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


        }

        // GET: NotaDaVendas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notaDaVenda = await _context.NotaDaVenda.FindAsync(id);
            if (notaDaVenda == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Id", notaDaVenda.ClienteId);
            ViewData["TipoDePagamentoId"] = new SelectList(_context.TipoDePagamento, "Id", "Discriminator", notaDaVenda.TipoDePagamentoId);
            ViewData["VendedorId"] = new SelectList(_context.Vendedor, "Id", "Id", notaDaVenda.VendedorId);
            return View(notaDaVenda);
        }

        // POST: NotaDaVendas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Data,Tipo,Devolvido,VendedorId,TipoDePagamentoId,ClienteId")] NotaDaVenda notaDaVenda)
        {
            if (id != notaDaVenda.Id)
            {
                return NotFound();
            }


            try
            {
                _context.Update(notaDaVenda);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotaDaVendaExists(notaDaVenda.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));

        }

        // GET: NotaDaVendas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notaDaVenda = await _context.NotaDaVenda
                .Include(n => n.Cliente)
                .Include(n => n.TipoDePagamento)
                .Include(n => n.Vendedor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (notaDaVenda == null)
            {
                return NotFound();
            }

            return View(notaDaVenda);
        }

        // POST: NotaDaVendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var notaDaVenda = await _context.NotaDaVenda.FindAsync(id);
            _context.NotaDaVenda.Remove(notaDaVenda);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NotaDaVendaExists(int id)
        {
            return _context.NotaDaVenda.Any(e => e.Id == id);
        }
    }
}
