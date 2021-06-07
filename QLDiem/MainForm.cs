using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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

        private void button_formKhoa_Click(object sender, EventArgs e)
        {
            FormKhoa formKhoa = new FormKhoa();
            formKhoa.Show();
        }

        private void button_formSinhVien_Click(object sender, EventArgs e)
        {
            FormSinhVien formSinhVien = new FormSinhVien();
            formSinhVien.Show();
        }

        private void button_MonHoc_Click(object sender, EventArgs e)
        {
            FormMonHoc formMonHoc = new FormMonHoc();
            formMonHoc.Show();
        }

        private void button_formKetQua_Click(object sender, EventArgs e)
        {
            FormKetQua formKetQua = new FormKetQua();
            formKetQua.Show();
        }

        private void button_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            using (ModelQLD modelQLD=new ModelQLD())
            {
                modelQLD.Khoas.ToList();
                modelQLD.SinhViens.ToList();
                modelQLD.MonHocs.ToList();
                modelQLD.KetQuas.ToList();
            }
        }
    }
}
