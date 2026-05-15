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
            dgvNhanVien = new DataGridView();
            btnLuuChamCong = new Button();
            btnXuatBaoCao = new Button();
            btnXuatExcel = new Button();
            btnChotLuong = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).BeginInit();
            SuspendLayout();
            // 
            // dgvNhanVien
            // 
            dgvNhanVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNhanVien.Location = new Point(158, 104);
            dgvNhanVien.Name = "dgvNhanVien";
            dgvNhanVien.RowHeadersWidth = 51;
            dgvNhanVien.Size = new Size(555, 188);
            dgvNhanVien.TabIndex = 0;
            dgvNhanVien.CellContentClick += dataGridView1_CellContentClick;
            // 
            // btnLuuChamCong
            // 
            btnLuuChamCong.Location = new Point(64, 320);
            btnLuuChamCong.Name = "btnLuuChamCong";
            btnLuuChamCong.Size = new Size(94, 29);
            btnLuuChamCong.TabIndex = 1;
            btnLuuChamCong.Text = "Chấm công";
            btnLuuChamCong.UseVisualStyleBackColor = true;
            btnLuuChamCong.Click += button1_Click;
            // 
            // btnXuatBaoCao
            // 
            btnXuatBaoCao.Location = new Point(218, 320);
            btnXuatBaoCao.Name = "btnXuatBaoCao";
            btnXuatBaoCao.Size = new Size(132, 29);
            btnXuatBaoCao.TabIndex = 2;
            btnXuatBaoCao.Text = "Xuất file PDF";
            btnXuatBaoCao.UseVisualStyleBackColor = true;
            btnXuatBaoCao.Click += btnXuatBaoCao_Click;
            // 
            // btnXuatExcel
            // 
            btnXuatExcel.Location = new Point(407, 320);
            btnXuatExcel.Name = "btnXuatExcel";
            btnXuatExcel.Size = new Size(94, 29);
            btnXuatExcel.TabIndex = 3;
            btnXuatExcel.Text = "Xuất Excel";
            btnXuatExcel.UseVisualStyleBackColor = true;
            btnXuatExcel.Click += btnXuatExcel_Click;
            // 
            // btnChotLuong
            // 
            btnChotLuong.Location = new Point(606, 320);
            btnChotLuong.Name = "btnChotLuong";
            btnChotLuong.Size = new Size(94, 29);
            btnChotLuong.TabIndex = 4;
            btnChotLuong.Text = "Chốt Lương";
            btnChotLuong.UseVisualStyleBackColor = true;
            btnChotLuong.Click += btnChotLuong_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(946, 450);
            Controls.Add(btnChotLuong);
            Controls.Add(btnXuatExcel);
            Controls.Add(btnXuatBaoCao);
            Controls.Add(btnLuuChamCong);
            Controls.Add(dgvNhanVien);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvNhanVien;
        private Button btnLuuChamCong;
        private Button btnXuatBaoCao;
        private Button btnXuatExcel;
        private Button btnChotLuong;
    }
}
