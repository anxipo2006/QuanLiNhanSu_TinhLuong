namespace QuanLiNhanSu_TinhLuong
{
    partial class FrmDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDashboard));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnChamCong = new Guna.UI2.WinForms.Guna2Button();
            btnQuanLyNhanVien = new Guna.UI2.WinForms.Guna2Button();
            btnTinhLuong = new Guna.UI2.WinForms.Guna2Button();
            lblHeader = new Guna.UI2.WinForms.Guna2HtmlLabel();
            SuspendLayout();
            // 
            // btnChamCong
            // 
            btnChamCong.BorderRadius = 20;
            btnChamCong.CustomizableEdges = customizableEdges1;
            btnChamCong.DisabledState.BorderColor = Color.DarkGray;
            btnChamCong.DisabledState.CustomBorderColor = Color.DarkGray;
            btnChamCong.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnChamCong.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnChamCong.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnChamCong.ForeColor = Color.White;
            btnChamCong.Image = (Image)resources.GetObject("btnChamCong.Image");
            btnChamCong.ImageSize = new Size(60, 60);
            btnChamCong.Location = new Point(371, 195);
            btnChamCong.Name = "btnChamCong";
            btnChamCong.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnChamCong.Size = new Size(252, 88);
            btnChamCong.TabIndex = 0;
            btnChamCong.Text = "Chấm Công";
            btnChamCong.Click += btnChamCong_Click;
            // 
            // btnQuanLyNhanVien
            // 
            btnQuanLyNhanVien.BorderRadius = 20;
            btnQuanLyNhanVien.CustomizableEdges = customizableEdges3;
            btnQuanLyNhanVien.DisabledState.BorderColor = Color.DarkGray;
            btnQuanLyNhanVien.DisabledState.CustomBorderColor = Color.DarkGray;
            btnQuanLyNhanVien.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnQuanLyNhanVien.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnQuanLyNhanVien.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnQuanLyNhanVien.ForeColor = Color.White;
            btnQuanLyNhanVien.Image = (Image)resources.GetObject("btnQuanLyNhanVien.Image");
            btnQuanLyNhanVien.ImageSize = new Size(60, 60);
            btnQuanLyNhanVien.Location = new Point(12, 195);
            btnQuanLyNhanVien.Name = "btnQuanLyNhanVien";
            btnQuanLyNhanVien.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnQuanLyNhanVien.Size = new Size(252, 88);
            btnQuanLyNhanVien.TabIndex = 1;
            btnQuanLyNhanVien.Text = "Quản lý Nhân sự";
            btnQuanLyNhanVien.Click += btnQuanLyNhanVien_Click;
            // 
            // btnTinhLuong
            // 
            btnTinhLuong.BorderRadius = 20;
            btnTinhLuong.CustomizableEdges = customizableEdges5;
            btnTinhLuong.DisabledState.BorderColor = Color.DarkGray;
            btnTinhLuong.DisabledState.CustomBorderColor = Color.DarkGray;
            btnTinhLuong.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnTinhLuong.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnTinhLuong.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTinhLuong.ForeColor = Color.White;
            btnTinhLuong.Image = (Image)resources.GetObject("btnTinhLuong.Image");
            btnTinhLuong.ImageSize = new Size(60, 60);
            btnTinhLuong.Location = new Point(724, 195);
            btnTinhLuong.Name = "btnTinhLuong";
            btnTinhLuong.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnTinhLuong.Size = new Size(252, 88);
            btnTinhLuong.TabIndex = 2;
            btnTinhLuong.Text = "Bảng Lương";
            btnTinhLuong.Click += btnTinhLuong_Click;
            // 
            // lblHeader
            // 
            lblHeader.BackColor = Color.Transparent;
            lblHeader.Font = new Font("Segoe UI Black", 19.8000011F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblHeader.ForeColor = Color.FromArgb(0, 192, 192);
            lblHeader.Location = new Point(262, 31);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(520, 47);
            lblHeader.TabIndex = 3;
            lblHeader.Text = "HỆ THỐNG QUẢN LÝ TỔNG THỂ";
            // 
            // FrmDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(991, 507);
            Controls.Add(lblHeader);
            Controls.Add(btnQuanLyNhanVien);
            Controls.Add(btnChamCong);
            Controls.Add(btnTinhLuong);
            Name = "FrmDashboard";
            Text = "FrmDashboard";
            Load += FrmDashboard_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnChamCong;
        private Guna.UI2.WinForms.Guna2Button btnQuanLyNhanVien;
        private Guna.UI2.WinForms.Guna2Button btnTinhLuong;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblHeader;
    }
}