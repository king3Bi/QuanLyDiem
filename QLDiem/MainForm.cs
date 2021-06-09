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
            // Ẩn của sổ hiện tại
            this.Hide();

            // Tạo mới một formKhoa
            FormKhoa formKhoa = new FormKhoa();

            // Hiển thị formKhoa ra màn hình
            formKhoa.ShowDialog();

            // Sau khi thoát khỏi formKhoa, hiện lại MainForm
            this.Show();
        }

        // Mở form sinh viên
        private void button_formSinhVien_Click(object sender, EventArgs e)
        {
            // Ẩn của sổ hiện tại
            this.Hide();

            // Tạo mới một formSinhVien
            FormSinhVien formSinhVien = new FormSinhVien();

            // Hiển thị formSinhVien ra màn hình
            formSinhVien.ShowDialog();

            // Sau khi thoát khỏi formKhoa, hiện lại MainForm
            this.Show();
        }

        // Mở form môn học
        private void button_MonHoc_Click(object sender, EventArgs e)
        {
            // Ẩn của sổ hiện tại
            this.Hide();

            // Tạo mới một formMonHoc
            FormMonHoc formMonHoc = new FormMonHoc();

            // Hiển thị formMonHoc ra màn hình
            formMonHoc.ShowDialog();

            // Sau khi thoát khỏi formKhoa, hiện lại MainForm
            this.Show();
        }

        // Mở form kết quả
        private void button_formKetQua_Click(object sender, EventArgs e)
        {
            // Ẩn của sổ hiện tại
            this.Hide();

            // Tạo mới một formKetQua
            FormKetQua formKetQua = new FormKetQua();

            // Hiển thị formKetQua ra màn hình
            formKetQua.ShowDialog();

            // Sau khi thoát khỏi formKhoa, hiện lại MainForm
            this.Show();
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
        
        // Khi con trỏ chuột ở trên button
        private void button_thoat_MouseEnter(object sender, EventArgs e)
        {
            button_thoat.ForeColor = Color.Red;
        }

        // Khi con trỏ chuột rời khỏi button
        private void button_thoat_MouseLeave(object sender, EventArgs e)
        {
            button_thoat.ForeColor = Color.White;
        }

        // Đóng ứng dụng
        private void button_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
