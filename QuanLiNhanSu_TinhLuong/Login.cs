using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiNhanSu_TinhLuong
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            // Bọc Try...Catch theo đúng Nhiệm vụ 4 của Nhóm trưởng
            try
            {
                using (var context = new QuanLiNhanSu_TinhLuong.Data.QuanlynhansuContext())
                {
                    string user = txtUsername.Text.Trim();
                    string pass = txtPassword.Text.Trim();

                    // Tìm tài khoản trong Database
                    var account = context.Accounts.FirstOrDefault(a => a.Username == user && a.Password == pass);

                    if (account != null)
                    {
                        MessageBox.Show($"Đăng nhập thành công! Xin chào {account.DisplayName}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Mở Form chính và truyền quyền (Role) qua
                        // Lưu ý: Đổi 'Form1' thành tên Form chính của bạn nếu cần
                        Form1 frm = new Form1(account.Role);
                        frm.Show();
                        this.Hide(); // Ẩn form login đi
                    }
                    else
                    {
                        MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                // Gọi hàm Ghi Log của Nhóm trưởng An viết sẵn
                QuanLiNhanSu_TinhLuong.Services.ErrorLogger.WriteLog(ex);
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu. Vui lòng xem log.txt!", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
