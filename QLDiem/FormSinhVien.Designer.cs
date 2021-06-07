
namespace QLDiem
{
    partial class FormSinhVien
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.MaSV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoVaTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phai = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.NgaySinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaK = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.panel_inp = new System.Windows.Forms.Panel();
            this.comboBox_MaK = new System.Windows.Forms.ComboBox();
            this.dateTimePicker_NgaySinh = new System.Windows.Forms.DateTimePicker();
            this.comboBox_Phai = new System.Windows.Forms.ComboBox();
            this.textBox_HoVaTen = new System.Windows.Forms.TextBox();
            this.textBox_MaSV = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button_sua = new System.Windows.Forms.Button();
            this.button_xoa = new System.Windows.Forms.Button();
            this.button_thoat = new System.Windows.Forms.Button();
            this.button_them = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel_inp.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaSV,
            this.HoVaTen,
            this.Phai,
            this.NgaySinh,
            this.MaK});
            this.dataGridView1.Location = new System.Drawing.Point(323, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(598, 426);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // MaSV
            // 
            this.MaSV.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MaSV.DataPropertyName = "MaSV";
            this.MaSV.HeaderText = "MSSV";
            this.MaSV.Name = "MaSV";
            this.MaSV.ReadOnly = true;
            // 
            // HoVaTen
            // 
            this.HoVaTen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.HoVaTen.DataPropertyName = "HoVaTen";
            this.HoVaTen.HeaderText = "Họ tên";
            this.HoVaTen.Name = "HoVaTen";
            // 
            // Phai
            // 
            this.Phai.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Phai.DataPropertyName = "Phai";
            this.Phai.HeaderText = "Phái";
            this.Phai.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.Phai.Name = "Phai";
            this.Phai.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Phai.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // NgaySinh
            // 
            this.NgaySinh.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NgaySinh.DataPropertyName = "NgaySinh";
            this.NgaySinh.HeaderText = "Ngày sinh";
            this.NgaySinh.Name = "NgaySinh";
            // 
            // MaK
            // 
            this.MaK.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MaK.DataPropertyName = "MaK";
            this.MaK.HeaderText = "Mã khoa";
            this.MaK.Name = "MaK";
            this.MaK.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MaK.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // panel_inp
            // 
            this.panel_inp.Controls.Add(this.comboBox_MaK);
            this.panel_inp.Controls.Add(this.dateTimePicker_NgaySinh);
            this.panel_inp.Controls.Add(this.comboBox_Phai);
            this.panel_inp.Controls.Add(this.textBox_HoVaTen);
            this.panel_inp.Controls.Add(this.textBox_MaSV);
            this.panel_inp.Controls.Add(this.label5);
            this.panel_inp.Controls.Add(this.label4);
            this.panel_inp.Controls.Add(this.label3);
            this.panel_inp.Controls.Add(this.label2);
            this.panel_inp.Controls.Add(this.label1);
            this.panel_inp.Location = new System.Drawing.Point(12, 12);
            this.panel_inp.Name = "panel_inp";
            this.panel_inp.Size = new System.Drawing.Size(305, 206);
            this.panel_inp.TabIndex = 1;
            // 
            // comboBox_MaK
            // 
            this.comboBox_MaK.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_MaK.FormattingEnabled = true;
            this.comboBox_MaK.Location = new System.Drawing.Point(105, 166);
            this.comboBox_MaK.Name = "comboBox_MaK";
            this.comboBox_MaK.Size = new System.Drawing.Size(197, 27);
            this.comboBox_MaK.TabIndex = 4;
            // 
            // dateTimePicker_NgaySinh
            // 
            this.dateTimePicker_NgaySinh.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_NgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_NgaySinh.Location = new System.Drawing.Point(105, 124);
            this.dateTimePicker_NgaySinh.MinDate = new System.DateTime(1930, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker_NgaySinh.Name = "dateTimePicker_NgaySinh";
            this.dateTimePicker_NgaySinh.Size = new System.Drawing.Size(200, 27);
            this.dateTimePicker_NgaySinh.TabIndex = 3;
            this.dateTimePicker_NgaySinh.ValueChanged += new System.EventHandler(this.dateTimePicker_NgaySinh_ValueChanged);
            // 
            // comboBox_Phai
            // 
            this.comboBox_Phai.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_Phai.FormattingEnabled = true;
            this.comboBox_Phai.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.comboBox_Phai.Location = new System.Drawing.Point(181, 84);
            this.comboBox_Phai.Name = "comboBox_Phai";
            this.comboBox_Phai.Size = new System.Drawing.Size(121, 27);
            this.comboBox_Phai.TabIndex = 2;
            // 
            // textBox_HoVaTen
            // 
            this.textBox_HoVaTen.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_HoVaTen.Location = new System.Drawing.Point(109, 47);
            this.textBox_HoVaTen.Name = "textBox_HoVaTen";
            this.textBox_HoVaTen.Size = new System.Drawing.Size(193, 27);
            this.textBox_HoVaTen.TabIndex = 1;
            // 
            // textBox_MaSV
            // 
            this.textBox_MaSV.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_MaSV.Location = new System.Drawing.Point(109, 11);
            this.textBox_MaSV.Name = "textBox_MaSV";
            this.textBox_MaSV.Size = new System.Drawing.Size(193, 27);
            this.textBox_MaSV.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 0;
            this.label5.Text = "Mã khoa";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 0;
            this.label4.Text = "Ngày sinh";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "Phái";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Họ tên";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "MSV";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button_sua);
            this.panel2.Controls.Add(this.button_xoa);
            this.panel2.Controls.Add(this.button_thoat);
            this.panel2.Controls.Add(this.button_them);
            this.panel2.Location = new System.Drawing.Point(12, 224);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(305, 198);
            this.panel2.TabIndex = 1;
            // 
            // button_sua
            // 
            this.button_sua.BackColor = System.Drawing.Color.LightSalmon;
            this.button_sua.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_sua.Location = new System.Drawing.Point(101, 15);
            this.button_sua.Name = "button_sua";
            this.button_sua.Size = new System.Drawing.Size(88, 52);
            this.button_sua.TabIndex = 3;
            this.button_sua.Text = "Sửa";
            this.button_sua.UseVisualStyleBackColor = false;
            this.button_sua.Click += new System.EventHandler(this.button_sua_Click);
            // 
            // button_xoa
            // 
            this.button_xoa.BackColor = System.Drawing.Color.LightSalmon;
            this.button_xoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_xoa.Location = new System.Drawing.Point(195, 15);
            this.button_xoa.Name = "button_xoa";
            this.button_xoa.Size = new System.Drawing.Size(88, 52);
            this.button_xoa.TabIndex = 2;
            this.button_xoa.Text = "Xóa";
            this.button_xoa.UseVisualStyleBackColor = false;
            this.button_xoa.Click += new System.EventHandler(this.button_xoa_Click);
            // 
            // button_thoat
            // 
            this.button_thoat.BackColor = System.Drawing.Color.Red;
            this.button_thoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_thoat.Location = new System.Drawing.Point(214, 143);
            this.button_thoat.Name = "button_thoat";
            this.button_thoat.Size = new System.Drawing.Size(88, 52);
            this.button_thoat.TabIndex = 1;
            this.button_thoat.Text = "Thoát";
            this.button_thoat.UseVisualStyleBackColor = false;
            this.button_thoat.Click += new System.EventHandler(this.button_thoat_Click);
            // 
            // button_them
            // 
            this.button_them.BackColor = System.Drawing.Color.LightSalmon;
            this.button_them.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_them.Location = new System.Drawing.Point(7, 15);
            this.button_them.Name = "button_them";
            this.button_them.Size = new System.Drawing.Size(88, 52);
            this.button_them.TabIndex = 4;
            this.button_them.Text = "Thêm";
            this.button_them.UseVisualStyleBackColor = false;
            this.button_them.Click += new System.EventHandler(this.button_them_Click);
            // 
            // FormSinhVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(933, 450);
            this.Controls.Add(this.panel_inp);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormSinhVien";
            this.Text = "FormSinhVien";
            this.Load += new System.EventHandler(this.FormSinhVien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel_inp.ResumeLayout(false);
            this.panel_inp.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel_inp;
        private System.Windows.Forms.ComboBox comboBox_Phai;
        private System.Windows.Forms.TextBox textBox_HoVaTen;
        private System.Windows.Forms.TextBox textBox_MaSV;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker dateTimePicker_NgaySinh;
        private System.Windows.Forms.ComboBox comboBox_MaK;
        private System.Windows.Forms.Button button_sua;
        private System.Windows.Forms.Button button_xoa;
        private System.Windows.Forms.Button button_thoat;
        private System.Windows.Forms.Button button_them;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaSV;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoVaTen;
        private System.Windows.Forms.DataGridViewComboBoxColumn Phai;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgaySinh;
        private System.Windows.Forms.DataGridViewComboBoxColumn MaK;
    }
}