using System;
using System.IO;

namespace QuanLiNhanSu_TinhLuong.Services
{
    // Bắt buộc phải là chữ 'static' để các bạn khác gọi thẳng tên class mà không cần 'new'
    public static class ErrorLogger
    {
        // Hàm nhận vào biến lỗi (Exception) và tự động ghi ra file
        public static void WriteLog(Exception ex)
        {
            try
            {
                // Lấy thư mục gốc của chương trình (nơi file .exe đang chạy)
                string thuMucGoc = AppDomain.CurrentDomain.BaseDirectory;
                string duongDanFile = Path.Combine(thuMucGoc, "log.txt");

                // Định dạng nội dung lỗi để thầy cô đọc dễ hiểu
                string noiDungLoi = $"[{DateTime.Now.ToString("dd/Ms    M/yyyy HH:mm:ss")}]" + Environment.NewLine +
                                    $"Lỗi: {ex.Message}" + Environment.NewLine +
                                    $"Chi tiết: {ex.StackTrace}" + Environment.NewLine +
                                    "--------------------------------------------------" + Environment.NewLine;

                // Hàm AppendAllText: Nếu chưa có file log.txt thì tự tạo, nếu có rồi thì ghi nối tiếp vào cuối
                File.AppendAllText(duongDanFile, noiDungLoi);
            }
            catch
            {
                // Ém lỗi: Đề phòng trường hợp ngay cả việc ghi file log cũng bị lỗi (đầy ổ cứng, mất quyền...)
                // thì phần mềm vẫn lẳng lặng chạy qua chứ không bị văng (crash)
            }
        }
    }
}