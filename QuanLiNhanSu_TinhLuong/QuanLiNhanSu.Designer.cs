namespace QuanLiNhanSu_TinhLuong
{
    partial class QuanLiNhanSu
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
            components = new System.ComponentModel.Container();
            picAvatar = new PictureBox();
            btnChọnAnh = new Button();
            dgvNhanVien = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtHoTen = new TextBox();
            txtSdt = new TextBox();
            txtDiaChi = new TextBox();
            cboPhongBan = new ComboBox();
            cboChucVu = new ComboBox();
            numLuongCoBan = new NumericUpDown();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)picAvatar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numLuongCoBan).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // picAvatar
            // 
            picAvatar.BackColor = SystemColors.ControlLight;
            picAvatar.Location = new Point(12, 324);
            picAvatar.Name = "picAvatar";
            picAvatar.Size = new Size(75, 52);
            picAvatar.TabIndex = 0;
            picAvatar.TabStop = false;
            // 
            // btnChọnAnh
            // 
            btnChọnAnh.Location = new Point(12, 265);
            btnChọnAnh.Name = "btnChọnAnh";
            btnChọnAnh.Size = new Size(75, 23);
            btnChọnAnh.TabIndex = 1;
            btnChọnAnh.Text = "Chọn Ảnh";
            btnChọnAnh.UseVisualStyleBackColor = true;
            btnChọnAnh.Click += btnChọnAnh_Click;
            // 
            // dgvNhanVien
            // 
            dgvNhanVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNhanVien.Location = new Point(113, 200);
            dgvNhanVien.Name = "dgvNhanVien";
            dgvNhanVien.Size = new Size(675, 238);
            dgvNhanVien.TabIndex = 2;
            dgvNhanVien.CellContentClick += dgvNhanVien_CellContentClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(67, 43);
            label1.Name = "label1";
            label1.Size = new Size(66, 17);
            label1.TabIndex = 3;
            label1.Text = "Họ và Tên";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(67, 80);
            label2.Name = "label2";
            label2.Size = new Size(89, 17);
            label2.TabIndex = 4;
            label2.Text = "Số Điện Thoại";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(67, 114);
            label3.Name = "label3";
            label3.Size = new Size(49, 17);
            label3.TabIndex = 5;
            label3.Text = "Địa Chỉ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(427, 43);
            label4.Name = "label4";
            label4.Size = new Size(90, 17);
            label4.TabIndex = 6;
            label4.Text = "Lương Cơ Bản";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(427, 80);
            label5.Name = "label5";
            label5.Size = new Size(70, 17);
            label5.TabIndex = 7;
            label5.Text = "Phòng Ban";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(427, 114);
            label6.Name = "label6";
            label6.Size = new Size(56, 17);
            label6.TabIndex = 8;
            label6.Text = "Chức Vụ";
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(162, 37);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(100, 23);
            txtHoTen.TabIndex = 9;
            // 
            // txtSdt
            // 
            txtSdt.Location = new Point(162, 74);
            txtSdt.Name = "txtSdt";
            txtSdt.Size = new Size(100, 23);
            txtSdt.TabIndex = 10;
            // 
            // txtDiaChi
            // 
            txtDiaChi.Location = new Point(162, 108);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(100, 23);
            txtDiaChi.TabIndex = 11;
            // 
            // cboPhongBan
            // 
            cboPhongBan.FormattingEnabled = true;
            cboPhongBan.Location = new Point(523, 74);
            cboPhongBan.Name = "cboPhongBan";
            cboPhongBan.Size = new Size(121, 23);
            cboPhongBan.TabIndex = 12;
            // 
            // cboChucVu
            // 
            cboChucVu.FormattingEnabled = true;
            cboChucVu.Location = new Point(523, 108);
            cboChucVu.Name = "cboChucVu";
            cboChucVu.Size = new Size(121, 23);
            cboChucVu.TabIndex = 13;
            // 
            // numLuongCoBan
            // 
            numLuongCoBan.Location = new Point(523, 37);
            numLuongCoBan.Maximum = new decimal(new int[] { -727379968, 232, 0, 0 });
            numLuongCoBan.Name = "numLuongCoBan";
            numLuongCoBan.Size = new Size(120, 23);
            numLuongCoBan.TabIndex = 14;
            numLuongCoBan.ThousandsSeparator = true;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(214, 171);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(75, 23);
            btnThem.TabIndex = 15;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(355, 171);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(75, 23);
            btnSua.TabIndex = 16;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(497, 171);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(75, 23);
            btnXoa.TabIndex = 17;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // QuanLiNhanSu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(numLuongCoBan);
            Controls.Add(cboChucVu);
            Controls.Add(cboPhongBan);
            Controls.Add(txtDiaChi);
            Controls.Add(txtSdt);
            Controls.Add(txtHoTen);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvNhanVien);
            Controls.Add(btnChọnAnh);
            Controls.Add(picAvatar);
            Name = "QuanLiNhanSu";
            Text = "QuanLiNhanSu";
            WindowState = FormWindowState.Minimized;
            Load += QuanLiNhanSu_Load;
            ((System.ComponentModel.ISupportInitialize)picAvatar).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).EndInit();
            ((System.ComponentModel.ISupportInitialize)numLuongCoBan).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picAvatar;
        private Button btnChọnAnh;
        private DataGridView dgvNhanVien;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox txtHoTen;
        private TextBox txtSdt;
        private TextBox txtDiaChi;
        private ComboBox cboPhongBan;
        private ComboBox cboChucVu;
        private NumericUpDown numLuongCoBan;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private ErrorProvider errorProvider1;
    }
}