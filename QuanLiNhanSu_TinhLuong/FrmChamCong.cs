using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace QuanLiNhanSu_TinhLuong
{
    public partial class FrmChamCong : Form
    {
        public FrmChamCong()
        {
            InitializeComponent();
            // Apply shared Guna styling and then additional form-specific tweaks
            GunaUiStyler.SetupGunaUI(this);
            ThemeManager.ApplyModernTheme(this);
            SetupModernUI();
        }

        public void SetupModernUI()
        {
            // Basic form styling
            this.BackColor = ColorTranslator.FromHtml("#F8FAFC");
            this.Font = new Font("Segoe UI", 10F, FontStyle.Regular);

            // Style status buttons (support both Guna2Button and standard Button)
            var presentBtn = this.Controls.Find("btnCoMat", true).FirstOrDefault() as Control
                             ?? this.Controls.OfType<Button>().FirstOrDefault(b => b.Text?.IndexOf("Có m?t", StringComparison.OrdinalIgnoreCase) >= 0) as Control;
            var absentBtn = this.Controls.Find("btnVang", true).FirstOrDefault() as Control
                             ?? this.Controls.OfType<Button>().FirstOrDefault(b => b.Text?.IndexOf("V?ng", StringComparison.OrdinalIgnoreCase) >= 0) as Control;
            var lateBtn = this.Controls.Find("btnDiTre", true).FirstOrDefault() as Control
                             ?? this.Controls.OfType<Button>().FirstOrDefault(b => b.Text?.IndexOf("Tr?", StringComparison.OrdinalIgnoreCase) >= 0) as Control;

            StyleStatusControl(presentBtn, "present");
            StyleStatusControl(absentBtn, "absent");
            StyleStatusControl(lateBtn, "late");

            // Style DataGridView(s)
            var gunaDg = this.Controls.Find("dgvChamCong", true).FirstOrDefault() as Guna2DataGridView;
            if (gunaDg != null)
            {
                GunaUiStyler.StyleDataGrid(gunaDg);
            }
            else
            {
                var stdDg = this.Controls.OfType<DataGridView>().FirstOrDefault();
                if (stdDg != null) StyleStandardDataGrid(stdDg as DataGridView);
            }

            // Style inputs if any (Guna2 or standard)
            foreach (var tb in GunaUiStyler.GetAllControls(this).OfType<Guna2TextBox>()) GunaUiStyler.StyleTextBox(tb);
            foreach (var cb in GunaUiStyler.GetAllControls(this).OfType<Guna2ComboBox>()) GunaUiStyler.StyleComboBox(cb);
            foreach (var dt in GunaUiStyler.GetAllControls(this).OfType<Guna2DateTimePicker>()) GunaUiStyler.StyleDatePicker(dt);

            // Style any standard Buttons to match modern look (non-status)
            foreach (var b in this.Controls.OfType<Button>())
            {
                if (b.Name == "btnCoMat" || b.Name == "btnVang" || b.Name == "btnDiTre") continue;
                StyleStandardButton(b);
            }
        }

        private void StyleStatusControl(Control ctl, string type)
        {
            if (ctl == null) return;
            // Guna2Button
            if (ctl is Guna.UI2.WinForms.Guna2Button gbtn)
            {
                GunaUiStyler.StyleStatusButton(gbtn, type);
                return;
            }

            // Standard Button fallback
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
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.ColumnHeadersHeight = 42;
            dgv.RowTemplate.Height = 38;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F1F5F9");
            dgv.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#DBEAFE");
            dgv.DefaultCellStyle.SelectionForeColor = ColorTranslator.FromHtml("#1E3A8A");
            try { dgv.RowHeadersVisible = false; } catch { }
        }
    }
}
