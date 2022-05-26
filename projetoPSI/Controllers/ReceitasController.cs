using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using projetoPSI.Data;
using projetoPSI.Models;

namespace projetoPSI.Controllers
{
    public class ReceitasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ReceitasController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

       
        // GET: Receitas
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var util = await _context.Utente.Include(i => i.Receitas).FirstOrDefaultAsync(u => u.lig == user.Id);
            if (util == null)return Redirect("./../");
            return View(util.Receitas.ToList());
        }

        // GET: Receitas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receita = await _context.Receita
                .Include(m => m.MedicamentoReceita)
                .ThenInclude(m => m.Medicamento)
                .FirstOrDefaultAsync(m => m.ReceitaId == id);
            if (receita == null)
            {
                return NotFound();
            }
            return View(receita);
        }
       
        // GET: Receitas/Create
        public async Task<IActionResult> Create()
        {
            
            ViewData["Utente"] = new SelectList(_context.Utente, "UtenteId", "Nome");
            ViewData["Medicamento"] = _context.Medicamento.ToList();
            return View();
        }

        // POST: Receitas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReceitaId,ReceitaData,UtenteIDFK")] Receita receita, String medicamentos, String Preco) 
        {
            var user = await _userManager.GetUserAsync(User);
            
            receita.Preco = Preco;


            String[] meds = medicamentos.Trim().Split(" ");
                foreach(String item in meds)
                {
                    Medicamento med = await _context.Medicamento.FirstOrDefaultAsync(m => m.MedicId == Int32.Parse(item));
                    MedicamentoReceita medrec = new MedicamentoReceita
                    {
                        Medicamento = med,
                        MedicamentoFk = Int32.Parse(item),
                        Receita = receita,
                        ReceitaFk = receita.ReceitaId
                    };
                    _context.Add(medrec);
                }
               
                receita.UtenteID = await _context.Utente.FirstOrDefaultAsync(m => m.UtenteId == receita.UtenteIDFK);
                _context.Add(receita);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
        }

        // GET: Receitas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receita = await _context.Receita.FindAsync(id);
            if (receita == null)
            {
                return NotFound();
            }
            return View(receita);
        }

        // POST: Receitas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReceitaId,Preco,ReceitaData,UtenteIDFK")] Receita receita)
        {
            if (id != receita.ReceitaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(receita);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReceitaExists(receita.ReceitaId))
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
            return View(receita);
        }

        // GET: Receitas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receita = await _context.Receita
                .FirstOrDefaultAsync(m => m.ReceitaId == id);
            if (receita == null)
            {
                return NotFound();
            }

            return View(receita);
        }

        // POST: Receitas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var receita = await _context.Receita.FindAsync(id);
            _context.Receita.Remove(receita);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReceitaExists(int id)
        {
            return _context.Receita.Any(e => e.ReceitaId == id);
        }
    }
}
