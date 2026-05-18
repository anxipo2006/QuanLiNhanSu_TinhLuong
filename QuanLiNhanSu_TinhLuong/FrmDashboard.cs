using System;
using System.Windows.Forms;

namespace QuanLiNhanSu_TinhLuong
{
    public partial class FrmDashboard : Form
    {
        // 1. Khai báo biến
        private string quyenNguoiDung = "";

        // 2. Nhét string role vào đây
        public FrmDashboard(string role)
        {
            InitializeComponent();
            quyenNguoiDung = role;

            // HÀN CHẾT DÂY SỰ KIỆN CHO NÚT BẢNG LƯƠNG (Chống đứt dây ngoài Designer)
            // Lưu ý: Đảm bảo nút ngoài giao diện của bạn tên là btnTinhLuong
            if (btnTinhLuong != null)
            {
                btnTinhLuong.Click -= btnTinhLuong_Click;
                btnTinhLuong.Click += btnTinhLuong_Click;
            }
        }

        private void btnQuanLyNhanVien_Click(object sender, EventArgs e)
        {
            // Gọi form FrmNhanVien (chứa sơ đồ TreeView và danh sách)
            FrmNhanVien frm = new FrmNhanVien();
            frm.ShowDialog();
        }

        private void btnChamCong_Click(object sender, EventArgs e)
        {
            // Gọi form FrmChamCong
            FrmChamCong frm = new FrmChamCong();
            frm.ShowDialog();
        }

        private void btnTinhLuong_Click(object sender, EventArgs e)
        {
            // GỌI FORM BẢNG LƯƠNG MỚI CHUẨN XỊN (Đã bỏ dấu //)
            FrmBangLuong frm = new FrmBangLuong();
            frm.ShowDialog();
        }

        private void FrmDashboard_Load(object sender, EventArgs e)
        {

        }
    }
}