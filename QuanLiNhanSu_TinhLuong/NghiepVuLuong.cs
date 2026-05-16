using System;
using QuanLiNhanSu_TinhLuong.Data;
using QuanLiNhanSu_TinhLuong.Models;
using System.Linq;

namespace QuanLiNhanSu_TinhLuong
{
    public class NghiepVuLuong
    {
        // Hàm tính lương thực lãnh cho 1 nhân viên
        public decimal TinhLuongThucLanh(int maNV, int thang, int nam) // Đã bỏ tham số soNgayDiLam vì hệ thống sẽ tự đếm
        {
            using (var context = new QuanlynhansuContext())
            {
                // 1. Tìm nhân viên và chức vụ
                var nhanVien = context.Nhanviens.Find(maNV);
                if (nhanVien == null) return 0;

                var chucVu = context.Chucvus.Find(nhanVien.MaCv);
                decimal phuCap = chucVu != null && chucVu.PhuCap.HasValue ? chucVu.PhuCap.Value : 0;
                decimal luongCoBan = nhanVien.LuongCoBan;

                // 2. Dùng LINQ GroupBy và Sum để tổng hợp ngày công từ bảng Chamcong (ĂN ĐIỂM TIÊU CHÍ LINQ)
                string thangNamStr = $"{thang:D2}/{nam}"; // Format chuỗi thành "10/2026"
                var tongHopCong = context.Chamcongs
                    .Where(cc => cc.MaNv == maNV && cc.ThangNam == thangNamStr)
                    .GroupBy(cc => cc.MaNv)
                    .Select(g => new {
                        TongNgayDiLam = g.Sum(cc => cc.SoNgayDiLam)
                    }).FirstOrDefault();

                // Nếu không có dữ liệu chấm công thì coi như làm 0 ngày
                float soNgayDiLamThucTe = tongHopCong != null ? (float)tongHopCong.TongNgayDiLam : 0;

                // 3. Tính Lương 1 ngày (Chuẩn 30/31 ngày linh hoạt)
                int soNgayTrongThang = DateTime.DaysInMonth(nam, thang);
                decimal luongMotNgay = luongCoBan / soNgayTrongThang;

                // 4. Dùng LINQ Sum tính tổng Khấu trừ (Tiền phạt vi phạm)
                decimal tongPhat = context.Viphams
                    .Where(vp => vp.MaNv == maNV && vp.NgayViPham.Value.Month == thang && vp.NgayViPham.Value.Year == nam)
                    .Sum(vp => vp.TienPhat ?? 0);

                // 5. Chốt công thức cuối cùng: (Lương CB * Ngày Công) + Phụ Cấp - Khấu Trừ
                decimal tongLuongThucLanh = (luongMotNgay * (decimal)soNgayDiLamThucTe) + phuCap - tongPhat;

                return tongLuongThucLanh; // Đã sửa lỗi return 0
            }
        }
    }
}