
namespace AL_G
{
    partial class FormMain
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
            this.dgvDsk = new System.Windows.Forms.DataGridView();
            this.txtSlDinh = new System.Windows.Forms.TextBox();
            this.lblSlDinh = new System.Windows.Forms.Label();
            this.btnNhapDinh = new System.Windows.Forms.Button();
            this.pbDoThi = new System.Windows.Forms.PictureBox();
            this.chkbCoHuong = new System.Windows.Forms.CheckBox();
            this.chkbCoTrongSo = new System.Windows.Forms.CheckBox();
            this.btnRandom = new System.Windows.Forms.Button();
            this.btnVeDoThi = new System.Windows.Forms.Button();
            this.btnDocFile = new System.Windows.Forms.Button();
            this.btnLuuDT = new System.Windows.Forms.Button();
            this.txtTimming = new System.Windows.Forms.TextBox();
            this.cbxCTDL = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDsk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDoThi)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDsk
            // 
            this.dgvDsk.AllowUserToAddRows = false;
            this.dgvDsk.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDsk.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDsk.Location = new System.Drawing.Point(17, 221);
            this.dgvDsk.Name = "dgvDsk";
            this.dgvDsk.RowHeadersWidth = 90;
            this.dgvDsk.RowTemplate.Height = 24;
            this.dgvDsk.Size = new System.Drawing.Size(596, 720);
            this.dgvDsk.TabIndex = 0;
            // 
            // txtSlDinh
            // 
            this.txtSlDinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSlDinh.Location = new System.Drawing.Point(113, 21);
            this.txtSlDinh.Multiline = true;
            this.txtSlDinh.Name = "txtSlDinh";
            this.txtSlDinh.Size = new System.Drawing.Size(106, 40);
            this.txtSlDinh.TabIndex = 1;
            // 
            // lblSlDinh
            // 
            this.lblSlDinh.AutoSize = true;
            this.lblSlDinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSlDinh.Location = new System.Drawing.Point(12, 24);
            this.lblSlDinh.Name = "lblSlDinh";
            this.lblSlDinh.Size = new System.Drawing.Size(95, 29);
            this.lblSlDinh.TabIndex = 2;
            this.lblSlDinh.Text = "Số đỉnh";
            // 
            // btnNhapDinh
            // 
            this.btnNhapDinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhapDinh.Location = new System.Drawing.Point(643, 12);
            this.btnNhapDinh.Name = "btnNhapDinh";
            this.btnNhapDinh.Size = new System.Drawing.Size(158, 40);
            this.btnNhapDinh.TabIndex = 3;
            this.btnNhapDinh.Text = "Nhập đỉnh";
            this.btnNhapDinh.UseVisualStyleBackColor = true;
            this.btnNhapDinh.Visible = false;
            this.btnNhapDinh.Click += new System.EventHandler(this.btnNhapDinh_Click);
            // 
            // pbDoThi
            // 
            this.pbDoThi.Location = new System.Drawing.Point(643, 91);
            this.pbDoThi.Name = "pbDoThi";
            this.pbDoThi.Size = new System.Drawing.Size(1127, 850);
            this.pbDoThi.TabIndex = 4;
            this.pbDoThi.TabStop = false;
            this.pbDoThi.Paint += new System.Windows.Forms.PaintEventHandler(this.pbDoThi_Paint);
            this.pbDoThi.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbDoThi_MouseMove);
            this.pbDoThi.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbDoThi_MouseUp);
            // 
            // chkbCoHuong
            // 
            this.chkbCoHuong.AutoSize = true;
            this.chkbCoHuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkbCoHuong.Location = new System.Drawing.Point(8, 91);
            this.chkbCoHuong.Name = "chkbCoHuong";
            this.chkbCoHuong.Size = new System.Drawing.Size(139, 33);
            this.chkbCoHuong.TabIndex = 5;
            this.chkbCoHuong.Text = "Có hướng";
            this.chkbCoHuong.UseVisualStyleBackColor = true;
            this.chkbCoHuong.CheckedChanged += new System.EventHandler(this.chkbCoHuong_CheckedChanged);
            // 
            // chkbCoTrongSo
            // 
            this.chkbCoTrongSo.AutoSize = true;
            this.chkbCoTrongSo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkbCoTrongSo.Location = new System.Drawing.Point(156, 91);
            this.chkbCoTrongSo.Name = "chkbCoTrongSo";
            this.chkbCoTrongSo.Size = new System.Drawing.Size(159, 33);
            this.chkbCoTrongSo.TabIndex = 6;
            this.chkbCoTrongSo.Text = "Có trọng số";
            this.chkbCoTrongSo.UseVisualStyleBackColor = true;
            this.chkbCoTrongSo.CheckedChanged += new System.EventHandler(this.chkbCoTrongSo_CheckedChanged);
            // 
            // btnRandom
            // 
            this.btnRandom.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRandom.Location = new System.Drawing.Point(244, 21);
            this.btnRandom.Name = "btnRandom";
            this.btnRandom.Size = new System.Drawing.Size(180, 40);
            this.btnRandom.TabIndex = 7;
            this.btnRandom.Text = "Ngẫu nhiên";
            this.btnRandom.UseVisualStyleBackColor = true;
            this.btnRandom.Click += new System.EventHandler(this.btnRandom_Click);
            // 
            // btnVeDoThi
            // 
            this.btnVeDoThi.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVeDoThi.Location = new System.Drawing.Point(820, 12);
            this.btnVeDoThi.Name = "btnVeDoThi";
            this.btnVeDoThi.Size = new System.Drawing.Size(180, 40);
            this.btnVeDoThi.TabIndex = 8;
            this.btnVeDoThi.Text = "Vẽ đồ thị";
            this.btnVeDoThi.UseVisualStyleBackColor = true;
            this.btnVeDoThi.Visible = false;
            this.btnVeDoThi.Click += new System.EventHandler(this.btnVeDoThi_Click);
            // 
            // btnDocFile
            // 
            this.btnDocFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDocFile.Location = new System.Drawing.Point(156, 157);
            this.btnDocFile.Name = "btnDocFile";
            this.btnDocFile.Size = new System.Drawing.Size(180, 40);
            this.btnDocFile.TabIndex = 9;
            this.btnDocFile.Text = "Đọc file";
            this.btnDocFile.UseVisualStyleBackColor = true;
            this.btnDocFile.Click += new System.EventHandler(this.btnDocFile_Click);
            // 
            // btnLuuDT
            // 
            this.btnLuuDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuuDT.Location = new System.Drawing.Point(17, 157);
            this.btnLuuDT.Name = "btnLuuDT";
            this.btnLuuDT.Size = new System.Drawing.Size(126, 40);
            this.btnLuuDT.TabIndex = 10;
            this.btnLuuDT.Text = "Lưu";
            this.btnLuuDT.UseVisualStyleBackColor = true;
            this.btnLuuDT.Click += new System.EventHandler(this.btnLuuDT_Click);
            // 
            // txtTimming
            // 
            this.txtTimming.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimming.Location = new System.Drawing.Point(368, 157);
            this.txtTimming.Multiline = true;
            this.txtTimming.Name = "txtTimming";
            this.txtTimming.Size = new System.Drawing.Size(245, 40);
            this.txtTimming.TabIndex = 11;
            // 
            // cbxCTDL
            // 
            this.cbxCTDL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCTDL.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxCTDL.FormattingEnabled = true;
            this.cbxCTDL.Items.AddRange(new object[] {
            "Danh sách liên kết đơn",
            "Ngăn xếp"});
            this.cbxCTDL.Location = new System.Drawing.Point(331, 87);
            this.cbxCTDL.Name = "cbxCTDL";
            this.cbxCTDL.Size = new System.Drawing.Size(282, 37);
            this.cbxCTDL.TabIndex = 12;
            this.cbxCTDL.SelectedIndexChanged += new System.EventHandler(this.cbxCTDL_SelectedIndexChanged);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1782, 953);
            this.Controls.Add(this.cbxCTDL);
            this.Controls.Add(this.txtTimming);
            this.Controls.Add(this.btnLuuDT);
            this.Controls.Add(this.btnDocFile);
            this.Controls.Add(this.btnVeDoThi);
            this.Controls.Add(this.btnRandom);
            this.Controls.Add(this.chkbCoTrongSo);
            this.Controls.Add(this.chkbCoHuong);
            this.Controls.Add(this.pbDoThi);
            this.Controls.Add(this.btnNhapDinh);
            this.Controls.Add(this.lblSlDinh);
            this.Controls.Add(this.txtSlDinh);
            this.Controls.Add(this.dgvDsk);
            this.Name = "FormMain";
            this.Text = "Biểu diễn đồ thị với danh sách kề";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDsk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDoThi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDsk;
        private System.Windows.Forms.TextBox txtSlDinh;
        private System.Windows.Forms.Label lblSlDinh;
        private System.Windows.Forms.Button btnNhapDinh;
        private System.Windows.Forms.PictureBox pbDoThi;
        private System.Windows.Forms.CheckBox chkbCoHuong;
        private System.Windows.Forms.CheckBox chkbCoTrongSo;
        private System.Windows.Forms.Button btnRandom;
        private System.Windows.Forms.Button btnVeDoThi;
        private System.Windows.Forms.Button btnDocFile;
        private System.Windows.Forms.Button btnLuuDT;
        private System.Windows.Forms.TextBox txtTimming;
        private System.Windows.Forms.ComboBox cbxCTDL;
    }
}

