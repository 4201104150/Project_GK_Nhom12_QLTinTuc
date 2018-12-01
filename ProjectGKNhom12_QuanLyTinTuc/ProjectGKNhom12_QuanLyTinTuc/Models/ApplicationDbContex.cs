using Microsoft.EntityFrameworkCore;
using ProjectGKNhom12_QuanLiTinTuc;
using ProjectGKNhom12_QuanLiTinTuc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectGKNhom12_QuanLyTinTuc.Models
{
    public class ApplicationDbContex:DbContext
    {
        public DbSet<NguoiDung> NguoiDungs { get; set; }
        public DbSet<TheLoai> TheLoais { get; set; }
        public DbSet<TinTuc> TinTucs { get; set; }

        public ApplicationDbContex(DbContextOptions<ApplicationDbContex> options)
            : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
