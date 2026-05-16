using OfficeOpenXml; // Bắt buộc phải có dòng này để dùng thư viện EPPlus
using System;
using System.ComponentModel;
using System.IO;

namespace QuanLiNhanSu_TinhLuong.Services
{
    // Cấp quyền kế thừa từ hợp đồng IBaoCao
    public class BaoCaoExcel : IBaoCao
    {
        public string XuatBaoCao(string tenNhanVien, string thangNam, decimal tongTien)
        {
            // Bắt buộc phải có dòng này khi dùng EPPlus bản mới
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string tenFile = $"PhieuLuong_EXCEL_{tenNhanVien.Replace(" ", "")}.xlsx";
            string duongDan = Path.Combine(desktopPath, tenFile);

            using (ExcelPackage package = new ExcelPackage())
            {
                var sheet = package.Workbook.Worksheets.Add("Phiếu Lương");

                // Vẽ định dạng phiếu lương theo mẫu công ty
                sheet.Cells["A1"].Value = "CÔNG TY TNHH B.A.H";
                sheet.Cells["A2"].Value = "PHIẾU THANH TOÁN LƯƠNG";
                sheet.Cells["A4"].Value = "Tháng:";
                sheet.Cells["B4"].Value = thangNam;
                sheet.Cells["A5"].Value = "Nhân viên:";
                sheet.Cells["B5"].Value = tenNhanVien;
                sheet.Cells["A6"].Value = "Thực lãnh:";
                sheet.Cells["B6"].Value = tongTien;

                FileInfo fi = new FileInfo(duongDan);
                package.SaveAs(fi);
            }

            return duongDan;
        }
    }
}