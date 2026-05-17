using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace QuanLiNhanSu_TinhLuong
{
    public static class GunaUiStyler
    {
        // Global colors
        private static readonly Color PrimaryBlue = ColorTranslator.FromHtml("#2563EB");
        private static readonly Color Background = ColorTranslator.FromHtml("#F8FAFC");
        private static readonly Color CardWhite = ColorTranslator.FromHtml("#FFFFFF");
        private static readonly Color BorderGray = ColorTranslator.FromHtml("#CBD5E1");

        // Entry point - call this after InitializeComponent() in each form
        public static void SetupGunaUI(Form form)
        {
            if (form == null) return;

            // Apply some common form-level styles
            form.BackColor = Background;
            form.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);

            // Dispatch by form type name to specific styling
            var typeName = form.GetType().Name;
            switch (typeName)
            {
                case "FrmNhanVien":
                    ApplyFrmNhanVienStyles(form);
                    break;
                case "FrmThemSuaNV":
                    ApplyFrmThemSuaNVStyles(form);
                    break;
                case "FrmChamCong":
                    ApplyFrmChamCongStyles(form);
                    break;
                default:
                    // generic: apply basic styles to Guna2 controls if present
                    ApplyGenericGunaStyles(form);
                    break;
            }
        }

        private static void ApplyGenericGunaStyles(Control parent)
        {
            foreach (var c in GetAllControls(parent))
            {
                if (c is Guna2TextBox tb)
                {
                    tb.BorderRadius = 6;
                    tb.BorderColor = BorderGray;
                    tb.FillColor = CardWhite;
                    tb.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
                    tb.FocusedState.BorderColor = PrimaryBlue;
                }
                else if (c is Guna2ComboBox cb)
                {
                    cb.BorderRadius = 6;
                    cb.BorderColor = BorderGray;
                    cb.FillColor = CardWhite;
                    cb.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
                    // focused color for combobox
                    cb.FocusedColor = PrimaryBlue;
                }
                else if (c is Guna2DateTimePicker dt)
                {
                    dt.BorderRadius = 6;
                    dt.BorderColor = BorderGray;
                    dt.FillColor = CardWhite;
                    dt.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
                    dt.FocusedColor = PrimaryBlue;
                }
                else if (c is Guna2Button btn)
                {
                    btn.BorderRadius = 6;
                    btn.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                    btn.ShadowDecoration.Enabled = false;
                    btn.UseTransparentBackground = false;
                }
                else if (c is Guna2DataGridView dgv)
                {
                    StyleDataGrid(dgv);
                }
            }
        }

        private static void ApplyFrmNhanVienStyles(Control form)
        {
            // Style DataGridView(s)
            var dgv = GetAllControls(form).OfType<Guna2DataGridView>().FirstOrDefault(c => c.Name.Contains("dgv", StringComparison.OrdinalIgnoreCase));
            if (dgv != null)
            {
                StyleDataGrid(dgv);
            }

            // Style textboxes (search bar heuristics)
            var allTextboxes = GetAllControls(form).OfType<Guna2TextBox>().ToList();
            foreach (var tb in allTextboxes)
            {
                // Default textbox shape
                tb.BorderRadius = 6;
                tb.BorderColor = BorderGray;
                tb.FillColor = CardWhite;
                tb.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
                tb.FocusedState.BorderColor = PrimaryBlue;

                // Heuristic: if name contains "search" make it pill-shaped
                if (tb.Name.IndexOf("search", StringComparison.OrdinalIgnoreCase) >= 0 || tb.PlaceholderText?.IndexOf("search", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    tb.BorderRadius = 20;
                }
            }

            // Style add/edit/delete buttons (common names)
            var btnNames = new[] { "btnAdd", "btnThem", "btnEdit", "btnSua", "btnDelete", "btnXoa" };
            foreach (var name in btnNames)
            {
                var btn = GetAllControls(form).OfType<Guna2Button>().FirstOrDefault(b => b.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
                if (btn != null)
                {
                    btn.BorderRadius = 6;
                    btn.FillColor = PrimaryBlue;
                    btn.ForeColor = Color.White;
                    btn.HoverState.FillColor = ControlPaint.Dark(PrimaryBlue);
                    btn.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                }
            }
        }

        private static void ApplyFrmThemSuaNVStyles(Control form)
        {
            // Iterate and apply global design to specific Guna2 controls
            foreach (var c in GetAllControls(form))
            {
                if (c is Guna2TextBox tb)
                {
                    tb.BorderRadius = 6;
                    tb.BorderColor = BorderGray;
                    tb.FillColor = CardWhite;
                    tb.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
                    tb.FocusedState.BorderColor = PrimaryBlue;
                }
                else if (c is Guna2ComboBox cb)
                {
                    cb.BorderRadius = 6;
                    cb.BorderColor = BorderGray;
                    cb.FillColor = CardWhite;
                    cb.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
                    cb.FocusedColor = PrimaryBlue;
                }
                else if (c is Guna2DateTimePicker dt)
                {
                    dt.BorderRadius = 6;
                    dt.BorderColor = BorderGray;
                    dt.FillColor = CardWhite;
                    dt.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
                    dt.FocusedColor = PrimaryBlue;
                }
            }

            // Style Choose Image button (assumed name contains "Chon" or "Ch?n" or "btnChonAnh")
            var chooseBtn = GetAllControls(form).OfType<Guna2Button>().FirstOrDefault(b => b.Name.IndexOf("chon", StringComparison.OrdinalIgnoreCase) >= 0 || b.Name.IndexOf("ch?n", StringComparison.OrdinalIgnoreCase) >= 0);
            if (chooseBtn != null)
            {
                chooseBtn.BorderRadius = 6;
                chooseBtn.FillColor = Color.Transparent;
                chooseBtn.BorderColor = PrimaryBlue;
                chooseBtn.BorderThickness = 1;
                chooseBtn.ForeColor = PrimaryBlue;
                chooseBtn.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                chooseBtn.HoverState.FillColor = Color.FromArgb(235, 248, 255);
            }
        }

        private static void ApplyFrmChamCongStyles(Control form)
        {
            // Style three status buttons by common names
            var present = GetAllControls(form).OfType<Guna2Button>().FirstOrDefault(b => b.Name.Equals("btnCoMat", StringComparison.OrdinalIgnoreCase) || b.Text.IndexOf("có m?t", StringComparison.OrdinalIgnoreCase) >= 0);
            var absent = GetAllControls(form).OfType<Guna2Button>().FirstOrDefault(b => b.Name.Equals("btnVang", StringComparison.OrdinalIgnoreCase) || b.Text.IndexOf("v?ng", StringComparison.OrdinalIgnoreCase) >= 0);
            var late = GetAllControls(form).OfType<Guna2Button>().FirstOrDefault(b => b.Name.Equals("btnDiTre", StringComparison.OrdinalIgnoreCase) || b.Text.IndexOf("tr?", StringComparison.OrdinalIgnoreCase) >= 0);

            if (present != null)
            {
                present.BorderRadius = 6;
                present.FillColor = ColorTranslator.FromHtml("#DCFCE7");
                present.ForeColor = ColorTranslator.FromHtml("#166534");
                present.BorderThickness = 0;
                present.HoverState.FillColor = ColorTranslator.FromHtml("#BBF7D0");
            }

            if (absent != null)
            {
                absent.BorderRadius = 6;
                absent.FillColor = ColorTranslator.FromHtml("#FEE2E2");
                absent.ForeColor = ColorTranslator.FromHtml("#991B1B");
                absent.BorderThickness = 0;
                absent.HoverState.FillColor = ColorTranslator.FromHtml("#FECACA");
            }

            if (late != null)
            {
                late.BorderRadius = 6;
                late.FillColor = ColorTranslator.FromHtml("#FEF3C7");
                late.ForeColor = ColorTranslator.FromHtml("#92400E");
                late.BorderThickness = 0;
                late.HoverState.FillColor = ColorTranslator.FromHtml("#FDE68A");
            }
        }

        public static void StyleDataGrid(Guna2DataGridView dgv)
        {
            if (dgv == null) return;

            dgv.ThemeStyle.HeaderStyle.BackColor = PrimaryBlue;
            dgv.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgv.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.ColumnHeadersHeight = 44;
            dgv.RowTemplate.Height = 40;
            dgv.BorderStyle = BorderStyle.None;
            dgv.GridColor = ColorTranslator.FromHtml("#E6EDF6");
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F1F5F9");
            dgv.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#DBEAFE");
            dgv.DefaultCellStyle.SelectionForeColor = ColorTranslator.FromHtml("#1E3A8A");
            dgv.EnableHeadersVisualStyles = false;
        }

        // Helper: recursively enumerate all child controls
        public static IEnumerable<Control> GetAllControls(Control parent)
        {
            var list = new List<Control>();
            foreach (Control c in parent.Controls)
            {
                list.Add(c);
                if (c.HasChildren)
                {
                    list.AddRange(GetAllControls(c));
                }
            }
            return list;
        }

        // Public styling helpers for external callers
        public static void StyleTextBox(Guna2TextBox tb)
        {
            if (tb == null) return;
            tb.BorderRadius = 6;
            tb.BorderColor = BorderGray;
            tb.FillColor = CardWhite;
            tb.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            tb.FocusedState.BorderColor = PrimaryBlue;
            tb.HoverState.BorderColor = ControlPaint.Dark(BorderGray);
        }

        public static void StyleComboBox(Guna2ComboBox cb)
        {
            if (cb == null) return;
            cb.BorderRadius = 6;
            cb.BorderColor = BorderGray;
            cb.FillColor = CardWhite;
            cb.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            cb.FocusedColor = PrimaryBlue;
            cb.HoverState.BorderColor = ControlPaint.Dark(BorderGray);
        }

        public static void StyleDatePicker(Guna2DateTimePicker dt)
        {
            if (dt == null) return;
            dt.BorderRadius = 6;
            dt.BorderColor = BorderGray;
            dt.FillColor = CardWhite;
            dt.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            dt.FocusedColor = PrimaryBlue;
            dt.HoverState.BorderColor = ControlPaint.Dark(BorderGray);
        }

        public static void StyleNumericUpDown(Guna2NumericUpDown num)
        {
            if (num == null) return;
            num.BorderRadius = 6;
            num.BorderColor = BorderGray;
            num.FillColor = CardWhite;
            num.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            // Guna2NumericUpDown does not expose FocusedColor or HoverState in this version
            // Leave default focus/hover appearance
        }

        public static void StyleStatusButton(Guna2Button btn, string type)
        {
            if (btn == null) return;
            btn.BorderRadius = 6;
            btn.BorderThickness = 0;
            btn.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btn.ShadowDecoration.Enabled = false;
            switch (type)
            {
                case "present":
                    btn.FillColor = ColorTranslator.FromHtml("#DCFCE7");
                    btn.ForeColor = ColorTranslator.FromHtml("#166534");
                    btn.HoverState.FillColor = ColorTranslator.FromHtml("#BBF7D0");
                    break;
                case "absent":
                    btn.FillColor = ColorTranslator.FromHtml("#FEE2E2");
                    btn.ForeColor = ColorTranslator.FromHtml("#991B1B");
                    btn.HoverState.FillColor = ColorTranslator.FromHtml("#FECACA");
                    break;
                case "late":
                    btn.FillColor = ColorTranslator.FromHtml("#FEF3C7");
                    btn.ForeColor = ColorTranslator.FromHtml("#92400E");
                    btn.HoverState.FillColor = ColorTranslator.FromHtml("#FDE68A");
                    break;
            }
        }
    }
}
