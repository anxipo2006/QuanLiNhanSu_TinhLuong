using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Drawing.Printing;
using System.IO;
using System.Reflection.Metadata;

namespace QuanLiNhanSu_TinhLuong.Services
{
    // Kế thừa hợp đồng IBaoCao
    public class BaoCaoPdf : IBaoCao
    {
        // Bắt buộc phải thực thi hàm XuatBaoCao đúng như hợp đồng đã ký
        public string XuatBaoCao(string tenNhanVien, string thangNam, decimal tongTien)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string tenFile = $"PhieuLuong_PDF_{tenNhanVien.Replace(" ", "")}.pdf";
            string duongDan = Path.Combine(desktopPath, tenFile);

            // Mở thư viện iTextSharp tạo PDF
            iTextSharp.text.Document doc = new iTextSharp.text.Document(PageSize.A5);
            PdfWriter.GetInstance(doc, new FileStream(duongDan, FileMode.Create));

            doc.Open();
            doc.Add(new Paragraph("CONG TY TNHH B.A.H"));
            doc.Add(new Paragraph($"Phieu luong thang: {thangNam}"));
            doc.Add(new Paragraph($"Nhan vien: {tenNhanVien}"));
            doc.Add(new Paragraph($"Tong thuc lanh: {tongTien:N0} VND"));
            doc.Close();

            return duongDan;
        }
    }
}