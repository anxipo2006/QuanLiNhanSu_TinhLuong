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
            monthCalendar1.Location = new Point(19, 44);
            monthCalendar1.Margin = new Padding(10, 12, 10, 12);
            monthCalendar1.MaxSelectionCount = 31;
            monthCalendar1.Name = "monthCalendar1";
            monthCalendar1.TabIndex = 3;
            monthCalendar1.DateChanged += monthCalendar1_DateChanged;
            // 
            // dgvChamCong
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
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
            dgvChamCong.Location = new Point(21, 267);
            dgvChamCong.Margin = new Padding(3, 4, 3, 4);
            dgvChamCong.Name = "dgvChamCong";
            dgvChamCong.RowHeadersVisible = false;
            dgvChamCong.RowHeadersWidth = 51;
            dgvChamCong.RowTemplate.Height = 40;
            dgvChamCong.Size = new Size(846, 400);
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
            btnCoMat.BorderRadius = 10;
            btnCoMat.CustomizableEdges = customizableEdges1;
            btnCoMat.FillColor = Color.FromArgb(220, 252, 231);
            btnCoMat.Font = new Font("Segoe UI", 9F);
            btnCoMat.ForeColor = Color.FromArgb(22, 101, 52);
            btnCoMat.HoverState.FillColor = Color.FromArgb(187, 247, 208);
            btnCoMat.Location = new Point(311, 44);
            btnCoMat.Margin = new Padding(3, 4, 3, 4);
            btnCoMat.Name = "btnCoMat";
            btnCoMat.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnCoMat.Size = new Size(114, 48);
            btnCoMat.TabIndex = 2;
            btnCoMat.Text = "Có mặt";
            toolTip1.SetToolTip(btnCoMat, "?ánh d?u có m?t cho nhân viên ch?n");
            // 
            // btnVang
            // 
            btnVang.BorderRadius = 10;
            btnVang.CustomizableEdges = customizableEdges3;
            btnVang.FillColor = Color.FromArgb(254, 226, 226);
            btnVang.Font = new Font("Segoe UI", 9F);
            btnVang.ForeColor = Color.FromArgb(153, 27, 27);
            btnVang.HoverState.FillColor = Color.FromArgb(254, 202, 202);
            btnVang.Location = new Point(311, 117);
            btnVang.Margin = new Padding(3, 4, 3, 4);
            btnVang.Name = "btnVang";
            btnVang.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnVang.Size = new Size(114, 48);
            btnVang.TabIndex = 1;
            btnVang.Text = "Vắng";
            toolTip1.SetToolTip(btnVang, "?ánh d?u v?ng");
            // 
            // btnDiTre
            // 
            btnDiTre.BorderRadius = 10;
            btnDiTre.CustomizableEdges = customizableEdges5;
            btnDiTre.FillColor = Color.FromArgb(254, 243, 199);
            btnDiTre.Font = new Font("Segoe UI", 9F);
            btnDiTre.ForeColor = Color.FromArgb(146, 64, 14);
            btnDiTre.HoverState.FillColor = Color.FromArgb(253, 230, 138);
            btnDiTre.Location = new Point(311, 182);
            btnDiTre.Margin = new Padding(3, 4, 3, 4);
            btnDiTre.Name = "btnDiTre";
            btnDiTre.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnDiTre.Size = new Size(114, 48);
            btnDiTre.TabIndex = 0;
            btnDiTre.Text = "Đi trễ";
            toolTip1.SetToolTip(btnDiTre, "?ánh d?u ?i tr?");
            // 
            // cboNhanVien
            // 
            cboNhanVien.BackColor = Color.Transparent;
            cboNhanVien.CustomizableEdges = customizableEdges7;
            cboNhanVien.DrawMode = DrawMode.OwnerDrawFixed;
            cboNhanVien.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNhanVien.FocusedColor = Color.FromArgb(94, 148, 255);
            cboNhanVien.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cboNhanVien.Font = new Font("Segoe UI", 10F);
            cboNhanVien.ForeColor = Color.FromArgb(68, 88, 112);
            cboNhanVien.ItemHeight = 30;
            cboNhanVien.Location = new Point(21, 2);
            cboNhanVien.Name = "cboNhanVien";
            cboNhanVien.ShadowDecoration.CustomizableEdges = customizableEdges8;
            cboNhanVien.Size = new Size(175, 36);
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
