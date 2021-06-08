using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLDiem.EF;

namespace QLDiem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        // Mở form khoa
        private void button_formKhoa_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormKhoa formKhoa = new FormKhoa();
            formKhoa.ShowDialog();
            this.Show();
        }

        // Mở form sinh viên
        private void button_formSinhVien_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormSinhVien formSinhVien = new FormSinhVien();
            formSinhVien.ShowDialog();
            this.Show();
        }

        // Mở form môn học
        private void button_MonHoc_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMonHoc formMonHoc = new FormMonHoc();
            formMonHoc.ShowDialog();
            this.Show();
        }

        // Mở form kết quả
        private void button_formKetQua_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormKetQua formKetQua = new FormKetQua();
            formKetQua.ShowDialog();
            this.Show();
        }

        // Thoát
        private void label1_Click(object sender, EventArgs e)
        {
            //label1.BackColor = Color.Red;
            //Thread.Sleep(1000);
            //this.Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Thiết lập kết nối với csdl để để tránh mất nhiều thời gian load dữ liệu khi mở các form lần đầu lên
            using (ModelQLD modelQLD=new ModelQLD())
            {
                modelQLD.Khoas.ToList();
                modelQLD.SinhViens.ToList();
                modelQLD.MonHocs.ToList();
                modelQLD.KetQuas.ToList();
            }
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.ForeColor = Color.Red;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.ForeColor = Color.White;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
