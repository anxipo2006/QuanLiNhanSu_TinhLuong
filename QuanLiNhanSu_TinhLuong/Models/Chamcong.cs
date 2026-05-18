using System;
using System.Collections.Generic;

namespace QuanLiNhanSu_TinhLuong.Models
{
    public partial class Chamcong
    {
        public int MaCc { get; set; }
        public int MaNv { get; set; }
        public DateOnly NgayChamCong { get; set; }
        public string TrangThai { get; set; } = null!;
        public string? GhiChu { get; set; }

        public virtual Nhanvien? MaNvNavigation { get; set; }
    }
}