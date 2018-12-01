using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectGKNhom12_QuanLiTinTuc.Models
{
    public class TinTuc
    {
        [Key]
        public string MaTin { get; set; }
        public string TieuDe { get; set; }
        public string NoiDung { get; set; }
        public string Anh { get; set; }
        public DateTime NgayDang { get; set; }

        [ForeignKey("MaNguoiDung")]
        public string MaNguoiDung { get; set; }
        public NguoiDung NguoiDung { get; set; }

        [ForeignKey("MaTheLoai")]
        public string MaTheLoai { get; set; }
        public TheLoai TheLoai { get; set; }
    }
}
