using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using OfficeOpenXml;
using QuanLiNhanSu_TinhLuong.Data;
using QuanLiNhanSu_TinhLuong.Models;
using QuanLiNhanSu_TinhLuong.Services;

namespace QuanLiNhanSu_TinhLuong
{
    public partial class FrmBangLuong : Form
    {
        private PrintDocument xuLyInAn = new PrintDocument();
        private PrintPreviewDialog cuaSoXemTruocIn = new PrintPreviewDialog();
        private int maNVSelectedDeIn = -1;

        public FrmBangLuong()
        {
            InitializeComponent();
            SetupModernUI();
            HanCheSuKienNutBam();
            xuLyInAn.PrintPage += new PrintPageEventHandler(VeDoHoaBiEnLaiLuong);

            // Cấu hình thư viện Excel
            OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            // ĐẢM BẢO 100% 3 NÚT GUNA HIỂN THỊ ĐÚNG CHỮ
            if (btnChotLuong != null) btnChotLuong.Text = "Tính & Chốt Lương";
            if (btnXuatExcel != null) btnXuatExcel.Text = "Xuất Excel";
            if (btnInBienLai != null) btnInBienLai.Text = "In Biên Lai";
        }

        private void HanCheSuKienNutBam()
        {
            if (btnChotLuong != null)
            {
                btnChotLuong.Click -= btnChotLuong_Click;
                btnChotLuong.Click += btnChotLuong_Click;
            }
            if (btnXuatExcel != null)
            {
                btnXuatExcel.Click -= btnXuatExcel_Click;
                btnXuatExcel.Click += btnXuatExcel_Click;
            }
            if (btnInBienLai != null)
            {
                btnInBienLai.Click -= btnInBienLai_Click;
                btnInBienLai.Click += btnInBienLai_Click;
            }
            if (nudThang != null) nudThang.ValueChanged += (s, e) => TaiBangLuongLenLuoi();
            if (nudNam != null) nudNam.ValueChanged += (s, e) => TaiBangLuongLenLuoi();
        }

        private void FrmBangLuong_Load(object sender, EventArgs e)
        {
            if (nudThang != null) nudThang.Value = DateTime.Now.Month;
            if (nudNam != null) nudNam.Value = DateTime.Now.Year;
            TaiBangLuongLenLuoi();
        }

        private void btnChotLuong_Click(object sender, EventArgs e)
        {
            if (nudThang == null || nudNam == null) return;

            int thang = (int)nudThang.Value;
            int nam = (int)nudNam.Value;

            try
            {
                using (var context = new QuanlynhansuContext())
                {
                    var dsNhanVien = context.Nhanviens.ToList();
                    NghiepVuLuong nghiepVu = new NghiepVuLuong();

                    foreach (var nv in dsNhanVien)
                    {
                        nghiepVu.TinhVaLuuLuongThang(nv.MaNv, thang, nam);
                    }

                    MessageBox.Show($"Đã tính toán và chốt lương thành công cho tháng {thang:D2}/{nam}!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TaiBangLuongLenLuoi();
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteLog(ex);
                MessageBox.Show("Lỗi thuật toán chốt lương: " + ex.Message, "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TaiBangLuongLenLuoi()
        {
            if (nudThang == null || nudNam == null || dgvBangLuong == null) return;
            string thangNamStr = $"{(int)nudThang.Value:D2}/{(int)nudNam.Value}";
            try
            {
                using (var context = new QuanlynhansuContext())
                {
                    var data = context.Bangluongs
                        .Where(bl => bl.ThangNam == thangNamStr)
                        .Select(bl => new
                        {
                            MãPhiếu = bl.MaBl,
                            MãNV = bl.MaNv,
                            TênNhânViên = bl.MaNvNavigation != null ? bl.MaNvNavigation.HoTen : "",
                            ThángNăm = bl.ThangNam,
                            TổngNgàyCông = bl.TongNgayCong,
                            PhụCấp = bl.PhuCap,
                            KhấuTrừ = bl.KhauTru,
                            ThựcNhận = bl.LuongThucNhan
                        }).ToList();

                    dgvBangLuong.DataSource = data;

                    // ĐỊNH DẠNG SỐ TIỀN VÀ CĂN LỀ PHẢI CHO DỄ NHÌN
                    string formatTienTe = "N0";

                    if (dgvBangLuong.Columns["PhụCấp"] != null)
                    {
                        dgvBangLuong.Columns["PhụCấp"].DefaultCellStyle.Format = formatTienTe;
                        dgvBangLuong.Columns["PhụCấp"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }
                    if (dgvBangLuong.Columns["KhấuTrừ"] != null)
                    {
                        dgvBangLuong.Columns["KhấuTrừ"].DefaultCellStyle.Format = formatTienTe;
                        dgvBangLuong.Columns["KhấuTrừ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }
                    if (dgvBangLuong.Columns["ThựcNhận"] != null)
                    {
                        dgvBangLuong.Columns["ThựcNhận"].DefaultCellStyle.Format = formatTienTe;
                        dgvBangLuong.Columns["ThựcNhận"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }
                }
            }
            catch (Exception ex) { ErrorLogger.WriteLog(ex); }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (dgvBangLuong == null || dgvBangLuong.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu lương tháng này để xuất file!", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog { Filter = "Excel Workbook|*.xlsx", FileName = $"BangLuong_Thang_{(int)nudThang.Value}_{(int)nudNam.Value}.xlsx" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        FileInfo fi = new FileInfo(sfd.FileName);
                        using (ExcelPackage pck = new ExcelPackage(fi))
                        {
                            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Bảng Lương");

                            ws.Cells["A1:H1"].Merge = true;
                            ws.Cells["A1"].Value = $"BẢNG TỔNG HỢP LƯƠNG NHÂN VIÊN THÁNG {(int)nudThang.Value}/{(int)nudNam.Value}";
                            ws.Cells["A1"].Style.Font.Bold = true;
                            ws.Cells["A1"].Style.Font.Size = 16;
                            ws.Cells["A1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                            for (int col = 0; col < dgvBangLuong.Columns.Count; col++)
                            {
                                ws.Cells[3, col + 1].Value = dgvBangLuong.Columns[col].HeaderText;
                                ws.Cells[3, col + 1].Style.Font.Bold = true;
                                ws.Cells[3, col + 1].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                                ws.Cells[3, col + 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(37, 99, 235));
                                ws.Cells[3, col + 1].Style.Font.Color.SetColor(Color.White);
                            }

                            for (int row = 0; row < dgvBangLuong.Rows.Count; row++)
                            {
                                for (int col = 0; col < dgvBangLuong.Columns.Count; col++)
                                {
                                    ws.Cells[row + 4, col + 1].Value = dgvBangLuong.Rows[row].Cells[col].Value;
                                }
                            }

                            ws.Cells.AutoFitColumns();
                            pck.Save();
                            MessageBox.Show("Xuất báo cáo Excel thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi xuất file Excel: " + ex.Message, "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnInBienLai_Click(object sender, EventArgs e)
        {
            if (dgvBangLuong == null || dgvBangLuong.CurrentRow == null || dgvBangLuong.CurrentRow.Index < 0)
            {
                MessageBox.Show("Vui lòng click chọn một nhân viên cụ thể trên lưới để in biên lai cá nhân!", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            maNVSelectedDeIn = Convert.ToInt32(dgvBangLuong.CurrentRow.Cells["MãNV"].Value);
            cuaSoXemTruocIn.Document = xuLyInAn;
            cuaSoXemTruocIn.WindowState = FormWindowState.Maximized;
            cuaSoXemTruocIn.ShowDialog();
        }

        private void VeDoHoaBiEnLaiLuong(object sender, PrintPageEventArgs e)
        {
            if (maNVSelectedDeIn == -1 || e.Graphics == null) return;

            try
            {
                using (var context = new QuanlynhansuContext())
                {
                    var nv = context.Nhanviens.Find(maNVSelectedDeIn);
                    string thangNamStr = $"{(int)nudThang.Value:D2}/{(int)nudNam.Value}";
                    var phieu = context.Bangluongs.FirstOrDefault(bl => bl.MaNv == maNVSelectedDeIn && bl.ThangNam == thangNamStr);

                    if (nv == null || phieu == null) return;

                    Graphics g = e.Graphics;
                    Font fontTieuDe = new Font("Segoe UI", 18, FontStyle.Bold);
                    Font fontMucLon = new Font("Segoe UI", 12, FontStyle.Bold);
                    Font fontChuThuong = new Font("Segoe UI", 11, FontStyle.Regular);
                    Font fontChuNghieng = new Font("Segoe UI", 10, FontStyle.Italic);
                    Brush coVe = Brushes.Black;

                    int x = 50, y = 40;

                    g.DrawString("CÔNG TY TNHH PHÁT TRIỂN THƯƠNG MẠI BAH", fontMucLon, coVe, x, y); y += 30;
                    g.DrawString("BIÊN LAI PHIẾU LƯƠNG CHI TIẾT", fontTieuDe, Brushes.Blue, x + 100, y); y += 45;
                    g.DrawString($"Kỳ tính lương: Tháng {thangNamStr}", fontChuNghieng, coVe, x + 240, y); y += 40;

                    g.DrawString("------------------------------------------------------------------------", fontChuThuong, coVe, x, y); y += 25;

                    g.DrawString($"Mã nhân viên: {nv.MaNv}", fontChuThuong, coVe, x, y); y += 25;
                    g.DrawString($"Họ và tên:     {nv.HoTen}", fontMucLon, coVe, x, y); y += 25;
                    g.DrawString($"Phòng ban:     {(nv.MaPbNavigation != null ? nv.MaPbNavigation.TenPb : "Khối văn phòng")}", fontChuThuong, coVe, x, y); y += 40;

                    g.DrawString("DANH MỤC THU NHẬP & KHẤU TRỪ", fontMucLon, coVe, x, y); y += 30;

                    g.DrawString($"+ Lương thỏa thuận gốc:     {nv.LuongCoBan:N0} VNĐ", fontChuThuong, coVe, x + 20, y); y += 25;
                    g.DrawString($"+ Tổng số ngày công tính:    {phieu.TongNgayCong} ngày làm việc", fontChuThuong, coVe, x + 20, y); y += 25;
                    g.DrawString($"+ Khoản phụ cấp thâm niên:  {phieu.PhuCap:N0} VNĐ", fontChuThuong, coVe, x + 20, y); y += 25;
                    g.DrawString($"+ Khoản khấu trừ vi phạm:   {phieu.KhauTru:N0} VNĐ", fontChuThuong, coVe, x + 20, y); y += 35;

                    g.DrawString("------------------------------------------------------------------------", fontChuThuong, coVe, x, y); y += 25;

                    g.DrawString($"LƯƠNG THỰC NHẬN:   {phieu.LuongThucNhan:N0} VNĐ", fontTieuDe, Brushes.Red, x, y); y += 60;

                    g.DrawString("Người lập phiếu", fontChuNghieng, coVe, x + 60, y);
                    g.DrawString("Nhân viên xác nhận ký tên", fontChuNghieng, coVe, x + 420, y);
                }
            }
            catch (Exception ex) { ErrorLogger.WriteLog(ex); }
        }

        public void SetupModernUI()
        {
            this.BackColor = ColorTranslator.FromHtml("#F8FAFC");
            this.Font = new Font("Segoe UI", 10F, FontStyle.Regular);

            if (dgvBangLuong != null)
            {
                dgvBangLuong.BorderStyle = BorderStyle.None;
                dgvBangLuong.GridColor = ColorTranslator.FromHtml("#E2E8F0");
                dgvBangLuong.EnableHeadersVisualStyles = false;
                dgvBangLuong.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#2563EB");
                dgvBangLuong.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgvBangLuong.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                dgvBangLuong.ColumnHeadersHeight = 42;
                dgvBangLuong.RowTemplate.Height = 38;
                dgvBangLuong.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F1F5F9");
                dgvBangLuong.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#DBEAFE");
                dgvBangLuong.DefaultCellStyle.SelectionForeColor = ColorTranslator.FromHtml("#1E3A8A");
                dgvBangLuong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                try { dgvBangLuong.RowHeadersVisible = false; } catch { }
            }
        }
    }
}