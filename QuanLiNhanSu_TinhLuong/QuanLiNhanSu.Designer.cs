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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuanLiNhanSu));
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
            picAvatar.BackColor = Color.White;
            picAvatar.Location = new Point(777, 43);
            picAvatar.Margin = new Padding(3, 4, 3, 4);
            picAvatar.Name = "picAvatar";
            picAvatar.Size = new Size(101, 117);
            picAvatar.TabIndex = 0;
            picAvatar.TabStop = false;
            // 
            // btnChọnAnh
            // 
            btnChọnAnh.BackColor = Color.White;
            btnChọnAnh.ForeColor = Color.FromArgb(37, 99, 235);
            btnChọnAnh.Location = new Point(777, 171);
            btnChọnAnh.Margin = new Padding(3, 4, 3, 4);
            btnChọnAnh.Name = "btnChọnAnh";
            btnChọnAnh.Size = new Size(101, 48);
            btnChọnAnh.TabIndex = 1;
            btnChọnAnh.Text = "Chọn Ảnh";
            btnChọnAnh.UseVisualStyleBackColor = false;
            btnChọnAnh.Click += btnChọnAnh_Click;
            // 
            // dgvNhanVien
            // 
            dataGridViewCellStyle1.BackColor = Color.FromArgb(249, 250, 252);
            dgvNhanVien.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvNhanVien.BackgroundColor = Color.White;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(37, 99, 235);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvNhanVien.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvNhanVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvNhanVien.DefaultCellStyle = dataGridViewCellStyle3;
            dgvNhanVien.EnableHeadersVisualStyles = false;
            dgvNhanVien.GridColor = Color.FromArgb(229, 231, 235);
            dgvNhanVien.Location = new Point(32, 467);
            dgvNhanVien.Margin = new Padding(3, 4, 3, 4);
            dgvNhanVien.Name = "dgvNhanVien";
            dgvNhanVien.RowHeadersWidth = 51;
            dgvNhanVien.RowTemplate.Height = 36;
            dgvNhanVien.Size = new Size(850, 320);
            dgvNhanVien.TabIndex = 2;
            dgvNhanVien.CellContentClick += dgvNhanVien_CellContentClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F);
            label1.Location = new Point(32, 123);
            label1.Name = "label1";
            label1.Size = new Size(85, 23);
            label1.TabIndex = 3;
            label1.Text = "Họ và Tên";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F);
            label2.Location = new Point(32, 203);
            label2.Name = "label2";
            label2.Size = new Size(116, 23);
            label2.TabIndex = 4;
            label2.Text = "Số Điện Thoại";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F);
            label3.Location = new Point(32, 283);
            label3.Name = "label3";
            label3.Size = new Size(65, 23);
            label3.TabIndex = 5;
            label3.Text = "Địa Chỉ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F);
            label4.Location = new Point(446, 123);
            label4.Name = "label4";
            label4.Size = new Size(118, 23);
            label4.TabIndex = 6;
            label4.Text = "Lương Cơ Bản";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F);
            label5.Location = new Point(446, 203);
            label5.Name = "label5";
            label5.Size = new Size(94, 23);
            label5.TabIndex = 7;
            label5.Text = "Phòng Ban";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9.75F);
            label6.Location = new Point(446, 283);
            label6.Name = "label6";
            label6.Size = new Size(75, 23);
            label6.TabIndex = 8;
            label6.Text = "Chức Vụ";
            // 
            // txtHoTen
            // 
            txtHoTen.BackColor = Color.White;
            txtHoTen.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            txtHoTen.Location = new Point(32, 149);
            txtHoTen.Margin = new Padding(3, 4, 3, 4);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(297, 29);
            txtHoTen.TabIndex = 9;
            // 
            // txtSdt
            // 
            txtSdt.BackColor = Color.White;
            txtSdt.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            txtSdt.Location = new Point(32, 229);
            txtSdt.Margin = new Padding(3, 4, 3, 4);
            txtSdt.Name = "txtSdt";
            txtSdt.Size = new Size(297, 29);
            txtSdt.TabIndex = 10;
            // 
            // txtDiaChi
            // 
            txtDiaChi.BackColor = Color.White;
            txtDiaChi.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            txtDiaChi.Location = new Point(32, 309);
            txtDiaChi.Margin = new Padding(3, 4, 3, 4);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(297, 29);
            txtDiaChi.TabIndex = 11;
            // 
            // cboPhongBan
            // 
            cboPhongBan.BackColor = Color.White;
            cboPhongBan.Font = new Font("Segoe UI", 9.75F);
            cboPhongBan.FormattingEnabled = true;
            cboPhongBan.Location = new Point(446, 229);
            cboPhongBan.Margin = new Padding(3, 4, 3, 4);
            cboPhongBan.Name = "cboPhongBan";
            cboPhongBan.Size = new Size(297, 29);
            cboPhongBan.TabIndex = 12;
            // 
            // cboChucVu
            // 
            cboChucVu.BackColor = Color.White;
            cboChucVu.Font = new Font("Segoe UI", 9.75F);
            cboChucVu.FormattingEnabled = true;
            cboChucVu.Location = new Point(446, 309);
            cboChucVu.Margin = new Padding(3, 4, 3, 4);
            cboChucVu.Name = "cboChucVu";
            cboChucVu.Size = new Size(297, 29);
            cboChucVu.TabIndex = 13;
            // 
            // numLuongCoBan
            // 
            numLuongCoBan.Font = new Font("Segoe UI", 9.75F);
            numLuongCoBan.Location = new Point(446, 149);
            numLuongCoBan.Margin = new Padding(3, 4, 3, 4);
            numLuongCoBan.Maximum = new decimal(new int[] { -727379968, 232, 0, 0 });
            numLuongCoBan.Name = "numLuongCoBan";
            numLuongCoBan.Size = new Size(297, 29);
            numLuongCoBan.TabIndex = 14;
            numLuongCoBan.ThousandsSeparator = true;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.FromArgb(37, 99, 235);
            btnThem.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(32, 389);
            btnThem.Margin = new Padding(3, 4, 3, 4);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(137, 53);
            btnThem.TabIndex = 15;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.White;
            btnSua.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnSua.ForeColor = Color.FromArgb(37, 99, 235);
            btnSua.Location = new Point(187, 389);
            btnSua.Margin = new Padding(3, 4, 3, 4);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(137, 53);
            btnSua.TabIndex = 16;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.FromArgb(254, 226, 226);
            btnXoa.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnXoa.ForeColor = Color.FromArgb(220, 38, 38);
            btnXoa.Location = new Point(343, 389);
            btnXoa.Margin = new Padding(3, 4, 3, 4);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(137, 53);
            btnXoa.TabIndex = 17;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // QuanLiNhanSu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 251);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(914, 867);
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
            Font = new Font("Segoe UI", 9F);
            Margin = new Padding(3, 4, 3, 4);
            Name = "QuanLiNhanSu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "QuanLiNhanSu";
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