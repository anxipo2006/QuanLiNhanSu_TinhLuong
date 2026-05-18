using System;
using System.Collections.Generic;

namespace QuanLiNhanSu_TinhLuong.Models;

public partial class Nhanvien
{
    public int MaNv { get; set; }
    public string? Email { get; set; }
    public string HoTen { get; set; } = null!;

    public DateOnly? NgaySinh { get; set; }

    public string? GioiTinh { get; set; }

    public string? DiaChi { get; set; }

    public string? Sdt { get; set; }

    public int? MaPb { get; set; }

    public int? MaCv { get; set; }

    public decimal LuongCoBan { get; set; }
    public string? HinhAnh { get; set; } // Thêm dòng này để C# hiểu được cột Hình Ảnh

   // public string? Email { get; set; }

    public virtual ICollection<Bangluong> Bangluongs { get; set; } = new List<Bangluong>();

    public virtual ICollection<Chamcong> Chamcongs { get; set; } = new List<Chamcong>();

    public virtual Chucvu? MaCvNavigation { get; set; }

    public virtual Phongban? MaPbNavigation { get; set; }

    public virtual ICollection<Vipham> Viphams { get; set; } = new List<Vipham>();
}
