
namespace QLDiem
{
    partial class FormKetQua
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
            this.button_thoat = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button_xoa = new System.Windows.Forms.Button();
            this.button_sua = new System.Windows.Forms.Button();
            this.button_them = new System.Windows.Forms.Button();
            this.panel_inp = new System.Windows.Forms.Panel();
            this.comboBox_MaMH = new System.Windows.Forms.ComboBox();
            this.comboBox_MaSV = new System.Windows.Forms.ComboBox();
            this.textBox_Diem = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.MaSV = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.MaMH = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Diem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            this.panel_inp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // button_thoat
            // 
            this.button_thoat.BackColor = System.Drawing.Color.Red;
            this.button_thoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_thoat.Location = new System.Drawing.Point(219, 366);
            this.button_thoat.Name = "button_thoat";
            this.button_thoat.Size = new System.Drawing.Size(88, 52);
            this.button_thoat.TabIndex = 6;
            this.button_thoat.Text = "Thoát";
            this.button_thoat.UseVisualStyleBackColor = false;
            this.button_thoat.Click += new System.EventHandler(this.button_thoat_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button_xoa);
            this.panel2.Controls.Add(this.button_sua);
            this.panel2.Controls.Add(this.button_them);
            this.panel2.Location = new System.Drawing.Point(12, 288);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(295, 72);
            this.panel2.TabIndex = 9;
            // 
            // button_xoa
            // 
            this.button_xoa.BackColor = System.Drawing.Color.LightSalmon;
            this.button_xoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_xoa.Location = new System.Drawing.Point(201, 11);
            this.button_xoa.Name = "button_xoa";
            this.button_xoa.Size = new System.Drawing.Size(88, 52);
            this.button_xoa.TabIndex = 0;
            this.button_xoa.Text = "Xóa";
            this.button_xoa.UseVisualStyleBackColor = false;
            this.button_xoa.Click += new System.EventHandler(this.button_xoa_Click);
            // 
            // button_sua
            // 
            this.button_sua.BackColor = System.Drawing.Color.LightSalmon;
            this.button_sua.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_sua.Location = new System.Drawing.Point(104, 11);
            this.button_sua.Name = "button_sua";
            this.button_sua.Size = new System.Drawing.Size(88, 52);
            this.button_sua.TabIndex = 0;
            this.button_sua.Text = "Sửa";
            this.button_sua.UseVisualStyleBackColor = false;
            this.button_sua.Click += new System.EventHandler(this.button_sua_Click);
            // 
            // button_them
            // 
            this.button_them.BackColor = System.Drawing.Color.LightSalmon;
            this.button_them.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_them.Location = new System.Drawing.Point(7, 11);
            this.button_them.Name = "button_them";
            this.button_them.Size = new System.Drawing.Size(88, 52);
            this.button_them.TabIndex = 0;
            this.button_them.Text = "Thêm";
            this.button_them.UseVisualStyleBackColor = false;
            this.button_them.Click += new System.EventHandler(this.button_them_Click);
            // 
            // panel_inp
            // 
            this.panel_inp.Controls.Add(this.comboBox_MaMH);
            this.panel_inp.Controls.Add(this.comboBox_MaSV);
            this.panel_inp.Controls.Add(this.textBox_Diem);
            this.panel_inp.Controls.Add(this.label3);
            this.panel_inp.Controls.Add(this.label2);
            this.panel_inp.Controls.Add(this.label1);
            this.panel_inp.Location = new System.Drawing.Point(12, 12);
            this.panel_inp.Name = "panel_inp";
            this.panel_inp.Size = new System.Drawing.Size(295, 270);
            this.panel_inp.TabIndex = 8;
            // 
            // comboBox_MaMH
            // 
            this.comboBox_MaMH.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_MaMH.FormattingEnabled = true;
            this.comboBox_MaMH.Location = new System.Drawing.Point(119, 67);
            this.comboBox_MaMH.Name = "comboBox_MaMH";
            this.comboBox_MaMH.Size = new System.Drawing.Size(170, 28);
            this.comboBox_MaMH.TabIndex = 2;
            // 
            // comboBox_MaSV
            // 
            this.comboBox_MaSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_MaSV.FormattingEnabled = true;
            this.comboBox_MaSV.Location = new System.Drawing.Point(119, 16);
            this.comboBox_MaSV.Name = "comboBox_MaSV";
            this.comboBox_MaSV.Size = new System.Drawing.Size(170, 28);
            this.comboBox_MaSV.TabIndex = 2;
            // 
            // textBox_Diem
            // 
            this.textBox_Diem.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Diem.Location = new System.Drawing.Point(119, 115);
            this.textBox_Diem.Name = "textBox_Diem";
            this.textBox_Diem.Size = new System.Drawing.Size(170, 27);
            this.textBox_Diem.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "Điểm";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã môn học";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã sinh viên";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGridView2
            // 
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaSV,
            this.MaMH,
            this.Diem});
            this.dataGridView2.Location = new System.Drawing.Point(313, 12);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(467, 406);
            this.dataGridView2.TabIndex = 7;
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            // 
            // MaSV
            // 
            this.MaSV.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MaSV.DataPropertyName = "MaSV";
            this.MaSV.HeaderText = "Mã sinh viên";
            this.MaSV.Name = "MaSV";
            this.MaSV.ReadOnly = true;
            this.MaSV.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MaSV.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // MaMH
            // 
            this.MaMH.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MaMH.DataPropertyName = "MaMH";
            this.MaMH.HeaderText = "Mã môn học";
            this.MaMH.Name = "MaMH";
            this.MaMH.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MaMH.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Diem
            // 
            this.Diem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Diem.DataPropertyName = "Diem";
            this.Diem.HeaderText = "Điểm";
            this.Diem.Name = "Diem";
            // 
            // FormKetQua
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(800, 426);
            this.Controls.Add(this.button_thoat);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel_inp);
            this.Controls.Add(this.dataGridView2);
            this.Name = "FormKetQua";
            this.Text = "FormKetQua";
            this.Load += new System.EventHandler(this.FormKetQua_Load);
            this.panel2.ResumeLayout(false);
            this.panel_inp.ResumeLayout(false);
            this.panel_inp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_thoat;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button_xoa;
        private System.Windows.Forms.Button button_sua;
        private System.Windows.Forms.Button button_them;
        private System.Windows.Forms.Panel panel_inp;
        private System.Windows.Forms.TextBox textBox_Diem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.ComboBox comboBox_MaMH;
        private System.Windows.Forms.ComboBox comboBox_MaSV;
        private System.Windows.Forms.DataGridViewComboBoxColumn MaSV;
        private System.Windows.Forms.DataGridViewComboBoxColumn MaMH;
        private System.Windows.Forms.DataGridViewTextBoxColumn Diem;
    }
}