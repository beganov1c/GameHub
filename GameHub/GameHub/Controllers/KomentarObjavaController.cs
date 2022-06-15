using GameHub.Data;
using GameHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace GameHub.Controllers
{
    public class KomentarObjavaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KomentarObjavaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: KomentarObjava
        public async Task<IActionResult> Index()
        {
            return View(await _context.KomentarObjava.ToListAsync());
        }

        // GET: KomentarObjava/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var komentarObjava = await _context.KomentarObjava
                .FirstOrDefaultAsync(m => m.Id == id);
            if (komentarObjava == null)
            {
                return NotFound();
            }

            return View(komentarObjava);
        }

        // GET: KomentarObjava/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KomentarObjava/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tekst,Lajkovi,ObjavaId")] KomentarObjava komentarObjava)
        {
            if (ModelState.IsValid)
            {
                _context.Add(komentarObjava);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(komentarObjava);
        }

        // GET: KomentarObjava/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var komentarObjava = await _context.KomentarObjava.FindAsync(id);
            if (komentarObjava == null)
            {
                return NotFound();
            }
            return View(komentarObjava);
        }

        // POST: KomentarObjava/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tekst,Lajkovi,ObjavaId")] KomentarObjava komentarObjava)
        {
            if (id != komentarObjava.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(komentarObjava);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KomentarObjavaExists(komentarObjava.Id))
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
            return View(komentarObjava);
        }

        // GET: KomentarObjava/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var komentarObjava = await _context.KomentarObjava
                .FirstOrDefaultAsync(m => m.Id == id);
            if (komentarObjava == null)
            {
                return NotFound();
            }

            return View(komentarObjava);
        }

        // POST: KomentarObjava/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var komentarObjava = await _context.KomentarObjava.FindAsync(id);
            _context.KomentarObjava.Remove(komentarObjava);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KomentarObjavaExists(int id)
        {
            return _context.KomentarObjava.Any(e => e.Id == id);
        }
    }
}
