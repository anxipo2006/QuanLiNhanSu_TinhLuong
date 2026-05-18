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
                string user = txtUsername.Text.Trim();
                string pass = txtPassword.Text.Trim();

                // =======================================================================
                // TRƯỜNG HỢP ĐẶC BIỆT: Tài khoản cố định admin / 1234
                // =======================================================================
                if (user == "admin" && pass == "1234")
                {
                    MessageBox.Show("Đăng nhập thành công! Xin chào Quản trị viên (Admin)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Vì không chứa đuôi @gmail.com nên quyền mặc định sẽ là Admin
                    string targetRole = "Admin";

                    FrmDashboard frm = new FrmDashboard(targetRole);
                    frm.Show();

                    this.Hide(); // Ẩn form login đi
                    return; // Dừng hàm lại tại đây, không cần chạy xuống kiểm tra Database nữa
                }

                // =======================================================================
                // TRƯỜNG HỢP THƯỜNG: Kiểm tra trong Database Cloud
                // =======================================================================
                using (var context = new QuanLiNhanSu_TinhLuong.Data.QuanlynhansuContext())
                {
                    // Tìm tài khoản khớp thông tin trong Database Cloud
                    var account = context.Accounts.FirstOrDefault(a => a.Username == user && a.Password == pass);

                    if (account != null)
                    {
                        string targetRole;

                        // LOGIC PHÂN QUYỀN VÀ HIỂN THỊ THÔNG BÁO TƯƠNG ỨNG
                        if (user.ToLower().EndsWith("@gmail.com"))
                        {
                            targetRole = "NhanVien";
                            // Hiển thị dòng thông báo đăng nhập thành công cho Nhân Viên
                            MessageBox.Show($"Đăng nhập thành công! Xin chào {account.DisplayName} (Nhân Viên)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            targetRole = "Admin";
                            // Hiển thị dòng thông báo đăng nhập thành công cho Admin
                            MessageBox.Show($"Đăng nhập thành công! Xin chào {account.DisplayName} (Admin)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        // Nạp quyền đã được tính toán vào Form Dashboard
                        FrmDashboard frm = new FrmDashboard(targetRole);
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
        private void guna2PanelMain_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}