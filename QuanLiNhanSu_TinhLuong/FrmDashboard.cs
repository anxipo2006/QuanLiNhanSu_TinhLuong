using System;
using System.Windows.Forms;

namespace QuanLiNhanSu_TinhLuong
{
    public partial class FrmDashboard : Form
    {
        // Biến toàn cục lưu quyền của người dùng sau khi đăng nhập thành công
        private string quyenNguoiDung = "";

        // Constructor nhận tham số Role truyền sang từ Form Login
        public FrmDashboard(string role)
        {
            InitializeComponent();


            // Gán quyền được nạp từ màn hình đăng nhập vào biến nội bộ
            quyenNguoiDung = role != null ? role.Trim() : "";

            // HÀN CHẾT DÂY SỰ KIỆN CHO NÚT BẢNG LƯƠNG (Tránh đứt liên kết ngoài Designer)
            if (btnTinhLuong != null)
            {
                btnTinhLuong.Click -= btnTinhLuong_Click;
                btnTinhLuong.Click += btnTinhLuong_Click;
            }
        }

        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            // THỰC HIỆN PHÂN QUYỀN GIAO DIỆN KHI FORM ĐƯỢC MỞ LÊN
            if (quyenNguoiDung == "NhanVien")
            {
                // Cách 1: Vô hiệu hóa nút (Nút mờ đi, không click được nhưng vẫn thấy cấu trúc hệ thống)
                if (btnQuanLyNhanVien != null) btnQuanLyNhanVien.Enabled = false;
                if (btnTinhLuong != null) btnTinhLuong.Enabled = false;

                // Cách 2: Nếu bạn muốn ẩn hoàn toàn 2 nút này đi, hãy mở comment 2 dòng dưới:
                // if (btnQuanLyNhanVien != null) btnQuanLyNhanVien.Visible = false;
                // if (btnTinhLuong != null) btnTinhLuong.Visible = false;
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
            // Gọi form FrmBangLuong
            FrmBangLuong frm = new FrmBangLuong();
            frm.ShowDialog();
        }
    }
}