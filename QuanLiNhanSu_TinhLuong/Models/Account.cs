using System;
using System.Collections.Generic;

namespace QuanLiNhanSu_TinhLuong.Models;

public partial class Account
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? DisplayName { get; set; }

    public string? Role { get; set; }
}
