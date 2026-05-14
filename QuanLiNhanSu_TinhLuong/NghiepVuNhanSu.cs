using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using QuanLiNhanSu_TinhLuong.Data;
using QuanLiNhanSu_TinhLuong.Models;

namespace QuanLiNhanSu_TinhLuong
{
    public class NghiepVuNhanSu
    {
        // Hàm lấy danh sách nhân viên kèm theo TÊN phòng ban và TÊN chức vụ
        public List<Nhanvien> LayDanhSachNhanVienDayDu()
        {
            using (var context = new QuanlynhansuContext())
            {
                // Lệnh Include giúp kết nối sang bảng PhongBan và ChucVu để lấy tên
                return context.Nhanviens
                              .Include(nv => nv.MaPbNavigation)
                              .Include(nv => nv.MaCvNavigation)
                              .ToList();
            }
        }
    }
}