using System.Windows.Forms;
using System.Linq;

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

        private async void button1_Click(object sender, EventArgs e)
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
