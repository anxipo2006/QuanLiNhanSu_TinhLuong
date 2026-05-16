using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms; // Thêm dòng này để dùng được MessageBox

namespace QuanLiNhanSu_TinhLuong.Services
{
    public class EmailService
    {
        public void GuiEmailPhieuLuong(string emailNhan, string tenFilePdf, string duongDanFile)
        {
            try
            {
                // Dùng từ khóa 'using' để tự động giải phóng tài nguyên và nhả file khi xong việc
                using (MailMessage mail = new MailMessage())
                using (SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com"))
                {
                    mail.From = new MailAddress("anloz3299@gmail.com");
                    mail.To.Add(emailNhan);
                    mail.Subject = "Thông báo Lương tháng này";
                    mail.Body = "Chào bạn, đính kèm là phiếu lương chi tiết tháng này.";

                    using (Attachment attachment = new Attachment(duongDanFile))
                    {
                        mail.Attachments.Add(attachment);

                        SmtpServer.Port = 587;
                        // CHÚ Ý DÒNG DƯỚI NÀY:
                        SmtpServer.Credentials = new NetworkCredential("anloz3299@gmail.com", "bieiyoyuboaqvkrd");
                        SmtpServer.EnableSsl = true;

                        SmtpServer.Send(mail);
                    }
                }
            }
            catch (Exception ex)
            {
                // Thay vì Console.WriteLine, bật hẳn thông báo lên cho dễ thấy lỗi
                MessageBox.Show("Lỗi gửi mail: " + ex.Message, "Lỗi hệ thống Email");
            }
        }
    }
}