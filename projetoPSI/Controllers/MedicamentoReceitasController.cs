using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using projetoPSI.Data;
using projetoPSI.Models;

namespace projetoPSI.Controllers
{
    public class MedicamentoReceitasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MedicamentoReceitasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MedicamentoReceitas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.MedicamentoReceita.Include(m => m.Medicamento).Include(m => m.Receita);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: MedicamentoReceitas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicamentoReceita = await _context.MedicamentoReceita
                .Include(m => m.Medicamento)
                .Include(m => m.Receita)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medicamentoReceita == null)
            {
                return NotFound();
            }

            return View(medicamentoReceita);
        }

        // GET: MedicamentoReceitas/Create
        public IActionResult Create()
        {
            ViewData["MedicamentoFk"] = new SelectList(_context.Medicamento, "MedicId", "MedicId");
            ViewData["ReceitaFk"] = new SelectList(_context.Receita, "ReceitaId", "ReceitaId");
            return View();
        }

        // POST: MedicamentoReceitas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ReceitaFk,MedicamentoFk")] MedicamentoReceita medicamentoReceita)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medicamentoReceita);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MedicamentoFk"] = new SelectList(_context.Medicamento, "MedicId", "MedicId", medicamentoReceita.MedicamentoFk);
            ViewData["ReceitaFk"] = new SelectList(_context.Receita, "ReceitaId", "ReceitaId", medicamentoReceita.ReceitaFk);
            return View(medicamentoReceita);
        }

        // GET: MedicamentoReceitas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicamentoReceita = await _context.MedicamentoReceita.FindAsync(id);
            if (medicamentoReceita == null)
            {
                return NotFound();
            }
            ViewData["MedicamentoFk"] = new SelectList(_context.Medicamento, "MedicId", "MedicId", medicamentoReceita.MedicamentoFk);
            ViewData["ReceitaFk"] = new SelectList(_context.Receita, "ReceitaId", "ReceitaId", medicamentoReceita.ReceitaFk);
            return View(medicamentoReceita);
        }

        // POST: MedicamentoReceitas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ReceitaFk,MedicamentoFk")] MedicamentoReceita medicamentoReceita)
        {
            if (id != medicamentoReceita.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicamentoReceita);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicamentoReceitaExists(medicamentoReceita.Id))
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
            ViewData["MedicamentoFk"] = new SelectList(_context.Medicamento, "MedicId", "MedicId", medicamentoReceita.MedicamentoFk);
            ViewData["ReceitaFk"] = new SelectList(_context.Receita, "ReceitaId", "ReceitaId", medicamentoReceita.ReceitaFk);
            return View(medicamentoReceita);
        }

        // GET: MedicamentoReceitas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicamentoReceita = await _context.MedicamentoReceita
                .Include(m => m.Medicamento)
                .Include(m => m.Receita)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medicamentoReceita == null)
            {
                return NotFound();
            }

            return View(medicamentoReceita);
        }

        // POST: MedicamentoReceitas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medicamentoReceita = await _context.MedicamentoReceita.FindAsync(id);
            _context.MedicamentoReceita.Remove(medicamentoReceita);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicamentoReceitaExists(int id)
        {
            return _context.MedicamentoReceita.Any(e => e.Id == id);
        }
    }
}
