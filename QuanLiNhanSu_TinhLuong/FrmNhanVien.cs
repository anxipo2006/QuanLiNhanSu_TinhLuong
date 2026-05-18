using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QuanLiNhanSu_TinhLuong.Data;
using QuanLiNhanSu_TinhLuong.Models;
using QuanLiNhanSu_TinhLuong.Services;

namespace QuanLiNhanSu_TinhLuong
{
    public partial class FrmNhanVien : Form
    {
        // =======================================================
        // 1. HÀM KHỞI TẠO (TRÁI TIM CỦA FORM)
        // =======================================================
        public FrmNhanVien()
        {
            InitializeComponent();
            SetupModernUI();

            // Ép phần mềm phải vẽ cây và đổ lưới ngay lập tức mà không cần chờ sự kiện Load
            LoadTreeViewPhongBan();
            HienThiDanhSachNhanVien(null);
        }

        private void FrmNhanVien_Load(object sender, EventArgs e)
        {
            // Để trống vì đã gọi ở Constructor
        }

        // =======================================================
        // 2. NẠP DỮ LIỆU SƠ ĐỒ CÂY PHÒNG BAN (Đã gọi đúng tên treeViewPhongBan)
        // =======================================================
        private void LoadTreeViewPhongBan()
        {
            try
            {
                // Gọi thẳng tên control của bạn ngoài Designer
                if (treeViewPhongBan == null) return;

                treeViewPhongBan.Nodes.Clear();
                treeViewPhongBan.ForeColor = Color.Black;
                TreeNode rootNode = new TreeNode("Tất cả phòng ban");
                rootNode.Tag = null; // Tag = null nghĩa là hiển thị toàn bộ không lọc
                treeViewPhongBan.Nodes.Add(rootNode);

                using (var context = new QuanlynhansuContext())
                {
                    // Lấy danh sách từ bảng phongban trong MySQL đổ vào nhánh con
                    var dsPhongBan = context.Phongbans.ToList();
                    foreach (var pb in dsPhongBan)
                    {
                        TreeNode node = new TreeNode(pb.TenPb);
                        node.Tag = pb.MaPb; // Găm mã phòng ban vào Tag để click lọc dữ liệu
                        rootNode.Nodes.Add(node);
                    }
                }

                treeViewPhongBan.ExpandAll(); // Bung toàn bộ các nhánh phòng ban ra ngay khi chạy
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteLog(ex);
                MessageBox.Show("Lỗi nạp sơ đồ cây phòng ban: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =======================================================
        // 3. HIỂN THỊ LƯỚI NHÂN VIÊN (Có hỗ trợ bộ lọc Phòng Ban)
        // =======================================================
        public void HienThiDanhSachNhanVien(int? maPb)
        {
            try
            {
                using (var context = new QuanlynhansuContext())
                {
                    var query = context.Nhanviens.AsQueryable();

                    // Lọc theo phòng ban nếu có click vào cây
                    if (maPb.HasValue)
                    {
                        query = query.Where(nv => nv.MaPb == maPb.Value);
                    }

                    var danhSach = query.Select(nv => new
                    {
                        MaNV = nv.MaNv,
                        HoTen = nv.HoTen,
                        SoDienThoai = nv.Sdt,
                        DiaChi = nv.DiaChi,
                        PhongBan = nv.MaPbNavigation != null ? nv.MaPbNavigation.TenPb : "Chưa xếp phòng",
                        ChucVu = nv.MaCvNavigation != null ? nv.MaCvNavigation.TenCv : "Chưa có chức vụ",

                        // Fix lỗi cộng dồn lương chuẩn xác
                        Luong = nv.LuongCoBan + (nv.MaCvNavigation != null ? (nv.MaCvNavigation.PhuCap ?? 0) : 0)
                    }).ToList();

                    // Tự động tìm Grid trên giao diện
                    var grid = this.Controls.OfType<DataGridView>().FirstOrDefault()
                            ?? this.Controls.Find("dgvNhanVien", true).FirstOrDefault() as DataGridView;

                    if (grid != null)
                    {
                        grid.DataSource = danhSach;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteLog(ex);
                MessageBox.Show("Lỗi tải danh sách: " + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =======================================================
        // 4. SỰ KIỆN NÚT BẤM VÀ CÂY THƯ MỤC
        // =======================================================

        // Sự kiện khi click vào cây phòng ban (Đã khớp tên trong Properties của bạn)
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node != null)
            {
                int? maPb = e.Node.Tag as int?;
                HienThiDanhSachNhanVien(maPb);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            FrmThemSuaNV frm = new FrmThemSuaNV(-1);
            frm.ShowDialog();
            HienThiDanhSachNhanVien(LayMaPhongBanDangChon());
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            var grid = this.Controls.OfType<DataGridView>().FirstOrDefault()
                    ?? this.Controls.Find("dgvNhanVien", true).FirstOrDefault() as DataGridView;

            if (grid == null || grid.CurrentRow == null || grid.CurrentRow.Index < 0)
            {
                MessageBox.Show("Vui lòng click chọn một nhân viên trong danh sách để sửa!", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int maNV = Convert.ToInt32(grid.CurrentRow.Cells["MaNV"].Value);
                FrmThemSuaNV frm = new FrmThemSuaNV(maNV);
                frm.ShowDialog();
                HienThiDanhSachNhanVien(LayMaPhongBanDangChon());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mở form sửa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var grid = this.Controls.OfType<DataGridView>().FirstOrDefault()
                    ?? this.Controls.Find("dgvNhanVien", true).FirstOrDefault() as DataGridView;

            if (grid == null || grid.CurrentRow == null || grid.CurrentRow.Index < 0)
            {
                MessageBox.Show("Vui lòng click chọn một nhân viên để xóa!", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maNV = Convert.ToInt32(grid.CurrentRow.Cells["MaNV"].Value);
            string tenNV = grid.CurrentRow.Cells["HoTen"].Value?.ToString() ?? "";

            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa nhân viên '{tenNV}' không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (var context = new QuanlynhansuContext())
                    {
                        var nv = context.Nhanviens.Find(maNV);
                        if (nv != null)
                        {
                            context.Nhanviens.Remove(nv);
                            context.SaveChanges();
                            MessageBox.Show("Đã xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            HienThiDanhSachNhanVien(LayMaPhongBanDangChon());
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể xóa nhân viên này vì ràng buộc dữ liệu lịch sử!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private int? LayMaPhongBanDangChon()
        {
            if (treeViewPhongBan != null && treeViewPhongBan.SelectedNode != null)
            {
                return treeViewPhongBan.SelectedNode.Tag as int?;
            }
            return null;
        }

        // Các hàm phụ để lót ổ cho Designer khỏi báo lỗi
        private void btnThemMoi_Click(object sender, EventArgs e) => btnThem_Click(sender, e);
        private void FrmNhanVien_Load_1(object sender, EventArgs e) { }

        // =======================================================
        // 5. TRANG TRÍ GIAO DIỆN CHUYÊN NGHIỆP
        // =======================================================
        public void SetupModernUI()
        {
            this.BackColor = ColorTranslator.FromHtml("#F8FAFC");
            this.Font = new Font("Segoe UI", 10F, FontStyle.Regular);

            var grid = this.Controls.OfType<DataGridView>().FirstOrDefault()
                    ?? this.Controls.Find("dgvNhanVien", true).FirstOrDefault() as DataGridView;

            if (grid != null)
            {
                grid.BorderStyle = BorderStyle.None;
                grid.GridColor = ColorTranslator.FromHtml("#E2E8F0");
                grid.EnableHeadersVisualStyles = false;
                grid.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#2563EB");
                grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                grid.ColumnHeadersHeight = 42;
                grid.RowTemplate.Height = 38;
                grid.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F1F5F9");
                grid.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#DBEAFE");
                grid.DefaultCellStyle.SelectionForeColor = ColorTranslator.FromHtml("#1E3A8A");
                grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                try { grid.RowHeadersVisible = false; } catch { }
            }

            foreach (var b in this.Controls.OfType<Button>())
            {
                b.FlatStyle = FlatStyle.Flat;
                b.FlatAppearance.BorderSize = 0;
                b.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                b.BackColor = ColorTranslator.FromHtml("#2563EB");
                b.ForeColor = Color.White;
                b.Padding = new Padding(8);
                var orig = b.BackColor;
                b.MouseEnter += (s, ev) => b.BackColor = ColorTranslator.FromHtml("#1D4ED8");
                b.MouseLeave += (s, ev) => b.BackColor = orig;
            }
        }

        private void treeViewPhongBan_ForeColorChanged(object sender, EventArgs e)
        {

        }
    }
}