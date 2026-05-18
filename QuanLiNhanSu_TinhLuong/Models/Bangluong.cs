using System;
using System.Collections.Generic;

namespace QuanLiNhanSu_TinhLuong.Models
{
    public partial class Bangluong
    {
        public int MaBl { get; set; }
        public int MaNv { get; set; }
        public string ThangNam { get; set; } = null!;
        public float TongNgayCong { get; set; }
        public decimal? PhuCap { get; set; }
        public decimal? KhauTru { get; set; }
        public decimal LuongThucNhan { get; set; }

        public virtual Nhanvien? MaNvNavigation { get; set; }
    }
}