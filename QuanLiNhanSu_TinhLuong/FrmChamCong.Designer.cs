namespace QuanLiNhanSu_TinhLuong
{
    partial class FrmChamCong
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmChamCong));
            monthCalendar1 = new MonthCalendar();
            dgvChamCong = new Guna.UI2.WinForms.Guna2DataGridView();
            btnCoMat = new Guna.UI2.WinForms.Guna2Button();
            btnVang = new Guna.UI2.WinForms.Guna2Button();
            btnDiTre = new Guna.UI2.WinForms.Guna2Button();
            toolTip1 = new ToolTip(components);
            cboNhanVien = new Guna.UI2.WinForms.Guna2ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvChamCong).BeginInit();
            SuspendLayout();
            // 
            // monthCalendar1
            // 
            monthCalendar1.BackColor = Color.FromArgb(192, 255, 255);
            monthCalendar1.Location = new Point(24, 56);
            monthCalendar1.Margin = new Padding(10, 12, 10, 12);
            monthCalendar1.MaxSelectionCount = 31;
            monthCalendar1.Name = "monthCalendar1";
            monthCalendar1.TabIndex = 3;
            monthCalendar1.DateChanged += monthCalendar1_DateChanged;
            // 
            // dgvChamCong
            // 
            dataGridViewCellStyle1.BackColor = Color.Transparent;
            dgvChamCong.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(37, 99, 235);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvChamCong.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvChamCong.ColumnHeadersHeight = 29;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvChamCong.DefaultCellStyle = dataGridViewCellStyle3;
            dgvChamCong.GridColor = Color.FromArgb(231, 229, 255);
            dgvChamCong.Location = new Point(21, 360);
            dgvChamCong.Margin = new Padding(3, 4, 3, 4);
            dgvChamCong.Name = "dgvChamCong";
            dgvChamCong.RowHeadersVisible = false;
            dgvChamCong.RowHeadersWidth = 51;
            dgvChamCong.RowTemplate.Height = 40;
            dgvChamCong.Size = new Size(846, 370);
            dgvChamCong.TabIndex = 1;
            dgvChamCong.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvChamCong.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvChamCong.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgvChamCong.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvChamCong.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvChamCong.ThemeStyle.BackColor = Color.White;
            dgvChamCong.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dgvChamCong.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(37, 99, 235);
            dgvChamCong.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvChamCong.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dgvChamCong.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvChamCong.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvChamCong.ThemeStyle.HeaderStyle.Height = 29;
            dgvChamCong.ThemeStyle.ReadOnly = false;
            dgvChamCong.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvChamCong.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvChamCong.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvChamCong.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgvChamCong.ThemeStyle.RowsStyle.Height = 40;
            dgvChamCong.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvChamCong.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // btnCoMat
            // 
            btnCoMat.BorderRadius = 14;
            btnCoMat.CustomizableEdges = customizableEdges1;
            btnCoMat.FillColor = Color.FromArgb(47, 158, 109);
            btnCoMat.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCoMat.ForeColor = Color.White;
            btnCoMat.Location = new Point(340, 52);
            btnCoMat.Margin = new Padding(3, 4, 3, 4);
            btnCoMat.Name = "btnCoMat";
            btnCoMat.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnCoMat.Size = new Size(160, 64);
            btnCoMat.TabIndex = 2;
            btnCoMat.Text = "  Có mặt";
            toolTip1.SetToolTip(btnCoMat, "Đánh dấu có mặt cho nhân viên được chọn");
            // 
            // btnVang
            // 
            btnVang.BorderRadius = 14;
            btnVang.CustomizableEdges = customizableEdges3;
            btnVang.FillColor = Color.FromArgb(229, 62, 62);
            btnVang.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnVang.ForeColor = Color.White;
            btnVang.HoverState.FillColor = Color.FromArgb(210, 50, 50);
            btnVang.Location = new Point(340, 132);
            btnVang.Margin = new Padding(3, 4, 3, 4);
            btnVang.Name = "btnVang";
            btnVang.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnVang.Size = new Size(160, 64);
            btnVang.TabIndex = 1;
            btnVang.Text = "  Vắng";
            toolTip1.SetToolTip(btnVang, "Đánh dấu vắng");
            // 
            // btnDiTre
            // 
            btnDiTre.BorderRadius = 14;
            btnDiTre.CustomizableEdges = customizableEdges5;
            btnDiTre.FillColor = Color.FromArgb(217, 150, 60);
            btnDiTre.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnDiTre.ForeColor = Color.White;
            btnDiTre.HoverState.FillColor = Color.FromArgb(200, 135, 50);
            btnDiTre.Location = new Point(340, 212);
            btnDiTre.Margin = new Padding(3, 4, 3, 4);
            btnDiTre.Name = "btnDiTre";
            btnDiTre.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnDiTre.Size = new Size(160, 64);
            btnDiTre.TabIndex = 0;
            btnDiTre.Text = "  Đi trễ";
            toolTip1.SetToolTip(btnDiTre, "Đánh dấu đi trễ");
            // 
            // cboNhanVien
            // 
            cboNhanVien.BackColor = Color.FromArgb(192, 255, 255);
            cboNhanVien.BorderRadius = 8;
            cboNhanVien.CustomizableEdges = customizableEdges7;
            cboNhanVien.DrawMode = DrawMode.OwnerDrawFixed;
            cboNhanVien.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNhanVien.FocusedColor = Color.FromArgb(94, 148, 255);
            cboNhanVien.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cboNhanVien.Font = new Font("Segoe UI", 10F);
            cboNhanVien.ForeColor = Color.FromArgb(68, 88, 112);
            cboNhanVien.ItemHeight = 30;
            cboNhanVien.Location = new Point(21, 12);
            cboNhanVien.Name = "cboNhanVien";
            cboNhanVien.ShadowDecoration.CustomizableEdges = customizableEdges8;
            cboNhanVien.Size = new Size(260, 36);
            cboNhanVien.TabIndex = 4;
            // 
            // FrmChamCong
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(896, 748);
            Controls.Add(cboNhanVien);
            Controls.Add(btnDiTre);
            Controls.Add(btnVang);
            Controls.Add(btnCoMat);
            Controls.Add(dgvChamCong);
            Controls.Add(monthCalendar1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmChamCong";
            Text = "FrmChamCong";
            Load += FrmChamCong_Load;
            ((System.ComponentModel.ISupportInitialize)dgvChamCong).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private MonthCalendar monthCalendar1;
        private Guna.UI2.WinForms.Guna2DataGridView dgvChamCong;
        private Guna.UI2.WinForms.Guna2Button btnCoMat;
        private Guna.UI2.WinForms.Guna2Button btnVang;
        private Guna.UI2.WinForms.Guna2Button btnDiTre;
        private ToolTip toolTip1;
        private Guna.UI2.WinForms.Guna2ComboBox cboNhanVien;
    }
}
