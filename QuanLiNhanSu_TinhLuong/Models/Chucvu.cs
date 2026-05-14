using System;
using System.Collections.Generic;

namespace QuanLiNhanSu_TinhLuong.Models;

public partial class Chucvu
{
    public int MaCv { get; set; }

    public string TenCv { get; set; } = null!;

    public decimal? PhuCap { get; set; }

    public virtual ICollection<Nhanvien> Nhanviens { get; set; } = new List<Nhanvien>();
}
