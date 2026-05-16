using System;
using System.Collections.Generic;

namespace QuanLiNhanSu_TinhLuong.Models;

public partial class Vipham
{
    public int MaVp { get; set; }

    public int? MaNv { get; set; }

    public DateOnly? NgayViPham { get; set; }

    public string? LyDo { get; set; }

    public decimal? TienPhat { get; set; }

    public virtual Nhanvien? MaNvNavigation { get; set; }
}
