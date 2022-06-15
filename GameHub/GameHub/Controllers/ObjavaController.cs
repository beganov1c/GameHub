using GameHub.Data;
using GameHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace GameHub.Controllers
{
    public class ObjavaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ObjavaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Objava
        public async Task<IActionResult> Index()
        {
            return View(await _context.Objava.ToListAsync());
        }

        // GET: Objava/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var objava = await _context.Objava
                .FirstOrDefaultAsync(m => m.Id == id);
            if (objava == null)
            {
                return NotFound();
            }

            return View(objava);
        }

        // GET: Objava/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Objava/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tekst,Lajkovi")] Objava objava)
        {
            if (ModelState.IsValid)
            {
                _context.Add(objava);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(objava);
        }

        // GET: Objava/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var objava = await _context.Objava.FindAsync(id);
            if (objava == null)
            {
                return NotFound();
            }
            return View(objava);
        }

        // POST: Objava/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tekst,Lajkovi")] Objava objava)
        {
            if (id != objava.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(objava);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObjavaExists(objava.Id))
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
            return View(objava);
        }

        // GET: Objava/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var objava = await _context.Objava
                .FirstOrDefaultAsync(m => m.Id == id);
            if (objava == null)
            {
                return NotFound();
            }

            return View(objava);
        }

        // POST: Objava/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var objava = await _context.Objava.FindAsync(id);
            _context.Objava.Remove(objava);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ObjavaExists(int id)
        {
            return _context.Objava.Any(e => e.Id == id);
        }
    }
}
