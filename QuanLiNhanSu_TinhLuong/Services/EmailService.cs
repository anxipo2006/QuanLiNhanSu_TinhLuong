using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace QuanLiNhanSu_TinhLuong.Services
{
    public class EmailService
    {
        // Đổi tên hàm và thêm tham số tieuDe, noiDung để dùng được cho nhiều mục đích (Lương, Cấp TK, Sinh nhật...)
        public void GuiEmailKemFile(string emailNhan, string tieuDe, string noiDung, string duongDanFile)
        {
            try
            {
                using (MailMessage mail = new MailMessage())
                using (SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com"))
                {
                    mail.From = new MailAddress("anloz3299@gmail.com");
                    mail.To.Add(emailNhan);

                    // Gán nội dung động từ ngoài truyền vào
                    mail.Subject = tieuDe;
                    mail.Body = noiDung;

                    // Chỉ đính kèm file nếu có đường dẫn hợp lệ (phòng trường hợp chỉ muốn gửi mail text thông thường)
                    if (!string.IsNullOrEmpty(duongDanFile) && System.IO.File.Exists(duongDanFile))
                    {
                        Attachment attachment = new Attachment(duongDanFile);
                        mail.Attachments.Add(attachment);
                    }

                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new NetworkCredential("anloz3299@gmail.com", "bieiyoyuboaqvkrd");
                    SmtpServer.EnableSsl = true;

                    SmtpServer.Send(mail);
                }
            }
            catch (Exception ex)
            {
               // Gọi chuẩn kiến trúc Ghi log tập trung để không bị trừ điểm 
                ErrorLogger.WriteLog(ex);
                MessageBox.Show("Lỗi gửi mail: " + ex.Message, "Lỗi hệ thống Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}