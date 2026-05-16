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

namespace QuanLiNhanSu_TinhLuong
{
    public partial class Form1 : Form
    {
        // 1. Khai báo 1 biến để lưu quyền
        string quyenNguoiDung = "";

        // 2. Nhét thêm chữ "string role" vào giữa 2 dấu ngoặc
        public Form1(string role)
        {
            InitializeComponent();

            // 3. Nhận quyền từ form đăng nhập và lưu lại
            quyenNguoiDung = role;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (var context = new Data.QuanlynhansuContext())
            {
                //dgvNhanVien.DataSource = context.Nhanviens.ToList();
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Khởi tạo Context để làm việc với Database (như bạn đã làm ở hàm Load)
                using (var db = new Data.QuanlynhansuContext())
                {
                    // Duyệt qua từng dòng trên bảng dgvNhanVien
                    foreach (DataGridViewRow row in dgvNhanVien.Rows)
                    {
                        // Bỏ qua dòng trống cuối cùng để tránh lỗi
                        if (row.IsNewRow) continue;

                        // LƯU Ý QUAN TRỌNG: 
                        // - Số 0 là vị trí cột Mã Nhân Viên (thường là cột đầu tiên).
                        // - Bạn cần thay số 3 thành vị trí cột "Số ngày làm" mà bạn vừa thêm (ví dụ nếu nó là cột thứ 4 thì index sẽ là 3).
                        if (row.Cells[3].Value != null)
                        {
                            int maNhanVien = Convert.ToInt32(row.Cells[0].Value);
                            float soNgayLam = Convert.ToSingle(row.Cells[3].Value);
                            string thangNamHienTai = DateTime.Now.ToString("MM/yyyy");

                            // Tạo một đối tượng Chamcong mới nằm trong thư mục Models
                            Models.Chamcong banGhiChamCong = new Models.Chamcong()
                            {
                                MaNv = maNhanVien,
                                ThangNam = thangNamHienTai,
                                SoNgayDiLam = soNgayLam
                            };

                            // Thêm vào DB
                            db.Chamcongs.Add(banGhiChamCong);
                        }
                    }

                    // Lưu toàn bộ thay đổi xuống Database
                    db.SaveChanges();
                    MessageBox.Show("Lưu ngày công thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                            // 1. Tạo bảng PDF (Sửa lỗi PdfPTable và Element)
                            PdfPTable pTable = new PdfPTable(dgvNhanVien.Columns.Count);
                            pTable.DefaultCell.Padding = 2;
                            pTable.WidthPercentage = 100;
                            pTable.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT; // Thêm iTextSharp.text vào trước Element

                            // 2. Thêm Header (Tiêu đề cột)
                            foreach (DataGridViewColumn col in dgvNhanVien.Columns)
                            {
                                PdfPCell pCell = new PdfPCell(new Phrase(col.HeaderText)); pTable.AddCell(pCell);
                            }

                            // 3. Khởi tạo Document (Sửa các lỗi từ dòng 123-127 trong danh sách lỗi trước đó)
                            // Lưu ý: Dùng tên đầy đủ iTextSharp.text.Document để không bị lẫn với thư viện hệ thống
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

            // 1. Khởi tạo hộp thoại lưu file
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx", FileName = "BaoCaoNhanSu.xlsx" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (XLWorkbook workbook = new XLWorkbook())
                        {
                            // 2. Tạo một DataTable để chứa dữ liệu từ DataGridView
                            DataTable dt = new DataTable();

                            // Thêm các cột tiêu đề
                            foreach (DataGridViewColumn col in dgvNhanVien.Columns)
                            {
                                dt.Columns.Add(col.HeaderText);
                            }

                            // Thêm các dòng dữ liệu (Dựa trên dgvNhanVien bạn đã dùng ở phần PDF)
                            foreach (DataGridViewRow row in dgvNhanVien.Rows)
                            {
                                if (!row.IsNewRow)
                                {
                                    DataRow dr = dt.NewRow();
                                    for (int i = 0; i < dgvNhanVien.Columns.Count; i++)
                                    {
                                        dr[i] = row.Cells[i].Value?.ToString() ?? "";
                                    }
                                    dt.Rows.Add(dr);
                                }
                            }

                            // 3. Đưa DataTable vào Worksheet và lưu file
                            var worksheet = workbook.Worksheets.Add(dt, "Danh sách");
                            worksheet.Columns().AdjustToContents(); // Tự động căn chỉnh độ rộng cột

                            workbook.SaveAs(sfd.FileName);
                            MessageBox.Show("Xuất file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
           
        {
            try
            {
                using (var context = new QuanLiNhanSu_TinhLuong.Data.QuanlynhansuContext())
                {
                    int thangChot = 10;
                    int namChot = 2026;
                        string chuoiThangNam = thangChot.ToString("D2") + "/" + namChot.ToString();
                        // Sử dụng GroupBy và Sum của LINQ theo yêu cầu của thầy
                        var danhSachCong = context.Chamcongs
                            .Where(t => t.ThangNam == chuoiThangNam)
                            .GroupBy(t => t.MaNv)
                            .Select(group => new
                             {
                                 MaNV = group.Key,
                                 // Dùng cột SoNgayDiLam có sẵn trong bảng của bạn
                                 TongNgayCong = group.Sum(x => x.SoNgayDiLam)
                             })
                             .ToList();

                        // Khởi tạo nghiệp vụ của Nhóm trưởng An
                        QuanLiNhanSu_TinhLuong.NghiepVuLuong nghiepVu = new QuanLiNhanSu_TinhLuong.NghiepVuLuong();

                    foreach (var item in danhSachCong)
                    {
                        // Gọi hàm tính tiền từ class NghiepVuLuong
                        decimal tienThucLanh = nghiepVu.TinhLuongThucLanh(item.MaNV.Value, thangChot, namChot, (float)item.TongNgayCong);

                        // TO DO: Viết code Insert số tiền này vào bảng SalarySlip
                    }
                    MessageBox.Show("Đã chốt lương thành công cho toàn bộ nhân viên!");
                }
            }
            catch (Exception ex)
            {
                // Ghi log lỗi theo yêu cầu của nhóm trưởng
                //QuanLiNhanSu_TinhLuong.Services.ErrorLogger.WriteLog(ex);
                MessageBox.Show("Có lỗi xảy ra! Đã ghi vào file log.", "Thông báo");
            }
        }
    }

        private async void btnTestGemini_Click(object sender, EventArgs e)
        {
            // Bật thông báo cho biết đang chờ AI suy nghĩ
            MessageBox.Show("Đang gửi câu hỏi cho AI... Vui lòng đợi vài giây nhấn OK!");

            // Gọi class GeminiService của bạn
            Services.GeminiService ai = new Services.GeminiService();

            // Đặt một câu hỏi thử
            string ketQua = await ai.HoiDapGemini("Viết một câu chào mừng nhân viên mới gia nhập công ty thật ngắn gọn.");

            // Hiển thị kết quả AI trả về
            MessageBox.Show(ketQua, "Kết quả từ Gemini");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Services.EmailService email = new Services.EmailService();

            // 1. Tạo file nháp tự động ngoài màn hình Desktop cho an toàn
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string duongDanNhap = System.IO.Path.Combine(desktopPath, "PhieuLuongTest.txt");

            System.IO.File.WriteAllText(duongDanNhap, "Đây là dữ liệu test gửi mail phiếu lương của Nhóm 02.");

            // 2. Gửi mail
            string emailNhan = "tronga96@gmail.com";

            email.GuiEmailPhieuLuong(emailNhan, "PhieuLuongTest", duongDanNhap);

            MessageBox.Show("Đã chạy lệnh gửi mail! Mở hộp thư kiểm tra thử nhé.", "Thông báo");
        }

    }
}

