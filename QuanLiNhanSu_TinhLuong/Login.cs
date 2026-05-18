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
            // Bọc Try...Catch theo đúng Nhiệm vụ 4 để ghi nhận ngoại lệ hệ thống
            try
            {
                using (var context = new QuanLiNhanSu_TinhLuong.Data.QuanlynhansuContext())
                {
                    string user = txtUsername.Text.Trim();
                    string pass = txtPassword.Text.Trim();

                    // Tìm tài khoản khớp thông tin trong Database Cloud
                    var account = context.Accounts.FirstOrDefault(a => a.Username == user && a.Password == pass);

                    if (account != null)
                    {
                        MessageBox.Show($"Đăng nhập thành công! Xin chào {account.DisplayName}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // CHỈNH SỬA TẠI ĐÂY: Chuyển hướng mở từ Form1 sang FrmDashboard và nạp quyền (Role) vào
                        FrmDashboard frm = new FrmDashboard(account.Role);
                        frm.Show();

                        this.Hide(); // Ẩn form login đi sau khi chuyển giao diện thành công
                    }
                    else
                    {
                        MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                // Gọi hàm Ghi Log tập trung vào file log.txt để đảm bảo tiêu chí xử lý ngoại lệ
                QuanLiNhanSu_TinhLuong.Services.ErrorLogger.WriteLog(ex);
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu. Vui lòng xem chi tiết tại file log.txt!", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra nhập liệu cơ bản tránh trường hợp chuỗi rỗng
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Username và Password!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var context = new QuanlynhansuContext())
                {
                    // 2. Kiểm tra xem tên đăng nhập đã tồn tại trong hệ thống chưa
                    var checkExist = context.Accounts.Any(a => a.Username == txtUsername.Text.Trim());
                    if (checkExist)
                    {
                        MessageBox.Show("Tài khoản này đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // 3. Tạo bản ghi tài khoản mới
                    var newAcc = new Account
                    {
                        Username = txtUsername.Text.Trim(),
                        Password = txtPassword.Text.Trim(),
                        DisplayName = txtUsername.Text.Trim(), // Tạm lấy Username làm tên hiển thị ban đầu
                        Role = "NhanVien" // Mặc định tất cả các tài khoản tự đăng ký mới đều gán quyền Nhân viên
                    };

                    context.Accounts.Add(newAcc);
                    context.SaveChanges();

                    MessageBox.Show("Đăng ký tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // Ghi nhận lỗi hệ thống phát sinh trong quá trình ghi dữ liệu xuống database
                QuanLiNhanSu_TinhLuong.Services.ErrorLogger.WriteLog(ex);
                MessageBox.Show("Lỗi đăng ký! Vui lòng kiểm tra lại trạng thái kết nối Database.", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2PanelMain_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}