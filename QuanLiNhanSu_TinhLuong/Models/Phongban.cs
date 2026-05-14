using System;
using System.Collections.Generic;

namespace QuanLiNhanSu_TinhLuong.Models;

public partial class Phongban
{
    public int MaPb { get; set; }

    public string TenPb { get; set; } = null!;

    public string? SoDienThoai { get; set; }

    public virtual ICollection<Nhanvien> Nhanviens { get; set; } = new List<Nhanvien>();
}
