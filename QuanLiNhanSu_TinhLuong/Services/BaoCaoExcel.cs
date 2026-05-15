using System;
using System.IO;

namespace QuanLiNhanSu_TinhLuong.Services
{
    // Cũng kế thừa từ hợp đồng IBaoCao
    public class BaoCaoExcel : IBaoCao
    {
        public string XuatBaoCao(string tenNhanVien, string thangNam, decimal tongTien)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string tenFile = $"PhieuLuong_EXCEL_{tenNhanVien.Replace(" ", "")}.xlsx";
            string duongDan = Path.Combine(desktopPath, tenFile);

            // TO DO: Thành viên 4 sẽ dùng thư viện EPPlus viết code tạo file Excel ở đây
            // ... (Code tạo file Excel) ...

            return duongDan;
        }
    }
}