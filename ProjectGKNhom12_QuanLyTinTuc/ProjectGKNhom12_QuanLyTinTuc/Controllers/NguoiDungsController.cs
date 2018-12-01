using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectGKNhom12_QuanLiTinTuc.Models;
using ProjectGKNhom12_QuanLyTinTuc.Models;


namespace ProjectGKNhom12_QuanLyTinTuc.Controllers
{
    public class NguoiDungsController : Controller
    {
        private readonly ApplicationDbContex _context;

        public NguoiDungsController(ApplicationDbContex context)
        {
            _context = context;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                NguoiDung nd = _context.NguoiDungs.SingleOrDefault(p => p.MaNguoiDung == model.MaNguoiDung && p.MatKhau == model.matKhau);
                if(nd==null)
                {
                    ModelState.AddModelError("loi", "null");
                    return View();
                }
                HttpContext.Session.Set("MaNguoiDung",nd);
                    return RedirectToAction("Index", "TinTucs");
            }
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("MaNguoiDung");
            return RedirectToAction("Index", "NguoiDungs");
        }
    }
}
