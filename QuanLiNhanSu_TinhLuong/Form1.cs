using System.Windows.Forms;
using System.Linq;

namespace QuanLiNhanSu_TinhLuong
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (var context = new Data.QuanlynhansuContext())
            {
                dgvNhanVien.DataSource = context.Nhanviens.ToList();
            }
        }
    }
}
