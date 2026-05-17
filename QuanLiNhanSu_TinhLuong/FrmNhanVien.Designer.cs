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
            components = new System.ComponentModel.Container();
            splitContainer1 = new SplitContainer();
            treeView1 = new TreeView();
            dgvNhanVien = new DataGridView();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new System.Drawing.Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(treeView1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(dgvNhanVien);
            splitContainer1.Size = new System.Drawing.Size(800, 450);
            splitContainer1.SplitterDistance = 250;
            splitContainer1.TabIndex = 0;
            // 
            // treeView1
            // 
            treeView1.Dock = DockStyle.Fill;
            treeView1.Location = new System.Drawing.Point(0, 0);
            treeView1.Name = "treeView1";
            treeView1.Size = new System.Drawing.Size(250, 450);
            treeView1.TabIndex = 0;
            // 
            // dgvNhanVien
            // 
            dgvNhanVien.Dock = DockStyle.Fill;
            dgvNhanVien.Location = new System.Drawing.Point(0, 0);
            dgvNhanVien.Name = "dgvNhanVien";
            dgvNhanVien.Size = new System.Drawing.Size(546, 450);
            dgvNhanVien.TabIndex = 0;
            // 
            // FrmNhanVien
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(splitContainer1);
            Name = "FrmNhanVien";
            Text = "FrmNhanVien";
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private TreeView treeView1;
        private DataGridView dgvNhanVien;
    }
}
