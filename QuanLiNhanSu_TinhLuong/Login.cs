using QuanLiNhanSu_TinhLuong.Data;
using QuanLiNhanSu_TinhLuong.Models;
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

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            /// 1. Kiểm tra nhập liệu cơ bản
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Username và Password!", "Thông báo");
                return;
            }

            try
            {
                using (var context = new QuanlynhansuContext())
                {
                    // 2. Kiểm tra xem tên đăng nhập đã tồn tại chưa
                    var checkExist = context.Accounts.Any(a => a.Username == txtUsername.Text.Trim());
                    if (checkExist)
                    {
                        MessageBox.Show("Tài khoản này đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // 3. Tạo tài khoản mới
                    var newAcc = new Account
                    {
                        Username = txtUsername.Text.Trim(),
                        Password = txtPassword.Text.Trim(), // Lưu ý: thực tế nên mã hóa pass, nhưng đồ án thì để vầy cũng được
                        DisplayName = txtUsername.Text.Trim(), // Tạm lấy User làm tên hiển thị
                        Role = "NhanVien" // Mặc định đăng ký mới là Nhân viên
                    };

                    context.Accounts.Add(newAcc);
                    context.SaveChanges();

                    MessageBox.Show("Đăng ký tài khoản thành công!", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                // Ghi log lỗi nếu có biến cố (Nhiệm vụ 4)
                QuanLiNhanSu_TinhLuong.Services.ErrorLogger.WriteLog(ex);
                MessageBox.Show("Lỗi đăng ký! Vui lòng kiểm tra lại Database.", "Lỗi hệ thống");
            }
        }
    }
}
