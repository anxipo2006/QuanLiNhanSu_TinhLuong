using System;
using System.Collections.Generic;

namespace QuanLiNhanSu_TinhLuong.Models;

public partial class Chamcong
{
    public int MaCc { get; set; }

    public int? MaNv { get; set; }

    public string ThangNam { get; set; } = null!;

    public float? SoNgayDiLam { get; set; }

    public virtual Nhanvien? MaNvNavigation { get; set; }
}
