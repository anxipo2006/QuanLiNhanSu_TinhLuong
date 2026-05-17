using iTextSharp.text;
using iTextSharp.text.pdf;
using System.ComponentModel;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection.Metadata;
using System.Windows.Forms;
using System.Xml.Linq;
using ClosedXML.Excel;
using System.Data;
using System;
using System.IO;

namespace QuanLiNhanSu_TinhLuong
{
    public partial class Form1 : Form
    {
        string quyenNguoiDung = "";

        public Form1(string role)
        {
            InitializeComponent();
            quyenNguoiDung = role;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (quyenNguoiDung != "Admin" && quyenNguoiDung != "Trưởng phòng")
            {
                button1.Enabled = false;
                btnChotLuong.Enabled = false;
                MessageBox.Show("Bạn đang truy cập với quyền Nhân viên. Các chức năng Chốt Lương và Lưu Ngày Công đã được khóa an toàn.",
                                "Thông báo phân quyền", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            using (var context = new Data.QuanlynhansuContext())
            {
                dgvNhanVien.DataSource = context.Nhanviens.ToList();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new Data.QuanlynhansuContext())
                {
                    Models.Chamcong banGhiTest = new Models.Chamcong()
                    {
                        MaNv = 1,
                        ThangNam = "10/2026",
                        SoNgayDiLam = 26
                    };

                    db.Chamcongs.Add(banGhiTest);
                    db.SaveChanges();

                    MessageBox.Show("Đã chèn cứng 1 dòng chấm công vào DB thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXuatBaoCao_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.Rows.Count > 0)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "PDF (*.pdf)|*.pdf";
                save.FileName = "BaoCaoLuong.pdf";
                bool ErrorMessage = false;

                if (save.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(save.FileName))
                    {
                        try { File.Delete(save.FileName); }
                        catch (Exception ex) { ErrorMessage = true; MessageBox.Show("Không thể ghi dữ liệu!" + ex.Message); }
                    }
                    if (!ErrorMessage)
                    {
                        try
                        {
                            PdfPTable pTable = new PdfPTable(dgvNhanVien.Columns.Count);
                            pTable.DefaultCell.Padding = 2;
                            pTable.WidthPercentage = 100;
                            pTable.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn col in dgvNhanVien.Columns)
                            {
                                PdfPCell pCell = new PdfPCell(new Phrase(col.HeaderText));
                                pTable.AddCell(pCell);
                            }

                            using (FileStream stream = new FileStream(save.FileName, FileMode.Create))
                            {
                                iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 10f, 10f, 10f, 0f);
                                PdfWriter.GetInstance(pdfDoc, stream);
                                pdfDoc.Open();
                                pdfDoc.Add(pTable);
                                pdfDoc.Close();
                                stream.Close();
                            }
                            MessageBox.Show("Xuất file PDF thành công!", "Thông báo");
                        }
                        catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
                    }
                }
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx", FileName = "BaoCaoNhanSu.xlsx" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (XLWorkbook workbook = new XLWorkbook())
                        {
                            DataTable dt = new DataTable();

                            // TẠO BỘ LỌC: Danh sách các tên cột rác cần vứt bỏ
                            string[] cotRac = { "Bangluongs", "Chamcongs", "Viphams", "Chucvus", "Phongbans", "MaCvNavigation", "MaPbNavigation" };

                            // 1. Thêm tiêu đề cột (Bỏ qua cột rác)
                            foreach (DataGridViewColumn col in dgvNhanVien.Columns)
                            {
                                if (!cotRac.Contains(col.Name))
                                {
                                    dt.Columns.Add(col.HeaderText);
                                }
                            }

                            // 2. Thêm dữ liệu từng dòng
                            foreach (DataGridViewRow row in dgvNhanVien.Rows)
                            {
                                if (!row.IsNewRow)
                                {
                                    DataRow dr = dt.NewRow();
                                    int dtIndex = 0; // Biến đếm vị trí cột cho DataTable sạch

                                    for (int i = 0; i < dgvNhanVien.Columns.Count; i++)
                                    {
                                        string colName = dgvNhanVien.Columns[i].Name;

                                        // Chỉ lấy dữ liệu nếu cột đó KHÔNG nằm trong danh sách rác
                                        if (!cotRac.Contains(colName))
                                        {
                                            dr[dtIndex] = row.Cells[i].Value?.ToString() ?? "";
                                            dtIndex++;
                                        }
                                    }
                                    dt.Rows.Add(dr);
                                }
                            }

                            var worksheet = workbook.Worksheets.Add(dt, "Danh sách");
                            worksheet.Columns().AdjustToContents();

                            workbook.SaveAs(sfd.FileName);
                            MessageBox.Show("Xuất file Excel thành công! Đã dọn sạch bong các cột mã Code thừa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnChotLuong_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new QuanLiNhanSu_TinhLuong.Data.QuanlynhansuContext())
                {
                    int thangChot = 10;
                    int namChot = 2026;
                    string chuoiThangNam = thangChot.ToString("D2") + "/" + namChot.ToString();

                    var danhSachCong = context.Chamcongs
                        .Where(t => t.ThangNam == chuoiThangNam)
                        .GroupBy(t => t.MaNv)
                        .Select(group => new
                        {
                            MaNV = group.Key,
                            TongNgayCong = group.Sum(x => x.SoNgayDiLam)
                        })
                        .ToList();

                    QuanLiNhanSu_TinhLuong.NghiepVuLuong nghiepVu = new QuanLiNhanSu_TinhLuong.NghiepVuLuong();

                    foreach (var item in danhSachCong)
                    {
                        decimal tienThucLanh = nghiepVu.TinhLuongThucLanh(item.MaNV.Value, thangChot, namChot);

                        Models.Bangluong phieuLuongMoi = new Models.Bangluong()
                        {
                            MaNv = item.MaNV.Value,
                            ThangNam = thangChot.ToString("D2") + "/" + namChot.ToString(),
                            TongTienLuong = tienThucLanh
                        };
                        context.Bangluongs.Add(phieuLuongMoi);
                    }

                    context.SaveChanges();
                    MessageBox.Show("Đã chốt lương và LƯU VÀO DATABASE thành công!", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                QuanLiNhanSu_TinhLuong.Services.ErrorLogger.WriteLog(ex);
                MessageBox.Show("Có lỗi xảy ra trong quá trình chốt lương! Đã tiến hành ghi vết vào file log.", "Thông báo lỗi");
            }
        }

        private async void btnTestGemini_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đang gửi câu hỏi cho AI... Vui lòng đợi vài giây nhấn OK!");
            Services.GeminiService ai = new Services.GeminiService();
            string ketQua = await ai.HoiDapGemini("Viết một câu chào mừng nhân viên mới gia nhập công ty thật ngắn gọn.");
            MessageBox.Show(ketQua, "Kết quả từ Gemini");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Services.EmailService email = new Services.EmailService();
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string duongDanNhap = System.IO.Path.Combine(desktopPath, "PhieuLuongTest.txt");

            System.IO.File.WriteAllText(duongDanNhap, "Đây là dữ liệu test gửi mail phiếu lương của Nhóm 02.");

            string emailNhan = "tronga96@gmail.com";

            email.GuiEmailKemFile(emailNhan, "PhieuLuongTest", "Gửi test tính năng gửi mail của dự án", duongDanNhap);

            MessageBox.Show("Đã chạy lệnh gửi mail! Mở hộp thư kiểm tra thử nhé.", "Thông báo");
        }

        // HÀM CHỈ LÀM NHIỆM VỤ VẼ BIÊN LAI
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Cài đặt Font chữ
            System.Drawing.Font fontTieuDe = new System.Drawing.Font("Arial", 20, System.Drawing.FontStyle.Bold);
            System.Drawing.Font fontThuong = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Regular);

            // Vẽ text tiêu đề lên tờ giấy in
            e.Graphics.DrawString("CÔNG TY TNHH B.A.H", fontTieuDe, System.Drawing.Brushes.Black, new System.Drawing.Point(250, 50));
            e.Graphics.DrawString("BIÊN LAI THANH TOÁN LƯƠNG", new System.Drawing.Font("Arial", 16, System.Drawing.FontStyle.Bold), System.Drawing.Brushes.Black, new System.Drawing.Point(230, 100));

            // Lấy dữ liệu thật từ DataGridView truyền vào
            string tenNhanVien = "Huỳnh Phúc Thịnh";
            string tienLuong = "0";

            if (dgvNhanVien.CurrentRow != null && !dgvNhanVien.CurrentRow.IsNewRow)
            {
                // Truy xuất giá trị cột Họ tên và Lương Cơ Bản
                tenNhanVien = dgvNhanVien.CurrentRow.Cells["HoTen"].Value?.ToString() ?? "Huỳnh Phúc Thịnh";
                tienLuong = dgvNhanVien.CurrentRow.Cells["LuongCoBan"].Value?.ToString() ?? "0";
            }

            decimal luongFormat = 0;
            decimal.TryParse(tienLuong, out luongFormat);

            // Vẽ dữ liệu nhân viên
            e.Graphics.DrawString($"Nhân viên: {tenNhanVien}", fontThuong, System.Drawing.Brushes.Black, new System.Drawing.Point(100, 160));
            e.Graphics.DrawString("Kỳ lương: Tháng 10/2026", fontThuong, System.Drawing.Brushes.Black, new System.Drawing.Point(100, 190));
            e.Graphics.DrawString($"Tổng thực lãnh: {luongFormat:N0} VNĐ", new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold), System.Drawing.Brushes.Red, new System.Drawing.Point(100, 220));

            // Kẻ chỉ và ký tên
            e.Graphics.DrawString("--------------------------------------------------", fontThuong, System.Drawing.Brushes.Black, new System.Drawing.Point(100, 250));
            e.Graphics.DrawString("Chữ ký người nhận", fontThuong, System.Drawing.Brushes.Black, new System.Drawing.Point(500, 280));
        }

        // HÀM GỌI LỆNH MỞ CỬA SỔ XEM TRƯỚC BẢN IN (GẮN VÀO NÚT BẤM)
        private void btnInBienLai_Click(object sender, EventArgs e)
        {
            // Gắn tài liệu vào màn hình Preview
            printPreviewDialog1.Document = printDocument1;

            // Chỉnh kích thước form xem trước cho dễ nhìn
            printPreviewDialog1.Width = 800;
            printPreviewDialog1.Height = 600;

            // Bật form xem trước lên
            printPreviewDialog1.ShowDialog();
        }
    }
}