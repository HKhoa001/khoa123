using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Demo.Data;
using Demo.Models;
using Demo.Models.Process;

namespace Demo.Controllers
{
    public class HoaQuaController : Controller
    {
        StringProcess Prc = new StringProcess();
        private readonly ApplicationDbContext _context;

        public HoaQuaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HoaQua
        public async Task<IActionResult> Index()
        {
              return _context.HoaQua != null ? 
                          View(await _context.HoaQua.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.HoaQua'  is null.");
        }

        // GET: HoaQua/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.HoaQua == null)
            {
                return NotFound();
            }

            var hoaQua = await _context.HoaQua
                .FirstOrDefaultAsync(m => m.ID == id);
            if (hoaQua == null)
            {
                return NotFound();
            }

            return View(hoaQua);
        }

        // GET: HoaQua/Create
        public IActionResult Create()
        {
            string newID;
            if (_context.HoaQua.Any())
            {
                var stdID = _context.HoaQua.OrderByDescending(s => s.ID).First();
                newID = Prc.AutoGenerateCode(stdID.ID);
            }
            else
            {
                newID = "HQ001";
            }
            ViewBag.NewID = newID;
            return View();
        }

        // POST: HoaQua/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Ten,SoLuong")] HoaQua hoaQua)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hoaQua);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hoaQua);
        }

        // GET: HoaQua/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.HoaQua == null)
            {
                return NotFound();
            }

            var hoaQua = await _context.HoaQua.FindAsync(id);
            if (hoaQua == null)
            {
                return NotFound();
            }
            return View(hoaQua);
        }

        // POST: HoaQua/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,Ten,SoLuong")] HoaQua hoaQua)
        {
            if (id != hoaQua.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hoaQua);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HoaQuaExists(hoaQua.ID))
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
            return View(hoaQua);
        }

        // GET: HoaQua/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.HoaQua == null)
            {
                return NotFound();
            }

            var hoaQua = await _context.HoaQua
                .FirstOrDefaultAsync(m => m.ID == id);
            if (hoaQua == null)
            {
                return NotFound();
            }

            return View(hoaQua);
        }

        // POST: HoaQua/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.HoaQua == null)
            {
                return Problem("Entity set 'ApplicationDbContext.HoaQua'  is null.");
            }
            var hoaQua = await _context.HoaQua.FindAsync(id);
            if (hoaQua != null)
            {
                _context.HoaQua.Remove(hoaQua);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HoaQuaExists(string id)
        {
          return (_context.HoaQua?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
