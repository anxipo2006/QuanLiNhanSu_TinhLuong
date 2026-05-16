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
            // --- NHIỆM VỤ 3: BẮT LỖI BẰNG ERRORPROVIDER ---
            errorProvider1.Clear();
            bool hopLe = true;

            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                errorProvider1.SetError(txtHoTen, "Họ tên không được để trống!");
                hopLe = false;
            }

            if (numLuongCoBan.Value <= 0)
            {
                errorProvider1.SetError(numLuongCoBan, "Lương phải lớn hơn 0!");
                hopLe = false;
            }

            if (!hopLe) return;

            // --- NHIỆM VỤ 4: CHỐNG VĂNG BẰNG TRY...CATCH ---
            try
            {
                using (var context = new QuanlynhansuContext())
                {
                    var nvMoi = new Nhanvien
                    {
                        HoTen = txtHoTen.Text,
                        Sdt = txtSdt.Text,
                        DiaChi = txtDiaChi.Text,
                        LuongCoBan = numLuongCoBan.Value,
                        MaPb = cboPhongBan.SelectedValue != null ? (int?)cboPhongBan.SelectedValue : null,
                        MaCv = cboChucVu.SelectedValue != null ? (int?)cboChucVu.SelectedValue : null,
                        // Lưu tên file ảnh vào Database (Nhiệm vụ 2)
                        // Ghi chú: Nếu bảng Nhanvien của bạn chưa có cột Avatar thì hãy bỏ dòng dưới
                        // Avatar = tenFileAvatarMoi 
                    };

                    context.Nhanviens.Add(nvMoi);
                    context.SaveChanges();

                    MessageBox.Show("Thêm nhân viên thành công!");
                    LoadDuLieu();
                    tenFileAvatarMoi = ""; // Reset biến sau khi lưu
                }
            }
            catch (Exception ex)
            {
                QuanLiNhanSu_TinhLuong.Services.ErrorLogger.WriteLog(ex);
                MessageBox.Show("Lỗi hệ thống! Đã ghi log vào log.txt", "Lỗi");
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