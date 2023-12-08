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
    public class PagamentoComChequesController : Controller
    {
        private readonly MyDbContext _context;

        public PagamentoComChequesController(MyDbContext context)
        {
            _context = context;
        }

        // GET: PagamentoComCheques
        public async Task<IActionResult> Index()
        {
            return View(await _context.PagamentoComCheque.ToListAsync());
        }

        // GET: PagamentoComCheques/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagamentoComCheque = await _context.PagamentoComCheque
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pagamentoComCheque == null)
            {
                return NotFound();
            }

            return View(pagamentoComCheque);
        }

        // GET: PagamentoComCheques/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PagamentoComCheques/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Banco,NomeDoBanco,Id,NomeDoCobrado,InformacoesAdicionais,Discriminator")] PagamentoComCheque pagamentoComCheque)
        {

            _context.Add(pagamentoComCheque);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        // GET: PagamentoComCheques/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagamentoComCheque = await _context.PagamentoComCheque.FindAsync(id);
            if (pagamentoComCheque == null)
            {
                return NotFound();
            }
            return View(pagamentoComCheque);
        }

        // POST: PagamentoComCheques/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Banco,NomeDoBanco,Id,NomeDoCobrado,InformacoesAdicionais,Discriminator")] PagamentoComCheque pagamentoComCheque)
        {
            if (id != pagamentoComCheque.Id)
            {
                return NotFound();
            }


            try
            {
                _context.Update(pagamentoComCheque);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PagamentoComChequeExists(pagamentoComCheque.Id))
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

        // GET: PagamentoComCheques/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagamentoComCheque = await _context.PagamentoComCheque
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pagamentoComCheque == null)
            {
                return NotFound();
            }

            return View(pagamentoComCheque);
        }

        // POST: PagamentoComCheques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pagamentoComCheque = await _context.PagamentoComCheque.FindAsync(id);
            _context.PagamentoComCheque.Remove(pagamentoComCheque);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PagamentoComChequeExists(int id)
        {
            return _context.PagamentoComCheque.Any(e => e.Id == id);
        }
    }
}
