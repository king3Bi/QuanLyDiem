
namespace QLDiem
{
    partial class FormKhoa
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
            this.panel_inp = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_MaK = new System.Windows.Forms.TextBox();
            this.textBox_TenKhoa = new System.Windows.Forms.TextBox();
            this.button_them = new System.Windows.Forms.Button();
            this.button_sua = new System.Windows.Forms.Button();
            this.button_xoa = new System.Windows.Forms.Button();
            this.button_thoat = new System.Windows.Forms.Button();
            this.MaK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenKhoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.MaK,
            this.TenKhoa});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(467, 201);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // panel_inp
            // 
            this.panel_inp.Controls.Add(this.textBox_TenKhoa);
            this.panel_inp.Controls.Add(this.textBox_MaK);
            this.panel_inp.Controls.Add(this.label2);
            this.panel_inp.Controls.Add(this.label1);
            this.panel_inp.Location = new System.Drawing.Point(12, 220);
            this.panel_inp.Name = "panel_inp";
            this.panel_inp.Size = new System.Drawing.Size(467, 63);
            this.panel_inp.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button_thoat);
            this.panel2.Controls.Add(this.button_xoa);
            this.panel2.Controls.Add(this.button_sua);
            this.panel2.Controls.Add(this.button_them);
            this.panel2.Location = new System.Drawing.Point(12, 289);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(467, 73);
            this.panel2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã khoa";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(210, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên khoa";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_MaK
            // 
            this.textBox_MaK.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_MaK.Location = new System.Drawing.Point(81, 20);
            this.textBox_MaK.Name = "textBox_MaK";
            this.textBox_MaK.Size = new System.Drawing.Size(100, 27);
            this.textBox_MaK.TabIndex = 1;
            // 
            // textBox_TenKhoa
            // 
            this.textBox_TenKhoa.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_TenKhoa.Location = new System.Drawing.Point(298, 17);
            this.textBox_TenKhoa.Name = "textBox_TenKhoa";
            this.textBox_TenKhoa.Size = new System.Drawing.Size(166, 27);
            this.textBox_TenKhoa.TabIndex = 1;
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
            // button_sua
            // 
            this.button_sua.BackColor = System.Drawing.Color.LightSalmon;
            this.button_sua.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_sua.Location = new System.Drawing.Point(105, 11);
            this.button_sua.Name = "button_sua";
            this.button_sua.Size = new System.Drawing.Size(88, 52);
            this.button_sua.TabIndex = 0;
            this.button_sua.Text = "Sửa";
            this.button_sua.UseVisualStyleBackColor = false;
            this.button_sua.Click += new System.EventHandler(this.button_sua_Click);
            // 
            // button_xoa
            // 
            this.button_xoa.BackColor = System.Drawing.Color.LightSalmon;
            this.button_xoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_xoa.Location = new System.Drawing.Point(204, 11);
            this.button_xoa.Name = "button_xoa";
            this.button_xoa.Size = new System.Drawing.Size(88, 52);
            this.button_xoa.TabIndex = 0;
            this.button_xoa.Text = "Xóa";
            this.button_xoa.UseVisualStyleBackColor = false;
            this.button_xoa.Click += new System.EventHandler(this.button_xoa_Click);
            // 
            // button_thoat
            // 
            this.button_thoat.BackColor = System.Drawing.Color.Red;
            this.button_thoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_thoat.Location = new System.Drawing.Point(376, 11);
            this.button_thoat.Name = "button_thoat";
            this.button_thoat.Size = new System.Drawing.Size(88, 52);
            this.button_thoat.TabIndex = 0;
            this.button_thoat.Text = "Thoát";
            this.button_thoat.UseVisualStyleBackColor = false;
            this.button_thoat.Click += new System.EventHandler(this.button3_Click);
            // 
            // MaK
            // 
            this.MaK.DataPropertyName = "MaK";
            this.MaK.HeaderText = "Mã khoa";
            this.MaK.Name = "MaK";
            this.MaK.ReadOnly = true;
            // 
            // TenKhoa
            // 
            this.TenKhoa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TenKhoa.DataPropertyName = "TenKhoa";
            this.TenKhoa.HeaderText = "Tên khoa";
            this.TenKhoa.Name = "TenKhoa";
            // 
            // FormKhoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(491, 374);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel_inp);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormKhoa";
            this.Text = "FormKhoa";
            this.Load += new System.EventHandler(this.FormKhoa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel_inp.ResumeLayout(false);
            this.panel_inp.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaK;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenKhoa;
        private System.Windows.Forms.Panel panel_inp;
        private System.Windows.Forms.TextBox textBox_TenKhoa;
        private System.Windows.Forms.TextBox textBox_MaK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button_thoat;
        private System.Windows.Forms.Button button_xoa;
        private System.Windows.Forms.Button button_sua;
        private System.Windows.Forms.Button button_them;
    }
}