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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            button1 = new Button();
            button2 = new Button();
            dgvNhanVien = new DataGridView();
            btnLuuChamCong = new Button();
            btnXuatBaoCao = new Button();
            btnXuatExcel = new Button();
            btnChotLuong = new Button();
            printDocument1 = new System.Drawing.Printing.PrintDocument();
            printPreviewDialog1 = new PrintPreviewDialog();
            btnInBienLai = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(328, 383);
            button1.Name = "button1";
            button1.Size = new Size(182, 29);
            button1.TabIndex = 0;
            button1.Text = "Test AI Gemini";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(530, 383);
            button2.Name = "button2";
            button2.Size = new Size(197, 29);
            button2.TabIndex = 1;
            button2.Text = "Test Gửi Email";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // dgvNhanVien
            // 
            dgvNhanVien.ColumnHeadersHeight = 29;
            dgvNhanVien.Location = new Point(0, 0);
            dgvNhanVien.Margin = new Padding(3, 4, 3, 4);
            dgvNhanVien.Name = "dgvNhanVien";
            dgvNhanVien.RowHeadersWidth = 51;
            dgvNhanVien.Size = new Size(274, 200);
            dgvNhanVien.TabIndex = 5;
            // 
            // btnLuuChamCong
            // 
            btnLuuChamCong.Location = new Point(73, 427);
            btnLuuChamCong.Margin = new Padding(3, 4, 3, 4);
            btnLuuChamCong.Name = "btnLuuChamCong";
            btnLuuChamCong.Size = new Size(107, 39);
            btnLuuChamCong.TabIndex = 1;
            btnLuuChamCong.Text = "Chấm công";
            btnLuuChamCong.UseVisualStyleBackColor = true;
            btnLuuChamCong.Click += button1_Click;
            // 
            // btnXuatBaoCao
            // 
            btnXuatBaoCao.Location = new Point(249, 427);
            btnXuatBaoCao.Margin = new Padding(3, 4, 3, 4);
            btnXuatBaoCao.Name = "btnXuatBaoCao";
            btnXuatBaoCao.Size = new Size(151, 39);
            btnXuatBaoCao.TabIndex = 2;
            btnXuatBaoCao.Text = "Xuất file PDF";
            btnXuatBaoCao.UseVisualStyleBackColor = true;
            btnXuatBaoCao.Click += btnXuatBaoCao_Click;
            // 
            // btnXuatExcel
            // 
            btnXuatExcel.Location = new Point(465, 427);
            btnXuatExcel.Margin = new Padding(3, 4, 3, 4);
            btnXuatExcel.Name = "btnXuatExcel";
            btnXuatExcel.Size = new Size(107, 39);
            btnXuatExcel.TabIndex = 3;
            btnXuatExcel.Text = "Xuất Excel";
            btnXuatExcel.UseVisualStyleBackColor = true;
            btnXuatExcel.Click += btnXuatExcel_Click;
            // 
            // btnChotLuong
            // 
            btnChotLuong.Location = new Point(620, 427);
            btnChotLuong.Margin = new Padding(3, 4, 3, 4);
            btnChotLuong.Name = "btnChotLuong";
            btnChotLuong.Size = new Size(107, 39);
            btnChotLuong.TabIndex = 4;
            btnChotLuong.Text = "Chốt Lương";
            btnChotLuong.UseVisualStyleBackColor = true;
            btnChotLuong.Click += btnChotLuong_Click;
            // 
            // printDocument1
            // 
            printDocument1.PrintPage += printDocument1_PrintPage;
            // 
            // printPreviewDialog1
            // 
            printPreviewDialog1.AutoScrollMargin = new Size(0, 0);
            printPreviewDialog1.AutoScrollMinSize = new Size(0, 0);
            printPreviewDialog1.ClientSize = new Size(400, 300);
            printPreviewDialog1.Enabled = true;
            printPreviewDialog1.Icon = (Icon)resources.GetObject("printPreviewDialog1.Icon");
            printPreviewDialog1.Name = "printPreviewDialog1";
            printPreviewDialog1.Visible = false;
            // 
            // btnInBienLai
            // 
            btnInBienLai.Location = new Point(806, 427);
            btnInBienLai.Name = "btnInBienLai";
            btnInBienLai.Size = new Size(94, 29);
            btnInBienLai.TabIndex = 6;
            btnInBienLai.Text = "In Biên Lai";
            btnInBienLai.UseVisualStyleBackColor = true;
            btnInBienLai.Click += btnInBienLai_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(946, 451);
            Controls.Add(btnInBienLai);
            Controls.Add(button2);
            Controls.Add(button1);
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

        private Button button1;
        private Button button2;
        private DataGridView dgvNhanVien;
        private Button btnLuuChamCong;
        private Button btnXuatBaoCao;
        private Button btnXuatExcel;
        private Button btnChotLuong;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private PrintPreviewDialog printPreviewDialog1;
        private Button btnInBienLai;
    }
}
