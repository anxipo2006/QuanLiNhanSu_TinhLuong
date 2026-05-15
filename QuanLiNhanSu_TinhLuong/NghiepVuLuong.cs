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
                // 5. Tính tổng tiền phạt trong tháng của nhân viên đó
                decimal tongPhat = context.Viphams
                                   .Where(vp => vp.MaNv == maNV && vp.NgayViPham.Value.Month == thang)
                                   .Sum(vp => vp.TienPhat ?? 0);

                // 6. Tổng lương thực lãnh cuối cùng
                decimal tongLuongThucLanh = (luongMotNgay * (decimal)soNgayDiLam) + phuCap - tongPhat;
            }
            return 0;
        }
    }
}