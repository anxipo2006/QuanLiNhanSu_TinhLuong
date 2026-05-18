namespace QuanLiNhanSu_TinhLuong
{
    partial class FrmBangLuong
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            nudThang = new NumericUpDown();
            nudNam = new NumericUpDown();
            dgvBangLuong = new Guna.UI2.WinForms.Guna2DataGridView();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            btnChotLuong = new Guna.UI2.WinForms.Guna2Button();
            btnXuatExcel = new Guna.UI2.WinForms.Guna2Button();
            btnInBienLai = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)nudThang).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudNam).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvBangLuong).BeginInit();
            SuspendLayout();
            // 
            // nudThang
            // 
            nudThang.Location = new Point(190, 58);
            nudThang.Name = "nudThang";
            nudThang.Size = new Size(150, 27);
            nudThang.TabIndex = 1;
            // 
            // nudNam
            // 
            nudNam.Location = new Point(190, 103);
            nudNam.Name = "nudNam";
            nudNam.Size = new Size(150, 27);
            nudNam.TabIndex = 2;
            // 
            // dgvBangLuong
            // 
            dataGridViewCellStyle4.BackColor = Color.White;
            dgvBangLuong.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvBangLuong.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvBangLuong.ColumnHeadersHeight = 4;
            dgvBangLuong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.White;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle6.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dgvBangLuong.DefaultCellStyle = dataGridViewCellStyle6;
            dgvBangLuong.GridColor = Color.FromArgb(231, 229, 255);
            dgvBangLuong.Location = new Point(-1, 264);
            dgvBangLuong.Name = "dgvBangLuong";
            dgvBangLuong.RowHeadersVisible = false;
            dgvBangLuong.RowHeadersWidth = 51;
            dgvBangLuong.Size = new Size(805, 188);
            dgvBangLuong.TabIndex = 6;
            dgvBangLuong.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvBangLuong.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvBangLuong.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgvBangLuong.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvBangLuong.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvBangLuong.ThemeStyle.BackColor = Color.White;
            dgvBangLuong.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dgvBangLuong.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgvBangLuong.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvBangLuong.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dgvBangLuong.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvBangLuong.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvBangLuong.ThemeStyle.HeaderStyle.Height = 4;
            dgvBangLuong.ThemeStyle.ReadOnly = false;
            dgvBangLuong.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvBangLuong.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvBangLuong.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvBangLuong.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgvBangLuong.ThemeStyle.RowsStyle.Height = 29;
            dgvBangLuong.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvBangLuong.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Location = new Point(111, 63);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(44, 22);
            guna2HtmlLabel1.TabIndex = 7;
            guna2HtmlLabel1.Text = "Tháng";
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.BackColor = Color.Transparent;
            guna2HtmlLabel2.Location = new Point(111, 108);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(73, 22);
            guna2HtmlLabel2.TabIndex = 8;
            guna2HtmlLabel2.Text = "Năm(20**)";
            // 
            // guna2HtmlLabel3
            // 
            guna2HtmlLabel3.BackColor = Color.Transparent;
            guna2HtmlLabel3.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel3.Location = new Point(334, 9);
            guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            guna2HtmlLabel3.Size = new Size(174, 43);
            guna2HtmlLabel3.TabIndex = 9;
            guna2HtmlLabel3.Text = "Bảng Lương";
            // 
            // btnChotLuong
            // 
            btnChotLuong.CustomizableEdges = customizableEdges7;
            btnChotLuong.DisabledState.BorderColor = Color.DarkGray;
            btnChotLuong.DisabledState.CustomBorderColor = Color.DarkGray;
            btnChotLuong.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnChotLuong.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnChotLuong.Font = new Font("Segoe UI", 9F);
            btnChotLuong.ForeColor = Color.White;
            btnChotLuong.Location = new Point(81, 185);
            btnChotLuong.Name = "btnChotLuong";
            btnChotLuong.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnChotLuong.Size = new Size(146, 39);
            btnChotLuong.TabIndex = 10;
            btnChotLuong.Text = "Chốt Lương";
            // 
            // btnXuatExcel
            // 
            btnXuatExcel.CustomizableEdges = customizableEdges9;
            btnXuatExcel.DisabledState.BorderColor = Color.DarkGray;
            btnXuatExcel.DisabledState.CustomBorderColor = Color.DarkGray;
            btnXuatExcel.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnXuatExcel.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnXuatExcel.Font = new Font("Segoe UI", 9F);
            btnXuatExcel.ForeColor = Color.White;
            btnXuatExcel.Location = new Point(262, 185);
            btnXuatExcel.Name = "btnXuatExcel";
            btnXuatExcel.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnXuatExcel.Size = new Size(146, 39);
            btnXuatExcel.TabIndex = 11;
            btnXuatExcel.Text = "Xuất excell";
            // 
            // btnInBienLai
            // 
            btnInBienLai.CustomizableEdges = customizableEdges11;
            btnInBienLai.DisabledState.BorderColor = Color.DarkGray;
            btnInBienLai.DisabledState.CustomBorderColor = Color.DarkGray;
            btnInBienLai.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnInBienLai.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnInBienLai.Font = new Font("Segoe UI", 9F);
            btnInBienLai.ForeColor = Color.White;
            btnInBienLai.Location = new Point(444, 185);
            btnInBienLai.Name = "btnInBienLai";
            btnInBienLai.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnInBienLai.Size = new Size(146, 39);
            btnInBienLai.TabIndex = 12;
            btnInBienLai.Text = "In";
            // 
            // FrmBangLuong
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnInBienLai);
            Controls.Add(btnXuatExcel);
            Controls.Add(btnChotLuong);
            Controls.Add(guna2HtmlLabel3);
            Controls.Add(guna2HtmlLabel2);
            Controls.Add(guna2HtmlLabel1);
            Controls.Add(dgvBangLuong);
            Controls.Add(nudNam);
            Controls.Add(nudThang);
            Name = "FrmBangLuong";
            Text = "FrmBangLuong";
            ((System.ComponentModel.ISupportInitialize)nudThang).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudNam).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvBangLuong).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NumericUpDown nudThang;
        private NumericUpDown nudNam;
       
        private Guna.UI2.WinForms.Guna2DataGridView dgvBangLuong;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2Button btnChotLuong;
        private Guna.UI2.WinForms.Guna2Button btnXuatExcel;
        private Guna.UI2.WinForms.Guna2Button btnInBienLai;
    }
}