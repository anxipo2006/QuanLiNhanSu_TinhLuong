using System;
using QuanLiNhanSu_TinhLuong.Data;
using QuanLiNhanSu_TinhLuong.Models;
using System.Linq;

namespace QuanLiNhanSu_TinhLuong
{
    public class NghiepVuLuong
    {
        // Hàm tính lương thực lãnh cho 1 nhân viên
        public decimal TinhLuongThucLanh(int maNV, int thang, int nam, float soNgayDiLam)
        {
            using (var context = new QuanlynhansuContext())
            {
                // 1. Tìm nhân viên và chức vụ để lấy Lương Cơ Bản và Phụ Cấp
                var nhanVien = context.Nhanviens.Find(maNV);
                if (nhanVien == null) return 0;

                var chucVu = context.Chucvus.Find(nhanVien.MaCv);
                decimal phuCap = chucVu != null && chucVu.PhuCap.HasValue ? chucVu.PhuCap.Value : 0;

                // 2. Lấy Lương cơ bản
                decimal luongCoBan = nhanVien.LuongCoBan;

                // 3. Xác định số ngày thực tế của tháng đó (sẽ tự động ra 30 hoặc 31 ngày, tháng 2 thì 28/29 ngày)
                int soNgayTrongThang = DateTime.DaysInMonth(nam, thang);

                // 4. Áp dụng công thức
                // Tiền 1 ngày = Lương cơ bản / Số ngày chuẩn của tháng
                decimal luongMotNgay = luongCoBan / soNgayTrongThang;

                // Tổng lương = (Lương 1 ngày * số ngày đi làm) + Phụ cấp
                decimal tongLuong = (luongMotNgay * (decimal)soNgayDiLam) + phuCap;

                return Math.Round(tongLuong, 0); // Làm tròn số cho đẹp
            }
        }
    }
}