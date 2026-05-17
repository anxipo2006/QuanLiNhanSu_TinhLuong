using QuanLiNhanSu_TinhLuong.Data;
using QuanLiNhanSu_TinhLuong.Models;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuanLiNhanSu_TinhLuong
{
    public partial class QuanLiNhanSu : Form
    {
        // Biến lưu tên file ảnh để dùng khi bấm nút Lưu
        string tenFileAvatarMoi = "";

        public QuanLiNhanSu()
        {
            InitializeComponent();
        }

        private void QuanLiNhanSu_Load(object sender, EventArgs e)
        {
            LoadDuLieu();
        }

        private void LoadDuLieu()
        {
            try
            {
                using (var context = new QuanlynhansuContext())
                {
                    cboPhongBan.DisplayMember = "TenPb";
                    cboPhongBan.ValueMember = "MaPb";
                    cboPhongBan.DataSource = context.Phongbans.ToList();

                    cboChucVu.DisplayMember = "TenCv";
                    cboChucVu.ValueMember = "MaCv";
                    cboChucVu.DataSource = context.Chucvus.ToList();

                    dgvNhanVien.DataSource = context.Nhanviens.Select(nv => new
                    {
                        nv.MaNv,
                        nv.HoTen,
                        nv.Sdt,
                        nv.DiaChi,
                        nv.LuongCoBan,
                        MaPb = nv.MaPb,
                        MaCv = nv.MaCv,
                        TenPhong = nv.MaPbNavigation != null ? nv.MaPbNavigation.TenPb : "",
                        TenChucVu = nv.MaCvNavigation != null ? nv.MaCvNavigation.TenCv : ""
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                // Ghi log lỗi nếu không load được dữ liệu
                QuanLiNhanSu_TinhLuong.Services.ErrorLogger.WriteLog(ex);
            }
        }

        private void btnChọnAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";

            if (open.ShowDialog() == DialogResult.OK)
            {
                picAvatar.Image = new Bitmap(open.FileName);

                string thuMucGoc = AppDomain.CurrentDomain.BaseDirectory;
                string thuMucImages = System.IO.Path.Combine(thuMucGoc, "Images");

                if (!System.IO.Directory.Exists(thuMucImages))
                {
                    System.IO.Directory.CreateDirectory(thuMucImages);
                }

                // Lưu tên file vào biến để lát nữa cất vào Database
                tenFileAvatarMoi = System.IO.Path.GetFileName(open.FileName);
                string duongDanLuuDich = System.IO.Path.Combine(thuMucImages, tenFileAvatarMoi);

                System.IO.File.Copy(open.FileName, duongDanLuuDich, true);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Bước 1: Bắt lỗi nhập liệu bằng ErrorProvider (Nhiệm vụ 3)
            errorProvider1.Clear();
            bool hopLe = true;

            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                errorProvider1.SetError(txtHoTen, "Họ tên không được trống!");
                hopLe = false;
            }

            // Nếu trên giao diện có ô txtEmail thì bắt lỗi rỗng luôn
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                errorProvider1.SetError(txtEmail, "Email không được trống!");
                hopLe = false;
            }

            if (!hopLe) return; // Có lỗi thì dừng lại, không lưu

            // Bước 2: Chạy luồng lưu dữ liệu và gửi mail liên hoàn (Nhiệm vụ 4)
            try
            {
                using (var context = new QuanLiNhanSu_TinhLuong.Data.QuanlynhansuContext())
                {
                    // 2.1. Tạo và thêm Nhân viên mới vào DB (Đồng bộ đúng theo Model thực tế của ba)
                    var nvMoi = new QuanLiNhanSu_TinhLuong.Models.Nhanvien
                    {
                        HoTen = txtHoTen.Text.Trim(),
                        Email = txtEmail.Text.Trim(),
                        LuongCoBan = numLuongCoBan.Value,    // Lấy giá trị từ ô numeric lương của ba
                        MaPb = cboPhongBan.SelectedValue != null ? (int?)cboPhongBan.SelectedValue : null,
                        MaCv = cboChucVu.SelectedValue != null ? (int?)cboChucVu.SelectedValue : null
                    };

                    context.Nhanviens.Add(nvMoi);
                    context.SaveChanges(); // Lệnh này giúp MySQL sinh ra MaNV tự động

                    // 2.2. TỰ ĐỘNG SINH TÀI KHOẢN TƯƠNG ỨNG CHO NHÂN VIÊN MỚI
                    var tkMoi = new QuanLiNhanSu_TinhLuong.Models.Account
                    {
                        Username = nvMoi.Email,             // Lấy Email làm tên đăng nhập
                        Password = "123456",                // Mật khẩu mặc định ban đầu
                        DisplayName = nvMoi.HoTen,          // Tên hiển thị là tên nhân viên
                        Role = "NhanVien"                   // Mặc định quyền là Nhân viên
                    };

                    context.Accounts.Add(tkMoi);
                    context.SaveChanges(); // Lưu tài khoản vào bảng Account

                    // 2.3. TẠO FILE ĐÍNH KÈM VÀ GỌI EMAIL SERVICE ĐỂ GỬI MAIL
                    string pathHuongDan = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "HuongDanHeThong.txt");
                    System.IO.File.WriteAllText(pathHuongDan, "Chao mung ban den voi cong ty. Tai khoan cua ban la: " + tkMoi.Username + " | Mat khau: 123456");

                    // Khởi tạo tầng dịch vụ email của An
                    QuanLiNhanSu_TinhLuong.Services.EmailService emailService = new QuanLiNhanSu_TinhLuong.Services.EmailService();

                    // CHUẨN NÈ: Truyền đúng 4 tham số như hàm GuiEmailKemFile yêu cầu
                    string tieuDeMail = "Thong Bao Cap Tai Khoan Nhan Vien Moi";
                    string noiDungMail = $"Chao mung {nvMoi.HoTen} tham gia vao cong ty. Thong tin tai khoan he thong cua ban duoc gui trong file dinh kem.";

                    emailService.GuiEmailKemFile(nvMoi.Email, tieuDeMail, noiDungMail, pathHuongDan);

                    MessageBox.Show("Thêm nhân viên và cấp tài khoản tự động thành công! Đã gửi email kích hoạt.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Lưu xong load lại bảng và đóng form cho chuyên nghiệp
                    LoadDuLieu();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                // Ghi log lỗi tự động bằng ErrorLogger tập trung của An
                QuanLiNhanSu_TinhLuong.Services.ErrorLogger.WriteLog(ex);
                MessageBox.Show("Lỗi hệ thống khi tạo nhân sự. Chi tiết đã được ghi vào log.txt!", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.CurrentRow == null) return;
            int maNV = (int)dgvNhanVien.CurrentRow.Cells["MaNv"].Value;

            try
            {
                using (var context = new QuanlynhansuContext())
                {
                    var nv = context.Nhanviens.Find(maNV);
                    if (nv != null)
                    {
                        nv.HoTen = txtHoTen.Text;
                        nv.Sdt = txtSdt.Text;
                        nv.DiaChi = txtDiaChi.Text;
                        nv.LuongCoBan = numLuongCoBan.Value;
                        nv.MaPb = cboPhongBan.SelectedValue != null ? (int?)cboPhongBan.SelectedValue : null;
                        nv.MaCv = cboChucVu.SelectedValue != null ? (int?)cboChucVu.SelectedValue : null;

                        context.SaveChanges();
                        MessageBox.Show("Cập nhật thành công!");
                        LoadDuLieu();
                    }
                }
            }
            catch (Exception ex)
            {
                QuanLiNhanSu_TinhLuong.Services.ErrorLogger.WriteLog(ex);
                MessageBox.Show("Có lỗi xảy ra khi sửa!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.CurrentRow == null) return;
            DialogResult result = MessageBox.Show("Xác nhận xóa?", "Xác nhận", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                try
                {
                    int maNV = (int)dgvNhanVien.CurrentRow.Cells["MaNv"].Value;
                    using (var context = new QuanlynhansuContext())
                    {
                        var nv = context.Nhanviens.Find(maNV);
                        if (nv != null)
                        {
                            context.Nhanviens.Remove(nv);
                            context.SaveChanges();
                            LoadDuLieu();
                        }
                    }
                }
                catch (Exception ex)
                {
                    QuanLiNhanSu_TinhLuong.Services.ErrorLogger.WriteLog(ex);
                }
            }
        }

        private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvNhanVien.Rows[e.RowIndex];
                txtHoTen.Text = row.Cells["HoTen"].Value?.ToString();
                txtSdt.Text = row.Cells["Sdt"].Value?.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value?.ToString();

                if (row.Cells["LuongCoBan"].Value != null)
                    numLuongCoBan.Value = Convert.ToDecimal(row.Cells["LuongCoBan"].Value);

                if (row.Cells["MaPb"].Value != null)
                    cboPhongBan.SelectedValue = row.Cells["MaPb"].Value;

                if (row.Cells["MaCv"].Value != null)
                    cboChucVu.SelectedValue = row.Cells["MaCv"].Value;
            }
        }
    }
}