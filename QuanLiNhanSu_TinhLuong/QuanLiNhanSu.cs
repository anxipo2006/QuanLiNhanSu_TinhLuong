using QuanLiNhanSu_TinhLuong.Data;
using QuanLiNhanSu_TinhLuong.Models;
using QuanLiNhanSu_TinhLuong.Services;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiNhanSu_TinhLuong
{
    public partial class QuanLiNhanSu : Form
    {
        private string tenFileAvatarMoi = "";

        public QuanLiNhanSu()
        {
            InitializeComponent();
        }

        private void QuanLiNhanSu_Load(object sender, EventArgs e)
        {
            LoadDuLieu();
        }

        // TỐI ƯU 1: Load dữ liệu gọn gàng, sử dụng chung Context cho các thao tác đọc
        private void LoadDuLieu()
        {
            try
            {
                using (var context = new QuanlynhansuContext())
                {
                    cboPhongBan.DataSource = context.Phongbans.ToList();
                    cboPhongBan.DisplayMember = "TenPb";
                    cboPhongBan.ValueMember = "MaPb";

                    cboChucVu.DataSource = context.Chucvus.ToList();
                    cboChucVu.DisplayMember = "TenCv";
                    cboChucVu.ValueMember = "MaCv";

                    dgvNhanVien.DataSource = context.Nhanviens.Select(nv => new
                    {
                        nv.MaNv,
                        nv.HoTen,
                        nv.Sdt,
                        nv.DiaChi,
                        nv.LuongCoBan,
                        MaPb = nv.MaPb,
                        MaCv = nv.MaCv,
                        TenPhong = nv.MaPbNavigation != null ? nv.MaPbNavigation.TenPb : "Chưa xếp phòng",
                        TenChucVu = nv.MaCvNavigation != null ? nv.MaCvNavigation.TenCv : "Chưa xếp chức vụ"
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteLog(ex);
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // TỐI ƯU 2: Quản lý bộ nhớ nghiêm ngặt cho OpenFileDialog
        private void btnChọnAnh_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog open = new OpenFileDialog { Filter = "Image Files|*.jpg;*.jpeg;*.gif;*.bmp;*.png" })
                {
                    if (open.ShowDialog() == DialogResult.OK)
                    {
                        // Giải phóng ảnh cũ nếu có trước khi gán ảnh mới để tránh tràn RAM
                        if (picAvatar.Image != null) picAvatar.Image.Dispose();
                        picAvatar.Image = new Bitmap(open.FileName);

                        string thuMucImages = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");
                        if (!Directory.Exists(thuMucImages)) Directory.CreateDirectory(thuMucImages);

                        tenFileAvatarMoi = Path.GetFileName(open.FileName);
                        string duongDanLuuDich = Path.Combine(thuMucImages, tenFileAvatarMoi);

                        File.Copy(open.FileName, duongDanLuuDich, true);
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteLog(ex);
                MessageBox.Show("Lỗi tải ảnh lên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // TỐI ƯU 3: Bất đồng bộ (Async/Await) chống đơ ứng dụng khi gửi Email
        private async void btnThem_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                errorProvider1.SetError(txtHoTen, "Họ tên không được để trống!");
                return;
            }

            try
            {
                string emailNhanVien = txtHoTen.Text.Trim().Replace(" ", "").ToLower() + "@bah.com";
                string passwordMacDinh = "123456";
                string hoTenTrimmed = txtHoTen.Text.Trim();

                using (var context = new QuanlynhansuContext())
                {
                    var nvMoi = new Nhanvien
                    {
                        HoTen = hoTenTrimmed,
                        Sdt = txtSdt.Text.Trim(),
                        DiaChi = txtDiaChi.Text.Trim(),
                        Email = emailNhanVien,
                        LuongCoBan = numLuongCoBan.Value,
                        MaPb = cboPhongBan.SelectedValue as int?,
                        MaCv = cboChucVu.SelectedValue as int?
                    };

                    context.Nhanviens.Add(nvMoi);

                    var tkMoi = new Account
                    {
                        Username = emailNhanVien,
                        Password = passwordMacDinh,
                        DisplayName = hoTenTrimmed,
                        Role = "NhanVien"
                    };
                    context.Accounts.Add(tkMoi);

                    context.SaveChanges();
                }

                // Chạy tác vụ gửi mail ở luồng nền (Background Thread) để UI không bị treo
                await Task.Run(() =>
                {
                    string pathHuongDan = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "HuongDanHeThong.txt");
                    File.WriteAllText(pathHuongDan, $"Chao mung den BAH. Tai khoan: {emailNhanVien} | Mat khau: {passwordMacDinh}");

                    EmailService emailService = new EmailService();
                    emailService.GuiEmailKemFile(emailNhanVien, "Cap Tai Khoan - BAH", $"Chao {hoTenTrimmed}. Thong tin o file dinh kem.", pathHuongDan);
                });

                MessageBox.Show("Thêm nhân viên và gửi email thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadDuLieu();
                XoaTrangForm();
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteLog(ex);
                MessageBox.Show("Lỗi hệ thống khi lưu: " + ex.Message, "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // HÀM TIỆN ÍCH DÙNG CHUNG: Loại bỏ code lặp kiểm tra dòng đang chọn
        private int? LayMaNhanVienDangChon()
        {
            if (dgvNhanVien.CurrentRow == null || dgvNhanVien.CurrentRow.Index < 0)
            {
                MessageBox.Show("Vui lòng chọn một nhân viên trên bảng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            return (int)dgvNhanVien.CurrentRow.Cells["MaNv"].Value;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int? maNV = LayMaNhanVienDangChon();
            if (maNV == null) return;

            try
            {
                using (var context = new QuanlynhansuContext())
                {
                    var nv = context.Nhanviens.Find(maNV.Value);
                    if (nv != null)
                    {
                        nv.HoTen = txtHoTen.Text.Trim();
                        nv.Sdt = txtSdt.Text.Trim();
                        nv.DiaChi = txtDiaChi.Text.Trim();
                        nv.LuongCoBan = numLuongCoBan.Value;
                        nv.MaPb = cboPhongBan.SelectedValue as int?;
                        nv.MaCv = cboChucVu.SelectedValue as int?;

                        context.SaveChanges();
                        MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadDuLieu();
                        XoaTrangForm();
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteLog(ex);
                MessageBox.Show("Lỗi cập nhật dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int? maNV = LayMaNhanVienDangChon();
            if (maNV == null) return;

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (var context = new QuanlynhansuContext())
                    {
                        var nv = context.Nhanviens.Find(maNV.Value);
                        if (nv != null)
                        {
                            context.Nhanviens.Remove(nv);
                            context.SaveChanges();

                            MessageBox.Show("Xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDuLieu();
                            XoaTrangForm();
                        }
                    }
                }
                catch (Exception ex)
                {
                    ErrorLogger.WriteLog(ex);
                    MessageBox.Show("Không thể xóa do ràng buộc dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // TỐI ƯU 4: An toàn khi trích xuất dữ liệu từ lưới (Tránh lỗi Null Reference)
        private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvNhanVien.Rows[e.RowIndex];
                txtHoTen.Text = row.Cells["HoTen"].Value?.ToString() ?? "";
                txtSdt.Text = row.Cells["Sdt"].Value?.ToString() ?? "";
                txtDiaChi.Text = row.Cells["DiaChi"].Value?.ToString() ?? "";

                if (decimal.TryParse(row.Cells["LuongCoBan"].Value?.ToString(), out decimal luong))
                    numLuongCoBan.Value = luong;

                if (row.Cells["MaPb"].Value != null)
                    cboPhongBan.SelectedValue = row.Cells["MaPb"].Value;

                if (row.Cells["MaCv"].Value != null)
                    cboChucVu.SelectedValue = row.Cells["MaCv"].Value;
            }
        }

        private void XoaTrangForm()
        {
            txtHoTen.Clear();
            txtSdt.Clear();
            txtDiaChi.Clear();
            numLuongCoBan.Value = 0;
            if (picAvatar.Image != null)
            {
                picAvatar.Image.Dispose();
                picAvatar.Image = null;
            }
        }
    }
}