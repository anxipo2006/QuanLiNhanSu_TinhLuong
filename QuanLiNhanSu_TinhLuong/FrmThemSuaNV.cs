using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLiNhanSu_TinhLuong.Data;
using QuanLiNhanSu_TinhLuong.Models;
using QuanLiNhanSu_TinhLuong.Services;

namespace QuanLiNhanSu_TinhLuong
{
    public partial class FrmThemSuaNV : Form
    {
        private string tenFileAnhDaLuu = "";
        private int maNVDangSua = -1;

        public FrmThemSuaNV()
        {
            InitializeComponent();
            NapDuLieuCombobox();
            HanCheSuKien();
        }

        public FrmThemSuaNV(int maNV)
        {
            InitializeComponent();
            maNVDangSua = maNV;
            NapDuLieuCombobox();
            HanCheSuKien();
            LoadDuLieuNhanVienCu();
        }

        private void HanCheSuKien()
        {
            try
            {
                if (tabControl1 != null && tabControl1.TabCount > 1)
                    tabControl1.TabPages[1].Text = "Hợp đồng lao động";
            }
            catch { }

            if (btnLuu != null)
            {
                btnLuu.Click -= btnLuu_Click;
                btnLuu.Click += btnLuu_Click;
            }
        }

        private void NapDuLieuCombobox()
        {
            try
            {
                using (var context = new QuanlynhansuContext())
                {
                    if (cboPhongBan != null)
                    {
                        cboPhongBan.DisplayMember = "TenPb";
                        cboPhongBan.ValueMember = "MaPb";
                        cboPhongBan.DataSource = context.Phongbans.ToList();
                    }

                    if (cboChucVu != null)
                    {
                        cboChucVu.DisplayMember = "TenCv";
                        cboChucVu.ValueMember = "MaCv";
                        cboChucVu.DataSource = context.Chucvus.ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nạp danh sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDuLieuNhanVienCu()
        {
            if (maNVDangSua == -1) return;
            try
            {
                using (var context = new QuanlynhansuContext())
                {
                    var nv = context.Nhanviens.Find(maNVDangSua);
                    if (nv != null)
                    {
                        if (txtName != null) txtName.Text = nv.HoTen;
                        if (txtSoDienThoai != null) txtSoDienThoai.Text = nv.Sdt;
                        if (txtDiaChi != null) txtDiaChi.Text = nv.DiaChi;
                        if (txtEmail != null) txtEmail.Text = nv.Email;
                        if (txtLuong != null) txtLuong.Text = nv.LuongCoBan.ToString();

                        if (dtpBirth != null && nv.NgaySinh.HasValue)
                            dtpBirth.Value = nv.NgaySinh.Value.ToDateTime(TimeOnly.MinValue);

                        if (cboPhongBan != null && nv.MaPb != null) cboPhongBan.SelectedValue = nv.MaPb;
                        if (cboChucVu != null && nv.MaCv != null) cboChucVu.SelectedValue = nv.MaCv;

                        if (nv.GioiTinh == "Nam" && rdoNam != null) rdoNam.Checked = true;
                        else if (nv.GioiTinh == "Nữ" && rdoNu != null) rdoNu.Checked = true;

                        if (!string.IsNullOrEmpty(nv.HinhAnh))
                        {
                            string pathAnh = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", nv.HinhAnh);
                            if (File.Exists(pathAnh) && picAvatar != null)
                            {
                                picAvatar.Image = new Bitmap(pathAnh);
                                picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
                                tenFileAnhDaLuu = nv.HinhAnh;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteLog(ex);
            }
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog open = new OpenFileDialog { Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp" })
                {
                    if (open.ShowDialog() == DialogResult.OK)
                    {
                        if (picAvatar != null && picAvatar.Image != null) picAvatar.Image.Dispose();

                        if (picAvatar != null)
                        {
                            picAvatar.Image = new Bitmap(open.FileName);
                            picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
                        }

                        string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");
                        if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);

                        tenFileAnhDaLuu = "Avatar_" + DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(open.FileName);
                        File.Copy(open.FileName, Path.Combine(folderPath, tenFileAnhDaLuu), true);
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteLog(ex);
                MessageBox.Show("Lỗi chọn hình ảnh!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtName == null || string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Họ tên không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal luong = 0;
            if (txtLuong != null) decimal.TryParse(txtLuong.Text.Trim(), out luong);

            string gioiTinh = "Khác";
            if (rdoNam != null && rdoNam.Checked) gioiTinh = "Nam";
            else if (rdoNu != null && rdoNu.Checked) gioiTinh = "Nữ";

            string emailNV = txtName.Text.Trim().Replace(" ", "").ToLower() + "@bah.com";
            if (txtEmail != null && !string.IsNullOrWhiteSpace(txtEmail.Text))
                emailNV = txtEmail.Text.Trim();

            try
            {
                using (var context = new QuanlynhansuContext())
                {
                    if (maNVDangSua == -1)
                    {
                        var nvMoi = new Nhanvien
                        {
                            HoTen = txtName.Text.Trim(),
                            GioiTinh = gioiTinh,
                            Sdt = txtSoDienThoai != null ? txtSoDienThoai.Text.Trim() : null,
                            DiaChi = txtDiaChi != null ? txtDiaChi.Text.Trim() : null,
                            Email = emailNV,
                            NgaySinh = dtpBirth != null ? DateOnly.FromDateTime(dtpBirth.Value) : null,
                            LuongCoBan = luong,
                            MaPb = cboPhongBan != null ? cboPhongBan.SelectedValue as int? : null,
                            MaCv = cboChucVu != null ? cboChucVu.SelectedValue as int? : null,
                            HinhAnh = tenFileAnhDaLuu
                        };

                        context.Nhanviens.Add(nvMoi);

                        var tkMoi = new Account
                        {
                            Username = emailNV,
                            Password = "123456",
                            DisplayName = nvMoi.HoTen,
                            Role = "NhanVien"
                        };
                        context.Accounts.Add(tkMoi);
                        context.SaveChanges();

                        await Task.Run(() =>
                        {
                            string pathHuongDan = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "HuongDan.txt");
                            File.WriteAllText(pathHuongDan, $"Tai khoan: {tkMoi.Username} | Pass: 123456");
                            EmailService es = new EmailService();
                            es.GuiEmailKemFile(emailNV, "Cap Tai Khoan Nhan Vien", "Thong tin mat khau duoc dinh kem.", pathHuongDan);
                        });

                        MessageBox.Show("Thêm mới thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        var nvUpdate = context.Nhanviens.Find(maNVDangSua);
                        if (nvUpdate != null)
                        {
                            nvUpdate.HoTen = txtName.Text.Trim();
                            nvUpdate.GioiTinh = gioiTinh;
                            if (txtSoDienThoai != null) nvUpdate.Sdt = txtSoDienThoai.Text.Trim();
                            if (txtDiaChi != null) nvUpdate.DiaChi = txtDiaChi.Text.Trim();
                            nvUpdate.Email = emailNV;
                            if (dtpBirth != null) nvUpdate.NgaySinh = DateOnly.FromDateTime(dtpBirth.Value);
                            nvUpdate.LuongCoBan = luong;
                            if (cboPhongBan != null) nvUpdate.MaPb = cboPhongBan.SelectedValue as int?;
                            if (cboChucVu != null) nvUpdate.MaCv = cboChucVu.SelectedValue as int?;
                            nvUpdate.HinhAnh = tenFileAnhDaLuu;

                            context.SaveChanges();
                            MessageBox.Show("Cập nhật thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteLog(ex);

                // BẬC THẦY BẮT LỖI: Lấy thông tin InnerException hiển thị ra màn hình
                string loiChiTiet = ex.InnerException != null ? ex.InnerException.Message : ex.Message;

                MessageBox.Show("Lỗi chi tiết từ Database: " + loiChiTiet, "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmThemSuaNV_Load(object sender, EventArgs e) { }
        private void FrmThemSuaNV_Load_1(object sender, EventArgs e) { }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}