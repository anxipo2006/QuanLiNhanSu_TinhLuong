namespace QuanLiNhanSu_TinhLuong
{
    partial class FrmThemSuaNV
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
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            picAvatar = new PictureBox();
            btnChonAnh = new Button();
            txtName = new TextBox();
            dtpBirth = new DateTimePicker();
            cboPhongBan = new ComboBox();
            cboChucVu = new ComboBox();
            tabPage2 = new TabPage();
            txtLuong = new TextBox();
            txtSoHopDong = new TextBox();
            dtpStart = new DateTimePicker();
            toolTip1 = new ToolTip(components);

            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar).BeginInit();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new System.Drawing.Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(600, 400);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(picAvatar);
            tabPage1.Controls.Add(btnChonAnh);
            tabPage1.Controls.Add(txtName);
            tabPage1.Controls.Add(dtpBirth);
            tabPage1.Controls.Add(cboPhongBan);
            tabPage1.Controls.Add(cboChucVu);
            tabPage1.Location = new System.Drawing.Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new System.Drawing.Size(592, 372);
            tabPage1.Text = "Thông tin cá nhân";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // picAvatar
            // 
            picAvatar.Location = new System.Drawing.Point(16, 16);
            picAvatar.Name = "picAvatar";
            picAvatar.Size = new System.Drawing.Size(120, 140);
            picAvatar.TabIndex = 0;
            picAvatar.TabStop = false;
            // 
            // btnChonAnh
            // 
            btnChonAnh.Location = new System.Drawing.Point(16, 166);
            btnChonAnh.Name = "btnChonAnh";
            btnChonAnh.Size = new System.Drawing.Size(120, 32);
            btnChonAnh.TabIndex = 1;
            btnChonAnh.Text = "Ch?n ?nh";
            btnChonAnh.UseVisualStyleBackColor = true;
            toolTip1.SetToolTip(btnChonAnh, "Ch?n ?nh ??i di?n cho nhân viên");
            // 
            // txtName
            // 
            txtName.Location = new System.Drawing.Point(160, 24);
            txtName.Name = "txtName";
            txtName.PlaceholderText = "H? và tên";
            txtName.Size = new System.Drawing.Size(360, 23);
            txtName.TabIndex = 2;
            // 
            // dtpBirth
            // 
            dtpBirth.Location = new System.Drawing.Point(160, 64);
            dtpBirth.Name = "dtpBirth";
            dtpBirth.Size = new System.Drawing.Size(200, 23);
            dtpBirth.TabIndex = 3;
            // 
            // cboPhongBan
            // 
            cboPhongBan.Location = new System.Drawing.Point(160, 104);
            cboPhongBan.Name = "cboPhongBan";
            cboPhongBan.Size = new System.Drawing.Size(200, 23);
            cboPhongBan.TabIndex = 4;
            // 
            // cboChucVu
            // 
            cboChucVu.Location = new System.Drawing.Point(160, 144);
            cboChucVu.Name = "cboChucVu";
            cboChucVu.Size = new System.Drawing.Size(200, 23);
            cboChucVu.TabIndex = 5;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(txtLuong);
            tabPage2.Controls.Add(txtSoHopDong);
            tabPage2.Controls.Add(dtpStart);
            tabPage2.Location = new System.Drawing.Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new System.Drawing.Size(592, 372);
            tabPage2.Text = "H?p ??ng lao ??ng";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtLuong
            // 
            txtLuong.Location = new System.Drawing.Point(20, 24);
            txtLuong.Name = "txtLuong";
            txtLuong.PlaceholderText = "L??ng c? b?n";
            txtLuong.Size = new System.Drawing.Size(200, 23);
            txtLuong.TabIndex = 0;
            // 
            // txtSoHopDong
            // 
            txtSoHopDong.Location = new System.Drawing.Point(20, 64);
            txtSoHopDong.Name = "txtSoHopDong";
            txtSoHopDong.PlaceholderText = "S? h?p ??ng";
            txtSoHopDong.Size = new System.Drawing.Size(200, 23);
            txtSoHopDong.TabIndex = 1;
            // 
            // dtpStart
            // 
            dtpStart.Location = new System.Drawing.Point(20, 104);
            dtpStart.Name = "dtpStart";
            dtpStart.Size = new System.Drawing.Size(200, 23);
            dtpStart.TabIndex = 2;
            // 
            // FrmThemSuaNV
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(600, 400);
            Controls.Add(tabControl1);
            Name = "FrmThemSuaNV";
            Text = "FrmThemSuaNV";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private PictureBox picAvatar;
        private Button btnChonAnh;
        private TextBox txtName;
        private DateTimePicker dtpBirth;
        private ComboBox cboPhongBan;
        private ComboBox cboChucVu;
        private TextBox txtLuong;
        private TextBox txtSoHopDong;
        private DateTimePicker dtpStart;
        private ToolTip toolTip1;
    }
}
