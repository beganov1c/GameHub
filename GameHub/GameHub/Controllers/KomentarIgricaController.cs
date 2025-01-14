﻿using GameHub.Data;
using GameHub.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameHub.Controllers
{
    public class KomentarIgricaController : Controller
    {
        private readonly ApplicationDbContext _context;


        public KomentarIgricaController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: KomentarIgrica/KomentariIgrica
        public async Task<IActionResult> KomentariIgrica(int ?id)
        {
            var igrice = await _context.KomentarIgrica.ToListAsync();
            igrice.RemoveAll(komentar => komentar.IgricaId != id);
            return View(igrice);
        }

        public async Task<IActionResult> KomentarVecPostoji()
        {
            return View(await _context.KomentarIgrica.ToListAsync());
        }


        // GET: KomentarIgrica
        public async Task<IActionResult> Index()
        {
            return View(await _context.KomentarIgrica.ToListAsync());
        }

        // GET: KomentarIgrica/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var komentarIgrica = await _context.KomentarIgrica
                .FirstOrDefaultAsync(m => m.Id == id);
            if (komentarIgrica == null)
            {
                return NotFound();
            }

            return View(komentarIgrica);
        }
        [Authorize(Roles = "Gamer")]
        // GET: KomentarIgrica/Create
        public IActionResult Create(int? id)
        {
            var model = new KomentarIgrica();
            model.IgricaId = (int)id;
            return View(model);
        }

        // POST: KomentarIgrica/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Tekst,Ocjena,IgricaId,KorisnikId")] KomentarIgrica komentarIgrica)
        {
            if (ModelState.IsValid)
            {
                var igrice = await _context.KomentarIgrica.ToListAsync();
                if (igrice.Find(igrice => igrice.KorisnikId == komentarIgrica.KorisnikId && igrice.IgricaId == komentarIgrica.IgricaId) != null)
                {
                    return RedirectToAction("KomentarVecPostoji");
                }


                _context.Add(komentarIgrica);
                await _context.SaveChangesAsync();
                return RedirectToAction("KomentariIgrica", new {id=komentarIgrica.IgricaId});
            }
            return View(komentarIgrica);
        }
        [Authorize(Roles = "Gamer")]
        // GET: KomentarIgrica/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var komentarIgrica = await _context.KomentarIgrica.FindAsync(id);
            if (komentarIgrica == null)
            {
                return NotFound();
            }
            return View(komentarIgrica);
        }

        // POST: KomentarIgrica/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tekst,Ocjena,IgricaId,KorisnikId")] KomentarIgrica komentarIgrica)
        {
            if (id != komentarIgrica.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(komentarIgrica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KomentarIgricaExists(komentarIgrica.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("KomentariIgrica", new {id=komentarIgrica.IgricaId});
            }
            return View(komentarIgrica);
        }

        [Authorize(Roles = "Admin, Gamer")]

        // GET: KomentarIgrica/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var komentarIgrica = await _context.KomentarIgrica
                .FirstOrDefaultAsync(m => m.Id == id);
            if (komentarIgrica == null)
            {
                return NotFound();
            }

            return View(komentarIgrica);
        }

        public async Task<IActionResult> KomentariKorisnika(string id)
        {
            var igrica = await _context.KomentarIgrica.ToListAsync();
            igrica.RemoveAll(igric => igric.KorisnikId != id);
            var igrice = await _context.Igrica.ToListAsync();
            Tuple<List<KomentarIgrica>, List<Igrica>> tuple = new Tuple<List<KomentarIgrica>, List<Igrica>>(igrica, igrice);

            return View(tuple);
        }

        // POST: KomentarIgrica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var komentarIgrica = await _context.KomentarIgrica.FindAsync(id);
            _context.KomentarIgrica.Remove(komentarIgrica);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KomentarIgricaExists(int id)
        {
            return _context.KomentarIgrica.Any(e => e.Id == id);
        }
    }
}
