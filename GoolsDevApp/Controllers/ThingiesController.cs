using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GoolsDevApp.DAL;
using GoolsDevApp.Models;

namespace GoolsDevApp.Controllers
{
    public class ThingiesController : Controller
    {
        private readonly GoolsDevContext _context;

        public ThingiesController(GoolsDevContext context)
        {
            _context = context;
        }

        // GET: Thingies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Thingies.ToListAsync());
        }

        // GET: Thingies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thingy = await _context.Thingies
                .FirstOrDefaultAsync(m => m.ThingyId == id);
            if (thingy == null)
            {
                return NotFound();
            }

            return View(thingy);
        }

        // GET: Thingies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Thingies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ThingyId,Count,Text")] Thingy thingy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(thingy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(thingy);
        }

        // GET: Thingies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thingy = await _context.Thingies.FindAsync(id);
            if (thingy == null)
            {
                return NotFound();
            }
            return View(thingy);
        }

        // POST: Thingies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ThingyId,Count,Text")] Thingy thingy)
        {
            if (id != thingy.ThingyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(thingy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThingyExists(thingy.ThingyId))
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
            return View(thingy);
        }

        // GET: Thingies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thingy = await _context.Thingies
                .FirstOrDefaultAsync(m => m.ThingyId == id);
            if (thingy == null)
            {
                return NotFound();
            }

            return View(thingy);
        }

        // POST: Thingies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var thingy = await _context.Thingies.FindAsync(id);
            _context.Thingies.Remove(thingy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ThingyExists(int id)
        {
            return _context.Thingies.Any(e => e.ThingyId == id);
        }
    }
}
