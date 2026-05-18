using System;
using System.Linq;
using QuanLiNhanSu_TinhLuong.Data;
using QuanLiNhanSu_TinhLuong.Models;
using QuanLiNhanSu_TinhLuong.Services;

namespace QuanLiNhanSu_TinhLuong
{
    public class NghiepVuLuong
    {
        public decimal TinhVaLuuLuongThang(int maNV, int thang, int nam)
        {
            try
            {
                using (var context = new QuanlynhansuContext())
                {
                    var nhanVien = context.Nhanviens.Find(maNV);
                    if (nhanVien == null) return 0;

                    decimal phuCap = 0;
                    if (nhanVien.MaCv.HasValue)
                    {
                        var chucVu = context.Chucvus.Find(nhanVien.MaCv.Value);
                        if (chucVu != null && chucVu.PhuCap.HasValue)
                        {
                            phuCap = chucVu.PhuCap.Value;
                        }
                    }

                    // FIX LỖI 1: Tự động chuyển đổi năm (Nếu nhập 26 sẽ tự hiểu là 2026)
                    int namThucTe = nam < 100 ? 2000 + nam : nam;

                    DateOnly tuNgay = new DateOnly(namThucTe, thang, 1);
                    DateOnly denNgay = tuNgay.AddMonths(1).AddDays(-1);

                    var dsChamCong = context.Chamcongs
                        .Where(cc => cc.MaNv == maNV && cc.NgayChamCong >= tuNgay && cc.NgayChamCong <= denNgay)
                        .ToList();

                    int soNgayCoMat = dsChamCong.Count(cc => cc.TrangThai != null && cc.TrangThai.ToLower().Contains("mặt"));
                    int soNgayTre = dsChamCong.Count(cc => cc.TrangThai != null && cc.TrangThai.ToLower().Contains("trễ"));

                    float tongNgayCong = soNgayCoMat + soNgayTre;

                    // FIX LỖI 2: Luật công ty - Nếu tháng đó không đi làm ngày nào (0 công) thì cắt luôn Phụ cấp
                    if (tongNgayCong == 0)
                    {
                        phuCap = 0;
                    }

                    decimal luongCoBan = nhanVien.LuongCoBan;
                    decimal phatDiTre = soNgayTre * 50000m;
                    decimal tienBaoHiem = luongCoBan * 0.08m;
                    decimal khauTru = phatDiTre + tienBaoHiem;

                    // Tính lương thực nhận
                    decimal luongThucNhan = (luongCoBan / 30m) * (decimal)tongNgayCong + phuCap - khauTru;
                    if (luongThucNhan < 0) luongThucNhan = 0;

                    // Lưu định dạng chuỗi ThangNam nguyên bản theo UI (VD: 05/26)
                    string thangNamStr = $"{thang:D2}/{nam}";
                    var phieuLuongCu = context.Bangluongs.FirstOrDefault(bl => bl.MaNv == maNV && bl.ThangNam == thangNamStr);

                    if (phieuLuongCu != null)
                    {
                        phieuLuongCu.TongNgayCong = tongNgayCong;
                        phieuLuongCu.PhuCap = phuCap;
                        phieuLuongCu.KhauTru = khauTru;
                        phieuLuongCu.LuongThucNhan = luongThucNhan;
                    }
                    else
                    {
                        var phieuLuongMoi = new Bangluong
                        {
                            MaNv = maNV,
                            ThangNam = thangNamStr,
                            TongNgayCong = tongNgayCong,
                            PhuCap = phuCap,
                            KhauTru = khauTru,
                            LuongThucNhan = luongThucNhan
                        };
                        context.Bangluongs.Add(phieuLuongMoi);
                    }

                    context.SaveChanges();
                    return luongThucNhan;
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteLog(ex);
                return -1;
            }
        }
    }
}