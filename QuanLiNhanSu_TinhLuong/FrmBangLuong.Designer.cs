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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBangLuong));
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
            nudThang.BackColor = Color.FromArgb(192, 255, 255);
            nudThang.Location = new Point(180, 82);
            nudThang.Name = "nudThang";
            nudThang.Size = new Size(140, 27);
            nudThang.TabIndex = 1;
            // 
            // nudNam
            // 
            nudNam.BackColor = Color.FromArgb(192, 255, 255);
            nudNam.Location = new Point(180, 131);
            nudNam.Name = "nudNam";
            nudNam.Size = new Size(140, 27);
            nudNam.TabIndex = 2;
            // 
            // dgvBangLuong
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            dgvBangLuong.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvBangLuong.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvBangLuong.ColumnHeadersHeight = 4;
            dgvBangLuong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvBangLuong.DefaultCellStyle = dataGridViewCellStyle3;
            dgvBangLuong.GridColor = Color.FromArgb(231, 229, 255);
            dgvBangLuong.Location = new Point(0, 320);
            dgvBangLuong.Name = "dgvBangLuong";
            dgvBangLuong.RowHeadersVisible = false;
            dgvBangLuong.RowHeadersWidth = 51;
            dgvBangLuong.Size = new Size(800, 210);
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
            guna2HtmlLabel1.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            guna2HtmlLabel1.Location = new Point(60, 87);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(48, 22);
            guna2HtmlLabel1.TabIndex = 7;
            guna2HtmlLabel1.Text = "Tháng";
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.BackColor = Color.Transparent;
            guna2HtmlLabel2.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            guna2HtmlLabel2.Location = new Point(60, 131);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(82, 22);
            guna2HtmlLabel2.TabIndex = 8;
            guna2HtmlLabel2.Text = "Năm(20**)";
            // 
            // guna2HtmlLabel3
            // 
            guna2HtmlLabel3.BackColor = Color.Transparent;
            guna2HtmlLabel3.Font = new Font("Segoe UI Black", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel3.Location = new Point(274, 15);
            guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            guna2HtmlLabel3.Size = new Size(301, 61);
            guna2HtmlLabel3.TabIndex = 9;
            guna2HtmlLabel3.Text = "BẢNG LƯƠNG";
            // 
            // btnChotLuong
            // 
            btnChotLuong.BorderRadius = 12;
            btnChotLuong.CustomizableEdges = customizableEdges1;
            btnChotLuong.DisabledState.BorderColor = Color.DarkGray;
            btnChotLuong.DisabledState.CustomBorderColor = Color.DarkGray;
            btnChotLuong.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnChotLuong.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnChotLuong.FillColor = Color.FromArgb(127, 183, 255);
            btnChotLuong.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnChotLuong.ForeColor = Color.White;
            btnChotLuong.Location = new Point(90, 220);
            btnChotLuong.Name = "btnChotLuong";
            btnChotLuong.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnChotLuong.Size = new Size(190, 48);
            btnChotLuong.TabIndex = 10;
            btnChotLuong.Text = "  Chốt Lương";
            // 
            // btnXuatExcel
            // 
            btnXuatExcel.BorderRadius = 12;
            btnXuatExcel.CustomizableEdges = customizableEdges3;
            btnXuatExcel.DisabledState.BorderColor = Color.DarkGray;
            btnXuatExcel.DisabledState.CustomBorderColor = Color.DarkGray;
            btnXuatExcel.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnXuatExcel.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnXuatExcel.FillColor = Color.FromArgb(127, 183, 255);
            btnXuatExcel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnXuatExcel.ForeColor = Color.White;
            btnXuatExcel.Location = new Point(305, 220);
            btnXuatExcel.Name = "btnXuatExcel";
            btnXuatExcel.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnXuatExcel.Size = new Size(190, 48);
            btnXuatExcel.TabIndex = 11;
            btnXuatExcel.Text = "  Xuất Excel";
            // 
            // btnInBienLai
            // 
            btnInBienLai.BorderRadius = 12;
            btnInBienLai.CustomizableEdges = customizableEdges5;
            btnInBienLai.DisabledState.BorderColor = Color.DarkGray;
            btnInBienLai.DisabledState.CustomBorderColor = Color.DarkGray;
            btnInBienLai.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnInBienLai.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnInBienLai.FillColor = Color.FromArgb(127, 183, 255);
            btnInBienLai.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnInBienLai.ForeColor = Color.White;
            btnInBienLai.Location = new Point(520, 220);
            btnInBienLai.Name = "btnInBienLai";
            btnInBienLai.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnInBienLai.Size = new Size(140, 48);
            btnInBienLai.TabIndex = 12;
            btnInBienLai.Text = "  In";
            // 
            // FrmBangLuong
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
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