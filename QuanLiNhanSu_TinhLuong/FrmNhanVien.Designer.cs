namespace QuanLiNhanSu_TinhLuong
{
    partial class FrmNhanVien
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNhanVien));
            guna2PanelSidebar = new Guna.UI2.WinForms.Guna2Panel();
            treeViewPhongBan = new TreeView();
            guna2PanelContent = new Guna.UI2.WinForms.Guna2Panel();
            btnXoa = new Guna.UI2.WinForms.Guna2Button();
            btnThemMoi = new Guna.UI2.WinForms.Guna2Button();
            btnSua = new Guna.UI2.WinForms.Guna2Button();
            dgvNhanVien = new Guna.UI2.WinForms.Guna2DataGridView();
            guna2PanelSidebar.SuspendLayout();
            guna2PanelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).BeginInit();
            SuspendLayout();
            // 
            // guna2PanelSidebar
            // 
            guna2PanelSidebar.Controls.Add(treeViewPhongBan);
            guna2PanelSidebar.CustomizableEdges = customizableEdges1;
            guna2PanelSidebar.Dock = DockStyle.Left;
            guna2PanelSidebar.FillColor = Color.FromArgb(37, 99, 235);
            guna2PanelSidebar.Location = new Point(0, 0);
            guna2PanelSidebar.Margin = new Padding(3, 4, 3, 4);
            guna2PanelSidebar.Name = "guna2PanelSidebar";
            guna2PanelSidebar.Padding = new Padding(14, 16, 14, 16);
            guna2PanelSidebar.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2PanelSidebar.Size = new Size(297, 600);
            guna2PanelSidebar.TabIndex = 1;
            // 
            // treeViewPhongBan
            // 
            treeViewPhongBan.Dock = DockStyle.Fill;
            treeViewPhongBan.ForeColor = Color.White;
            treeViewPhongBan.Location = new Point(14, 16);
            treeViewPhongBan.Margin = new Padding(3, 4, 3, 4);
            treeViewPhongBan.Name = "treeViewPhongBan";
            treeViewPhongBan.Size = new Size(269, 568);
            treeViewPhongBan.TabIndex = 0;
            treeViewPhongBan.AfterSelect += treeView1_AfterSelect;
            treeViewPhongBan.ForeColorChanged += treeViewPhongBan_ForeColorChanged;
            // 
            // guna2PanelContent
            // 
            guna2PanelContent.Controls.Add(btnXoa);
            guna2PanelContent.Controls.Add(btnThemMoi);
            guna2PanelContent.Controls.Add(btnSua);
            guna2PanelContent.Controls.Add(dgvNhanVien);
            guna2PanelContent.CustomizableEdges = customizableEdges9;
            guna2PanelContent.Dock = DockStyle.Fill;
            guna2PanelContent.FillColor = Color.White;
            guna2PanelContent.Location = new Point(297, 0);
            guna2PanelContent.Margin = new Padding(3, 4, 3, 4);
            guna2PanelContent.Name = "guna2PanelContent";
            guna2PanelContent.Padding = new Padding(18, 21, 18, 21);
            guna2PanelContent.ShadowDecoration.CustomizableEdges = customizableEdges10;
            guna2PanelContent.Size = new Size(617, 600);
            guna2PanelContent.TabIndex = 0;
            // 
            // btnXoa
            // 
            btnXoa.CustomizableEdges = customizableEdges3;
            btnXoa.DisabledState.BorderColor = Color.DarkGray;
            btnXoa.DisabledState.CustomBorderColor = Color.DarkGray;
            btnXoa.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnXoa.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnXoa.Font = new Font("Segoe UI", 9F);
            btnXoa.ForeColor = Color.White;
            btnXoa.Location = new Point(437, 528);
            btnXoa.Name = "btnXoa";
            btnXoa.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnXoa.Size = new Size(180, 72);
            btnXoa.TabIndex = 3;
            btnXoa.Text = "Xóa";
            btnXoa.Click += btnXoa_Click;
            // 
            // btnThemMoi
            // 
            btnThemMoi.CustomizableEdges = customizableEdges5;
            btnThemMoi.DisabledState.BorderColor = Color.DarkGray;
            btnThemMoi.DisabledState.CustomBorderColor = Color.DarkGray;
            btnThemMoi.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnThemMoi.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnThemMoi.Font = new Font("Segoe UI", 9F);
            btnThemMoi.ForeColor = Color.White;
            btnThemMoi.Location = new Point(6, 528);
            btnThemMoi.Name = "btnThemMoi";
            btnThemMoi.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnThemMoi.Size = new Size(180, 72);
            btnThemMoi.TabIndex = 1;
            btnThemMoi.Text = "Thêm";
            btnThemMoi.Click += btnThemMoi_Click;
            // 
            // btnSua
            // 
            btnSua.CustomizableEdges = customizableEdges7;
            btnSua.DisabledState.BorderColor = Color.DarkGray;
            btnSua.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSua.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnSua.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnSua.Font = new Font("Segoe UI", 9F);
            btnSua.ForeColor = Color.White;
            btnSua.Location = new Point(224, 528);
            btnSua.Name = "btnSua";
            btnSua.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnSua.Size = new Size(180, 72);
            btnSua.TabIndex = 2;
            btnSua.Text = "Sửa";
            btnSua.Click += btnSua_Click;
            // 
            // dgvNhanVien
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            dgvNhanVien.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(37, 99, 235);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvNhanVien.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvNhanVien.ColumnHeadersHeight = 29;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvNhanVien.DefaultCellStyle = dataGridViewCellStyle3;
            dgvNhanVien.Dock = DockStyle.Fill;
            dgvNhanVien.GridColor = Color.FromArgb(226, 232, 240);
            dgvNhanVien.Location = new Point(18, 21);
            dgvNhanVien.Margin = new Padding(3, 4, 3, 4);
            dgvNhanVien.Name = "dgvNhanVien";
            dgvNhanVien.RowHeadersVisible = false;
            dgvNhanVien.RowHeadersWidth = 51;
            dgvNhanVien.RowTemplate.Height = 40;
            dgvNhanVien.Size = new Size(581, 558);
            dgvNhanVien.TabIndex = 0;
            dgvNhanVien.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvNhanVien.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvNhanVien.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgvNhanVien.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvNhanVien.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvNhanVien.ThemeStyle.BackColor = Color.White;
            dgvNhanVien.ThemeStyle.GridColor = Color.FromArgb(226, 232, 240);
            dgvNhanVien.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(37, 99, 235);
            dgvNhanVien.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvNhanVien.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvNhanVien.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvNhanVien.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvNhanVien.ThemeStyle.HeaderStyle.Height = 29;
            dgvNhanVien.ThemeStyle.ReadOnly = false;
            dgvNhanVien.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvNhanVien.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvNhanVien.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvNhanVien.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgvNhanVien.ThemeStyle.RowsStyle.Height = 40;
            dgvNhanVien.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvNhanVien.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // FrmNhanVien
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(914, 600);
            Controls.Add(guna2PanelContent);
            Controls.Add(guna2PanelSidebar);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmNhanVien";
            Text = "FrmNhanVien";
            Load += FrmNhanVien_Load_1;
            guna2PanelSidebar.ResumeLayout(false);
            guna2PanelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2PanelSidebar;
        private Guna.UI2.WinForms.Guna2Panel guna2PanelContent;
        private TreeView treeViewPhongBan;
        private Guna.UI2.WinForms.Guna2DataGridView dgvNhanVien;
        private Guna.UI2.WinForms.Guna2Button btnXoa;
        private Guna.UI2.WinForms.Guna2Button btnSua;
        private Guna.UI2.WinForms.Guna2Button btnThemMoi;
    }
}