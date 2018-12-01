using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectGKNhom12_QuanLiTinTuc
{
    public class TheLoai
    {
        [Key]
        public string MaTheLoai { get; set; }
        [Required]
        [MaxLength(50)]
        public string TenTheLoai { get; set; }
    }
}
