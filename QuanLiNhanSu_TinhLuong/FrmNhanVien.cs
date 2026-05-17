using System;
using System.Windows.Forms;

namespace QuanLiNhanSu_TinhLuong
{
    public partial class FrmNhanVien : Form
    {
        public FrmNhanVien()
        {
            InitializeComponent();
            GunaUiStyler.SetupGunaUI(this);
            ThemeManager.ApplyModernTheme(this);
        }
    }
}
