namespace QuanLiNhanSu_TinhLuong
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            button1 = new Button();
            button2 = new Button();
            dgvNhanVien = new DataGridView();
            btnLuuChamCong = new Button();
            btnXuatBaoCao = new Button();
            btnXuatExcel = new Button();
            btnChotLuong = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(245, 243, 255);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(235, 230, 255);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            button1.ForeColor = Color.FromArgb(124, 58, 237);
            button1.Location = new Point(370, 700);
            button1.Name = "button1";
            button1.Size = new Size(183, 48);
            button1.TabIndex = 0;
            button1.Text = "Test AI Gemini";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(225, 249, 255);
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.MouseOverBackColor = Color.FromArgb(207, 243, 247);
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            button2.ForeColor = Color.FromArgb(6, 182, 212);
            button2.Location = new Point(609, 700);
            button2.Name = "button2";
            button2.Size = new Size(183, 48);
            button2.TabIndex = 1;
            button2.Text = "Test Gửi Email";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // dgvNhanVien
            // 
            dataGridViewCellStyle1.BackColor = Color.FromArgb(249, 250, 252);
            dgvNhanVien.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvNhanVien.BackgroundColor = Color.White;
            dgvNhanVien.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(37, 99, 235);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvNhanVien.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvNhanVien.ColumnHeadersHeight = 44;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(232, 244, 255);
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvNhanVien.DefaultCellStyle = dataGridViewCellStyle3;
            dgvNhanVien.EnableHeadersVisualStyles = false;
            dgvNhanVien.GridColor = Color.FromArgb(229, 231, 235);
            dgvNhanVien.Location = new Point(46, 133);
            dgvNhanVien.Margin = new Padding(3, 4, 3, 4);
            dgvNhanVien.Name = "dgvNhanVien";
            dgvNhanVien.RowHeadersWidth = 51;
            dgvNhanVien.RowTemplate.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvNhanVien.RowTemplate.Height = 40;
            dgvNhanVien.Size = new Size(1051, 480);
            dgvNhanVien.TabIndex = 5;
            // 
            // btnLuuChamCong
            // 
            btnLuuChamCong.BackColor = Color.FromArgb(37, 99, 235);
            btnLuuChamCong.FlatAppearance.BorderSize = 0;
            btnLuuChamCong.FlatAppearance.MouseOverBackColor = Color.FromArgb(29, 78, 216);
            btnLuuChamCong.FlatStyle = FlatStyle.Flat;
            btnLuuChamCong.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnLuuChamCong.ForeColor = Color.White;
            btnLuuChamCong.Location = new Point(183, 640);
            btnLuuChamCong.Margin = new Padding(3, 4, 3, 4);
            btnLuuChamCong.Name = "btnLuuChamCong";
            btnLuuChamCong.Size = new Size(183, 53);
            btnLuuChamCong.TabIndex = 1;
            btnLuuChamCong.Text = "Chấm công";
            btnLuuChamCong.UseVisualStyleBackColor = false;
            btnLuuChamCong.Click += button1_Click;
            // 
            // btnXuatBaoCao
            // 
            btnXuatBaoCao.BackColor = Color.FromArgb(254, 226, 226);
            btnXuatBaoCao.FlatAppearance.BorderSize = 0;
            btnXuatBaoCao.FlatAppearance.MouseOverBackColor = Color.FromArgb(252, 210, 210);
            btnXuatBaoCao.FlatStyle = FlatStyle.Flat;
            btnXuatBaoCao.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnXuatBaoCao.ForeColor = Color.FromArgb(153, 27, 27);
            btnXuatBaoCao.Location = new Point(389, 640);
            btnXuatBaoCao.Margin = new Padding(3, 4, 3, 4);
            btnXuatBaoCao.Name = "btnXuatBaoCao";
            btnXuatBaoCao.Size = new Size(183, 53);
            btnXuatBaoCao.TabIndex = 2;
            btnXuatBaoCao.Text = "Xuất file PDF";
            btnXuatBaoCao.UseVisualStyleBackColor = false;
            btnXuatBaoCao.Click += btnXuatBaoCao_Click;
            // 
            // btnXuatExcel
            // 
            btnXuatExcel.BackColor = Color.FromArgb(236, 252, 245);
            btnXuatExcel.FlatAppearance.BorderSize = 0;
            btnXuatExcel.FlatAppearance.MouseOverBackColor = Color.FromArgb(220, 248, 230);
            btnXuatExcel.FlatStyle = FlatStyle.Flat;
            btnXuatExcel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnXuatExcel.ForeColor = Color.FromArgb(16, 185, 129);
            btnXuatExcel.Location = new Point(594, 640);
            btnXuatExcel.Margin = new Padding(3, 4, 3, 4);
            btnXuatExcel.Name = "btnXuatExcel";
            btnXuatExcel.Size = new Size(183, 53);
            btnXuatExcel.TabIndex = 3;
            btnXuatExcel.Text = "Xuất Excel";
            btnXuatExcel.UseVisualStyleBackColor = false;
            btnXuatExcel.Click += btnXuatExcel_Click;
            // 
            // btnChotLuong
            // 
            btnChotLuong.BackColor = Color.FromArgb(30, 64, 175);
            btnChotLuong.FlatAppearance.BorderSize = 0;
            btnChotLuong.FlatAppearance.MouseOverBackColor = Color.FromArgb(24, 54, 150);
            btnChotLuong.FlatStyle = FlatStyle.Flat;
            btnChotLuong.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnChotLuong.ForeColor = Color.White;
            btnChotLuong.Location = new Point(800, 640);
            btnChotLuong.Margin = new Padding(3, 4, 3, 4);
            btnChotLuong.Name = "btnChotLuong";
            btnChotLuong.Size = new Size(183, 53);
            btnChotLuong.TabIndex = 4;
            btnChotLuong.Text = "Chốt Lương";
            btnChotLuong.UseVisualStyleBackColor = false;
            btnChotLuong.Click += btnChotLuong_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 251);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1143, 800);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(btnChotLuong);
            Controls.Add(btnXuatExcel);
            Controls.Add(btnXuatBaoCao);
            Controls.Add(btnLuuChamCong);
            Controls.Add(dgvNhanVien);
            Font = new Font("Segoe UI", 9F);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button button1;
        private Button button2;
        private DataGridView dgvNhanVien;
        private Button btnLuuChamCong;
        private Button btnXuatBaoCao;
        private Button btnXuatExcel;
        private Button btnChotLuong;
    }
}
