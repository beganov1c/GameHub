using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GameHub.Data;
using GameHub.Models;
using Microsoft.AspNetCore.Authorization;

namespace GameHub.Controllers

{
    public class IgricaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IgricaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Igrica
        public async Task<IActionResult> Index(string imeIgrice)
        {
            var igrica = from m in _context.Igrica
                         select m;

            if (!String.IsNullOrEmpty(imeIgrice))
            {
                igrica = igrica.Where(s => s.Naziv.Contains(imeIgrice));
            }

            return View(await igrica.ToListAsync());
        }

        // GET: Igrica/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var igrica = await _context.Igrica
                .FirstOrDefaultAsync(m => m.Id == id);
            if (igrica == null)
            {
                return NotFound();
            }

            return View(igrica);
        }
        [Authorize]
        // GET: Igrica/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Igrica/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naziv,Opis,SrednjaOcjena,Autor,Zanr,RRated")] Igrica igrica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(igrica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(igrica);
        }
        [Authorize]
        // GET: Igrica/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var igrica = await _context.Igrica.FindAsync(id);
            if (igrica == null)
            {
                return NotFound();
            }
            return View(igrica);
        }

        // POST: Igrica/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naziv,Opis,SrednjaOcjena,Autor,Zanr,RRated")] Igrica igrica)
        {
            if (id != igrica.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(igrica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IgricaExists(igrica.Id))
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
            return View(igrica);
        }
        [Authorize]
        // GET: Igrica/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var igrica = await _context.Igrica
                .FirstOrDefaultAsync(m => m.Id == id);
            if (igrica == null)
            {
                return NotFound();
            }

            return View(igrica);
        }

        // POST: Igrica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var igrica = await _context.Igrica.FindAsync(id);
            _context.Igrica.Remove(igrica);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IgricaExists(int id)
        {
            return _context.Igrica.Any(e => e.Id == id);
        }
    }
}
