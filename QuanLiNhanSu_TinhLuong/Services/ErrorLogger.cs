using System;
using System.IO;

namespace QuanLiNhanSu_TinhLuong.Services
{
    // BẮT BUỘC phải có chữ 'public static' ở đây
    public static class ErrorLogger
    {
        public static void WriteLog(Exception ex)
        {
            try
            {
                string thuMucGoc = AppDomain.CurrentDomain.BaseDirectory;
                string duongDanFile = Path.Combine(thuMucGoc, "log.txt");

                string noiDungLoi = $"[{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}]" + Environment.NewLine +
                                    $"Lỗi: {ex.Message}" + Environment.NewLine +
                                    $"Chi tiết: {ex.StackTrace}" + Environment.NewLine +
                                    "--------------------------------------------------" + Environment.NewLine;

                File.AppendAllText(duongDanFile, noiDungLoi);
            }
            catch
            {
                // Ém lỗi
            }
        }
    }
}