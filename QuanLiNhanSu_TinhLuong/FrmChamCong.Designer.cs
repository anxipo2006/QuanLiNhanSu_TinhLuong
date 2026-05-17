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
            monthCalendar1 = new MonthCalendar();
            dgvChamCong = new DataGridView();
            btnCoMat = new Button();
            btnVang = new Button();
            btnDiTre = new Button();
            toolTip1 = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)dgvChamCong).BeginInit();
            SuspendLayout();
            // 
            // monthCalendar1
            // 
            monthCalendar1.Location = new System.Drawing.Point(18, 18);
            monthCalendar1.MaxSelectionCount = 31;
            // 
            // dgvChamCong
            // 
            dgvChamCong.Location = new System.Drawing.Point(18, 200);
            dgvChamCong.Name = "dgvChamCong";
            dgvChamCong.Size = new System.Drawing.Size(740, 300);
            dgvChamCong.TabIndex = 1;
            // 
            // btnCoMat
            // 
            btnCoMat.Location = new System.Drawing.Point(18, 140);
            btnCoMat.Name = "btnCoMat";
            btnCoMat.Size = new System.Drawing.Size(100, 36);
            btnCoMat.Text = "Có m?t";
            toolTip1.SetToolTip(btnCoMat, "?ánh d?u có m?t cho nhân viên ch?n");
            // 
            // btnVang
            // 
            btnVang.Location = new System.Drawing.Point(130, 140);
            btnVang.Name = "btnVang";
            btnVang.Size = new System.Drawing.Size(100, 36);
            btnVang.Text = "V?ng";
            toolTip1.SetToolTip(btnVang, "?ánh d?u v?ng");
            // 
            // btnDiTre
            // 
            btnDiTre.Location = new System.Drawing.Point(242, 140);
            btnDiTre.Name = "btnDiTre";
            btnDiTre.Size = new System.Drawing.Size(100, 36);
            btnDiTre.Text = "?i tr?";
            toolTip1.SetToolTip(btnDiTre, "?ánh d?u ?i tr?");
            // 
            // FrmChamCong
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(784, 561);
            Controls.Add(btnDiTre);
            Controls.Add(btnVang);
            Controls.Add(btnCoMat);
            Controls.Add(dgvChamCong);
            Controls.Add(monthCalendar1);
            Name = "FrmChamCong";
            Text = "FrmChamCong";
            ((System.ComponentModel.ISupportInitialize)dgvChamCong).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private MonthCalendar monthCalendar1;
        private DataGridView dgvChamCong;
        private Button btnCoMat;
        private Button btnVang;
        private Button btnDiTre;
        private ToolTip toolTip1;
    }
}
