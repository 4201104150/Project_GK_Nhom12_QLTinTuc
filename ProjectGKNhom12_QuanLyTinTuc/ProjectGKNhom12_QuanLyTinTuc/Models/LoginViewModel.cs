using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectGKNhom12_QuanLyTinTuc.Models
{
    public class LoginViewModel
    {
        public string MaNguoiDung { get; set; }
        [DataType(DataType.Password)]
        public string matKhau { get; set; }
    }
}
