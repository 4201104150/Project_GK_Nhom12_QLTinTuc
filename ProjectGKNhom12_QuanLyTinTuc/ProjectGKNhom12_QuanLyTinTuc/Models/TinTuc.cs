using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectGKNhom12_QuanLiTinTuc.Models
{
    public class TinTuc
    {   [Display(Name ="Mã tin tức")]
        [Key]
        public string MaTin { get; set; }
        [Display(Name = "Tiêu đề")]
        public string TieuDe { get; set; }
        [Display(Name = "Nội dung")]
        public string NoiDung { get; set; }
        [Display(Name = "Ảnh")]
        public string Anh { get; set; }
        [Display(Name = "Ngày đăng")]
        public DateTime NgayDang { get; set; }
        
        [ForeignKey("MaNguoiDung")]
        [Display(Name = "Người dùng")]
        public string MaNguoiDung { get; set; }
        public NguoiDung NguoiDung { get; set; }
        
        [ForeignKey("MaTheLoai")]
        [Display(Name = "Thể loại")]
        public string MaTheLoai { get; set; }
        public TheLoai TheLoai { get; set; }
    }
}
