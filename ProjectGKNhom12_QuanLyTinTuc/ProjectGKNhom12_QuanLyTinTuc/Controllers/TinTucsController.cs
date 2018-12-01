using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectGKNhom12_QuanLiTinTuc.Models;
using ProjectGKNhom12_QuanLyTinTuc.Models;

namespace ProjectGKNhom12_QuanLyTinTuc.Controllers
{
    public class TinTucsController : Controller
    {
        private readonly ApplicationDbContex _context;

        public TinTucsController(ApplicationDbContex context)
        {
            _context = context;
        }

        // GET: TinTucs
        public async Task<IActionResult> Index()
        {
            var applicationDbContex = _context.TinTucs.Include(t => t.NguoiDung).Include(t => t.TheLoai);
            return View(await applicationDbContex.ToListAsync());
        }

        // GET: TinTucs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tinTuc = await _context.TinTucs
                .Include(t => t.NguoiDung)
                .Include(t => t.TheLoai)
                .SingleOrDefaultAsync(m => m.MaTin == id);
            if (tinTuc == null)
            {
                return NotFound();
            }

            return View(tinTuc);
        }

        // GET: TinTucs/Create
        public IActionResult Create()
        {
            ViewData["MaNguoiDung"] = new SelectList(_context.NguoiDungs, "MaNguoiDung", "MaNguoiDung");
            ViewData["MaTheLoai"] = new SelectList(_context.TheLoais, "MaTheLoai", "MaTheLoai");
            return View();
        }

        // POST: TinTucs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaTin,TieuDe,NoiDung,Anh,NgayDang,MaNguoiDung,MaTheLoai")] TinTuc tinTuc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tinTuc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaNguoiDung"] = new SelectList(_context.NguoiDungs, "MaNguoiDung", "MaNguoiDung", tinTuc.MaNguoiDung);
            ViewData["MaTheLoai"] = new SelectList(_context.TheLoais, "MaTheLoai", "MaTheLoai", tinTuc.MaTheLoai);
            return View(tinTuc);
        }

        // GET: TinTucs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tinTuc = await _context.TinTucs.SingleOrDefaultAsync(m => m.MaTin == id);
            if (tinTuc == null)
            {
                return NotFound();
            }
            ViewData["MaNguoiDung"] = new SelectList(_context.NguoiDungs, "MaNguoiDung", "MaNguoiDung", tinTuc.MaNguoiDung);
            ViewData["MaTheLoai"] = new SelectList(_context.TheLoais, "MaTheLoai", "MaTheLoai", tinTuc.MaTheLoai);
            return View(tinTuc);
        }

        // POST: TinTucs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaTin,TieuDe,NoiDung,Anh,NgayDang,MaNguoiDung,MaTheLoai")] TinTuc tinTuc)
        {
            if (id != tinTuc.MaTin)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tinTuc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TinTucExists(tinTuc.MaTin))
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
            ViewData["MaNguoiDung"] = new SelectList(_context.NguoiDungs, "MaNguoiDung", "MaNguoiDung", tinTuc.MaNguoiDung);
            ViewData["MaTheLoai"] = new SelectList(_context.TheLoais, "MaTheLoai", "MaTheLoai", tinTuc.MaTheLoai);
            return View(tinTuc);
        }

        // GET: TinTucs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tinTuc = await _context.TinTucs
                .Include(t => t.NguoiDung)
                .Include(t => t.TheLoai)
                .SingleOrDefaultAsync(m => m.MaTin == id);
            if (tinTuc == null)
            {
                return NotFound();
            }

            return View(tinTuc);
        }

        // POST: TinTucs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tinTuc = await _context.TinTucs.SingleOrDefaultAsync(m => m.MaTin == id);
            _context.TinTucs.Remove(tinTuc);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TinTucExists(string id)
        {
            return _context.TinTucs.Any(e => e.MaTin == id);
        }
    }
}
