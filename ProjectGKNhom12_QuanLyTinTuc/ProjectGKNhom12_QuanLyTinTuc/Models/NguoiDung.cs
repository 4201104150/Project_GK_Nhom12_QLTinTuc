using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectGKNhom12_QuanLiTinTuc.Models
{
    public class NguoiDung
    {
        [Key]
        public string MaNguoiDung { get; set; }
        public string HoTen { get; set; }
        public string MatKhau { get; set; }
        public int KieuNguoiDung { get; set; }
    }
}
