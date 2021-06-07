
namespace QLDiem
{
    partial class MainForm
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
            this.button_formKhoa = new System.Windows.Forms.Button();
            this.button_formSinhVien = new System.Windows.Forms.Button();
            this.button_MonHoc = new System.Windows.Forms.Button();
            this.button_formKetQua = new System.Windows.Forms.Button();
            this.button_thoat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_formKhoa
            // 
            this.button_formKhoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_formKhoa.Location = new System.Drawing.Point(55, 255);
            this.button_formKhoa.Name = "button_formKhoa";
            this.button_formKhoa.Size = new System.Drawing.Size(139, 50);
            this.button_formKhoa.TabIndex = 0;
            this.button_formKhoa.Text = "Khoa";
            this.button_formKhoa.UseVisualStyleBackColor = true;
            this.button_formKhoa.Click += new System.EventHandler(this.button_formKhoa_Click);
            // 
            // button_formSinhVien
            // 
            this.button_formSinhVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_formSinhVien.Location = new System.Drawing.Point(218, 255);
            this.button_formSinhVien.Name = "button_formSinhVien";
            this.button_formSinhVien.Size = new System.Drawing.Size(144, 50);
            this.button_formSinhVien.TabIndex = 0;
            this.button_formSinhVien.Text = "Sinh viên";
            this.button_formSinhVien.UseVisualStyleBackColor = true;
            this.button_formSinhVien.Click += new System.EventHandler(this.button_formSinhVien_Click);
            // 
            // button_MonHoc
            // 
            this.button_MonHoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_MonHoc.Location = new System.Drawing.Point(396, 255);
            this.button_MonHoc.Name = "button_MonHoc";
            this.button_MonHoc.Size = new System.Drawing.Size(139, 50);
            this.button_MonHoc.TabIndex = 0;
            this.button_MonHoc.Text = "Môn học";
            this.button_MonHoc.UseVisualStyleBackColor = true;
            this.button_MonHoc.Click += new System.EventHandler(this.button_MonHoc_Click);
            // 
            // button_formKetQua
            // 
            this.button_formKetQua.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_formKetQua.Location = new System.Drawing.Point(582, 255);
            this.button_formKetQua.Name = "button_formKetQua";
            this.button_formKetQua.Size = new System.Drawing.Size(139, 50);
            this.button_formKetQua.TabIndex = 0;
            this.button_formKetQua.Text = "Kết quả";
            this.button_formKetQua.UseVisualStyleBackColor = true;
            this.button_formKetQua.Click += new System.EventHandler(this.button_formKetQua_Click);
            // 
            // button_thoat
            // 
            this.button_thoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_thoat.Location = new System.Drawing.Point(582, 328);
            this.button_thoat.Name = "button_thoat";
            this.button_thoat.Size = new System.Drawing.Size(139, 50);
            this.button_thoat.TabIndex = 0;
            this.button_thoat.Text = "Thoát";
            this.button_thoat.UseVisualStyleBackColor = true;
            this.button_thoat.Click += new System.EventHandler(this.button_thoat_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_thoat);
            this.Controls.Add(this.button_formKetQua);
            this.Controls.Add(this.button_MonHoc);
            this.Controls.Add(this.button_formSinhVien);
            this.Controls.Add(this.button_formKhoa);
            this.Name = "MainForm";
            this.Text = "Quản lý điểm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_formKhoa;
        private System.Windows.Forms.Button button_formSinhVien;
        private System.Windows.Forms.Button button_MonHoc;
        private System.Windows.Forms.Button button_formKetQua;
        private System.Windows.Forms.Button button_thoat;
    }
}

