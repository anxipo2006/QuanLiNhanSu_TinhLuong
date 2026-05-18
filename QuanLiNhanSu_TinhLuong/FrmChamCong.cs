using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using QuanLiNhanSu_TinhLuong.Data;
using QuanLiNhanSu_TinhLuong.Models;
using QuanLiNhanSu_TinhLuong.Services;

namespace QuanLiNhanSu_TinhLuong
{
    public partial class FrmChamCong : Form
    {
        public FrmChamCong()
        {
            InitializeComponent();

            GunaUiStyler.SetupGunaUI(this);
            // ThemeManager.ApplyModernTheme(this);
            SetupModernUI();
        }

        // =========================================================
        // PHẦN 1: LOGIC NGHIỆP VỤ (DATABASE) & NỐI SỰ KIỆN TỰ ĐỘNG
        // =========================================================

        private void FrmChamCong_Load(object sender, EventArgs e)
        {
            // 1. Ép Font tiếng Việt chuẩn xác
            if (btnCoMat != null) btnCoMat.Text = "Có mặt";
            if (btnVang != null) btnVang.Text = "Vắng";
            if (btnDiTre != null) btnDiTre.Text = "Đi trễ";

            // 2. TUYỆT CHIÊU: Hàn chết sự kiện click bằng Code (Trị dứt điểm bệnh bấm không ăn)
            if (btnCoMat != null)
            {
                btnCoMat.Click -= btnCoMat_Click_1; // Hủy các dây nối bị lỗi cũ
                btnCoMat.Click += (s, ev) => LuuChamCong("Có mặt"); // Hàn dây mới
            }
            if (btnVang != null)
            {
                btnVang.Click -= btnVang_Click_1;
                btnVang.Click += (s, ev) => LuuChamCong("Vắng");
            }
            if (btnDiTre != null)
            {
                btnDiTre.Click -= btnDiTre_Click_1;
                btnDiTre.Click += (s, ev) => LuuChamCong("Trễ");
            }

            LoadComboboxNhanVien();
            HienThiLichSuChamCong();
        }

        // Đổ danh sách nhân viên vào ComboBox
        private void LoadComboboxNhanVien()
        {
            try
            {
                using (var context = new QuanlynhansuContext())
                {
                    var dsNhanVien = context.Nhanviens.Select(nv => new
                    {
                        nv.MaNv,
                        HienThi = nv.MaNv + " - " + nv.HoTen
                    }).ToList();

                    // Dùng thẳng tên cboNhanVien
                    if (cboNhanVien != null)
                    {
                        cboNhanVien.DataSource = dsNhanVien;
                        cboNhanVien.DisplayMember = "HienThi";
                        cboNhanVien.ValueMember = "MaNv";
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteLog(ex);
            }
        }

        // Hiển thị lịch sử chấm công
        private void HienThiLichSuChamCong()
        {
            try
            {
                DateOnly ngayChon = DateOnly.FromDateTime(monthCalendar1.SelectionStart);

                using (var context = new QuanlynhansuContext())
                {
                    var lichSu = context.Chamcongs
                        .Where(cc => cc.NgayChamCong == ngayChon)
                        .Select(cc => new
                        {
                            MaCC = cc.MaCc,
                            MaNV = cc.MaNv,
                            TenNhanVien = cc.MaNvNavigation != null ? cc.MaNvNavigation.HoTen : "",
                            Ngay = cc.NgayChamCong,
                            TrạngThái = cc.TrangThai,
                            GhiChú = cc.GhiChu
                        }).ToList();

                    // Dùng thẳng tên dgvChamCong
                    if (dgvChamCong != null)
                    {
                        dgvChamCong.DataSource = lichSu;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteLog(ex);
            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            HienThiLichSuChamCong();
        }

        // HÀM XỬ LÝ LƯU DATABASE TỐI ƯU
        private void LuuChamCong(string trangThai)
        {
            if (cboNhanVien == null || cboNhanVien.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên trước khi chấm công!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maNV = (int)cboNhanVien.SelectedValue;
            DateOnly ngayCham = DateOnly.FromDateTime(monthCalendar1.SelectionStart);
            string ghiChu = ""; // Nếu bạn kéo thêm TextBox ghi chú vào form thì lấy chữ ở đây

            try
            {
                using (var context = new QuanlynhansuContext())
                {
                    var ccTonTai = context.Chamcongs.FirstOrDefault(cc => cc.MaNv == maNV && cc.NgayChamCong == ngayCham);

                    if (ccTonTai != null)
                    {
                        ccTonTai.TrangThai = trangThai; // Đổi trạng thái nếu chấm lại
                        MessageBox.Show($"Đã cập nhật lại thành: {trangThai}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        var ccMoi = new Chamcong
                        {
                            MaNv = maNV,
                            NgayChamCong = ngayCham,
                            TrangThai = trangThai,
                            GhiChu = ghiChu
                        };
                        context.Chamcongs.Add(ccMoi);
                        MessageBox.Show($"Đã ghi nhận: {trangThai}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    context.SaveChanges();
                    HienThiLichSuChamCong(); // Load lại lưới ngay lập tức
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteLog(ex);
                MessageBox.Show("Lỗi lưu dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // PHẦN 2: XỬ LÝ GIAO DIỆN (Đã fix lỗi cảnh báo màu vàng)
        // =========================================================

        public void SetupModernUI()
        {
            this.BackColor = ColorTranslator.FromHtml("#F8FAFC");
            this.Font = new Font("Segoe UI", 10F, FontStyle.Regular);

            if (btnCoMat != null) StyleStatusControl(btnCoMat, "present");
            if (btnVang != null) StyleStatusControl(btnVang, "absent");
            if (btnDiTre != null) StyleStatusControl(btnDiTre, "late");

            if (dgvChamCong is Guna2DataGridView gunaDg)
            {
                GunaUiStyler.StyleDataGrid(gunaDg);
            }
            else if (dgvChamCong != null)
            {
                StyleStandardDataGrid(dgvChamCong);
            }

            foreach (var tb in GunaUiStyler.GetAllControls(this).OfType<Guna2TextBox>()) GunaUiStyler.StyleTextBox(tb);
            foreach (var cb in GunaUiStyler.GetAllControls(this).OfType<Guna2ComboBox>()) GunaUiStyler.StyleComboBox(cb);
            foreach (var dt in GunaUiStyler.GetAllControls(this).OfType<Guna2DateTimePicker>()) GunaUiStyler.StyleDatePicker(dt);

            foreach (var b in this.Controls.OfType<Button>())
            {
                if (b.Name == "btnCoMat" || b.Name == "btnVang" || b.Name == "btnDiTre") continue;
                StyleStandardButton(b);
            }
        }

        private void StyleStatusControl(Control ctl, string type)
        {
            if (ctl == null) return;
            if (ctl is Guna2Button gbtn)
            {
                GunaUiStyler.StyleStatusButton(gbtn, type);
                return;
            }

            if (ctl is Button btn)
            {
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                btn.Padding = new Padding(8);
                switch (type)
                {
                    case "present":
                        btn.BackColor = ColorTranslator.FromHtml("#DCFCE7");
                        btn.ForeColor = ColorTranslator.FromHtml("#166534");
                        btn.MouseEnter += (s, e) => btn.BackColor = ColorTranslator.FromHtml("#BBF7D0");
                        btn.MouseLeave += (s, e) => btn.BackColor = ColorTranslator.FromHtml("#DCFCE7");
                        break;
                    case "absent":
                        btn.BackColor = ColorTranslator.FromHtml("#FEE2E2");
                        btn.ForeColor = ColorTranslator.FromHtml("#991B1B");
                        btn.MouseEnter += (s, e) => btn.BackColor = ColorTranslator.FromHtml("#FECACA");
                        btn.MouseLeave += (s, e) => btn.BackColor = ColorTranslator.FromHtml("#FEE2E2");
                        break;
                    case "late":
                        btn.BackColor = ColorTranslator.FromHtml("#FFEDD5");
                        btn.ForeColor = ColorTranslator.FromHtml("#9A3412");
                        btn.MouseEnter += (s, e) => btn.BackColor = ColorTranslator.FromHtml("#FED7AA");
                        btn.MouseLeave += (s, e) => btn.BackColor = ColorTranslator.FromHtml("#FFEDD5");
                        break;
                }
            }
        }

        private void StyleStandardButton(Button btn)
        {
            if (btn == null) return;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn.BackColor = ColorTranslator.FromHtml("#2563EB");
            btn.ForeColor = Color.White;
            btn.Padding = new Padding(8);
            var orig = btn.BackColor;
            btn.MouseEnter += (s, e) => btn.BackColor = ColorTranslator.FromHtml("#1D4ED8");
            btn.MouseLeave += (s, e) => btn.BackColor = orig;
        }

        private void StyleStandardDataGrid(DataGridView dgv)
        {
            if (dgv == null) return;
            dgv.BorderStyle = BorderStyle.None;
            dgv.GridColor = ColorTranslator.FromHtml("#E2E8F0");
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#2563EB");
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgv.ColumnHeadersHeight = 42;
            dgv.RowTemplate.Height = 38;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F1F5F9");
            dgv.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#DBEAFE");
            dgv.DefaultCellStyle.SelectionForeColor = ColorTranslator.FromHtml("#1E3A8A");
            try { dgv.RowHeadersVisible = false; } catch { }
        }

        private void btnCoMat_Click_1(object sender, EventArgs e) { }
        private void btnVang_Click_1(object sender, EventArgs e) { }
        private void btnDiTre_Click_1(object sender, EventArgs e) { }
    }
}