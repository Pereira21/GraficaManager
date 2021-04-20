using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DevIO.Business.Models;
using DevIO.Data.Data;
using DevIO.App.Models;

namespace DevIO.App.Controllers
{
    public class MateriaPrimaEstoquesController : Controller
    {
        private readonly GraficaDbContext _context;

        public MateriaPrimaEstoquesController(GraficaDbContext context)
        {
            _context = context;
        }

        // GET: MateriaPrimaEstoques
        public async Task<IActionResult> Index()
        {
            return View(await _context.MateriasPrimasEstoque.ToListAsync());
        }

        // GET: MateriaPrimaEstoques/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materiaPrimaEstoque = await _context.MateriasPrimasEstoque
                .FirstOrDefaultAsync(m => m.Id == id);
            if (materiaPrimaEstoque == null)
            {
                return NotFound();
            }

            return View(materiaPrimaEstoque);
        }

        // GET: MateriaPrimaEstoques/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MateriaPrimaEstoques/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MateriaPrimaEstoquesViewModel materiaPrimaEstoque)
        {
            if (ModelState.IsValid)
            {
                materiaPrimaEstoque.Id = Guid.NewGuid();
                _context.Add(materiaPrimaEstoque);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(materiaPrimaEstoque);
        }

        // GET: MateriaPrimaEstoques/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materiaPrimaEstoque = await _context.MateriasPrimasEstoque.FindAsync(id);
            if (materiaPrimaEstoque == null)
            {
                return NotFound();
            }
            return View(materiaPrimaEstoque);
        }

        // POST: MateriaPrimaEstoques/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, MateriaPrimaEstoquesViewModel materiaPrimaEstoque)
        {
            if (id != materiaPrimaEstoque.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(materiaPrimaEstoque);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MateriaPrimaEstoqueExists(materiaPrimaEstoque.Id))
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
            return View(materiaPrimaEstoque);
        }

        // GET: MateriaPrimaEstoques/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materiaPrimaEstoque = await _context.MateriasPrimasEstoque
                .FirstOrDefaultAsync(m => m.Id == id);
            if (materiaPrimaEstoque == null)
            {
                return NotFound();
            }

            return View(materiaPrimaEstoque);
        }

        // POST: MateriaPrimaEstoques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var materiaPrimaEstoque = await _context.MateriasPrimasEstoque.FindAsync(id);
            _context.MateriasPrimasEstoque.Remove(materiaPrimaEstoque);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MateriaPrimaEstoqueExists(Guid id)
        {
            return _context.MateriasPrimasEstoque.Any(e => e.Id == id);
        }
    }
}
