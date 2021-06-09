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
using QLDiem.Entity;

namespace QLDiem
{
    public partial class FormMonHoc : Form
    {
        // Tạo một object để lưu dữ liệu tạm
        MonHoc modelMonHoc = new MonHoc();

        // biến satatus lưu giữ trạng thái làm việc: thêm(1), sửa(2)
        int status = 0;     // 0 là trạng thái ban đầu
        public FormMonHoc()
        {
            InitializeComponent();
        }

        private void FormMonHoc_Load(object sender, EventArgs e)
        {
            // Load dữ liệu vào dataGridView khi form load
            loadData();

            // Xóa các dữ liệu trên panel_inp và object lưu dữ liệu tạm
            clear();

            // Mặc định mã môn học không thể sửa
            textBox_MaMH.Enabled = false;

            // Khóa panel_inp
            block_status();
        }

        // Load dữ liệu vào dataGridView
        private void loadData()
        {
            dataGridView2.AutoGenerateColumns = false;
            using (ModelQLD modelQLD = new ModelQLD())
            {
                dataGridView2.DataSource = modelQLD.MonHocs.ToList();
            }
        }

        // Đưa dữ liệu từ object lưu dữ liệu vào trong panel_inp
        private void dataBindingPanel_inp()
        {
            if (status == 1)
            {
                textBox_MaMH.Text = "";
            }
            else
            {
                textBox_MaMH.Text = modelMonHoc.MaMH.ToString();
            }
            textBox_TenMH.Text = modelMonHoc.TenMH.ToString();
            textBox_SoTinChi.Text = modelMonHoc.SoTinChi.ToString();
        }

        // Kiểm tra các dữ liệu trong panel_inp có được nhập đầy đủ
        private bool check_panel_inp()
        {
            if (textBox_TenMH.Text != "" && textBox_SoTinChi.Text != "")
            {
                return true;
            }
            MessageBox.Show("Nhập thiếu dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        // Kiểm tra có tồn tại object không
        private bool check_exist_ob()
        {
            if (modelMonHoc != null)
            {
                return true;
            }
            MessageBox.Show("Chưa chọn đối tượng dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        // Khóa panel inp không cho nhập dữ liệu
        private void block_status()
        {
            panel_inp.Enabled = false;
        }

        // Mở khóa panel inp
        private void un_block_status()
        {
            panel_inp.Enabled = true;
        }

        // Xóa các dữ liệu trên panel_inp và object lưu dữ liệu tạm
        private void clear()
        {
            textBox_MaMH.Text = textBox_TenMH.Text = textBox_SoTinChi.Text = "";
            modelMonHoc = null;
        }

        // Sự kiện click vào một dòng trong dataGridView
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.CurrentRow.Index != -1)
            {
                int ID = Convert.ToInt32(dataGridView2.CurrentRow.Cells["MaMH"].Value);
                using (ModelQLD modelQLD = new ModelQLD())
                {
                    modelMonHoc = modelQLD.MonHocs.Where(x => x.MaMH == ID).FirstOrDefault();
                    dataBindingPanel_inp();
                }
            }
        }

        // Sự kiện click button thêm
        private void button_them_Click(object sender, EventArgs e)
        {
            // Nếu ở trang thái ban đầu
            if (status == 0)
            {
                // Lúc này button thêm mang chức năng thêm
                // cập nhật trạng thái về trạng thái thêm
                status = 1;
                clear();
                label_status.Text = "Thêm";
                button_them.Text = "Lưu";
                button_sua.Text = "Hủy";
                un_block_status();
                button_xoa.Visible = false;
            }

            // Nếu ở trạng thái thêm
            else if (status == 1 && check_panel_inp())
            {
                // Lúc này button thêm mang chức năng lưu ở trạng thái thêm
                // thực hiện insert dữ liệu lên database

                // tạo mới một object Khoa
                modelMonHoc = new MonHoc();
                using (ModelQLD modelQLD = new ModelQLD())
                {
                    // Gán dữ liệu cho object
                    modelMonHoc.TenMH = textBox_TenMH.Text.Trim().ToString();
                    modelMonHoc.SoTinChi = Convert.ToInt32(textBox_SoTinChi.Text.Trim().ToString());
                    modelMonHoc.MaMH = 0;

                    // Thêm object vào tập thực thể
                    modelQLD.MonHocs.Add(modelMonHoc);

                    // Đưa dữ liệu xuống database
                    int eror = modelQLD.SaveChanges();

                    // Thêm thành công
                    if (eror == 1)
                    {
                        // Load lại data
                        loadData();

                        // Thông báo
                        MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    // Thêm bị lỗi
                    else
                    {
                        // Load lại data
                        loadData();

                        // Thông báo
                        MessageBox.Show("Thêm bị lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            // Nếu ở trạng thái sửa
            else if (status == 2 && check_exist_ob() && check_panel_inp())
            {
                // Lúc này button thêm mang chức năng lưu ở trạng thái sửa
                // Thực hiện update dữ liệu lên database
                using (ModelQLD modelQLD = new ModelQLD())
                {
                    // Gán dữ liệu cho object
                    modelMonHoc.TenMH = textBox_TenMH.Text.Trim().ToString();
                    modelMonHoc.SoTinChi = Convert.ToInt32(textBox_SoTinChi.Text.Trim().ToString());

                    // Cập nhật lại dữ liệu trong tập thưc thể
                    modelQLD.Entry(modelMonHoc).State = System.Data.Entity.EntityState.Modified;

                    // Đưa dữ liệu xuống database
                    int eror = modelQLD.SaveChanges();

                    // Sửa thành công
                    if (eror == 1)
                    {
                        // Load lại data
                        loadData();

                        // Thông báo
                        MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    // Sửa bị lỗi
                    else
                    {
                        // Load lại data
                        loadData();

                        // Thông báo
                        MessageBox.Show("Sửa bị lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // Sự kiện click button sửa
        private void button_sua_Click(object sender, EventArgs e)
        {
            // Nếu là trạng thái thêm hoặc sửa
            if (status == 1 || status == 2)
            {
                // Lúc này, nút thêm mang chức năng hủy
                // Đưa trạng thái về trạng thái ban đầu
                status = 0;
                label_status.Text = "";
                button_them.Text = "Thêm";
                button_sua.Text = "Sửa";
                clear();
                button_xoa.Visible = true;
                block_status();
            }
            else

            // Nếu là trạng thái ban đầu
            if (status == 0)
            {
                // Lúc này button sửa mang chức năng sửa
                // Đưa về trạng thái sửa
                status = 2;
                label_status.Text = "Sửa";
                button_them.Text = "Lưu";
                button_sua.Text = "Hủy";
                button_xoa.Visible = false;

                un_block_status();
            }
        }

        // Sự kiện click button xóa
        private void button_xoa_Click(object sender, EventArgs e)
        {
            // Hỏi lại trước khi xóa
            if (MessageBox.Show("Bạn có chắc chắn xóa?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                using (ModelQLD modelQLD = new ModelQLD())
                {
                    // Kiểm tra xem object có tồn tại không
                    if (check_exist_ob())
                    {
                        // xóa objcet trong tập thực thể
                        var entry = modelQLD.Entry(modelMonHoc);
                        if (entry.State == System.Data.Entity.EntityState.Detached)
                            modelQLD.MonHocs.Attach(modelMonHoc);
                        modelQLD.MonHocs.Remove(modelMonHoc);

                        // Đưa dữ liệu xuống database
                        int eror = modelQLD.SaveChanges();

                        // Xóa thành công
                        if (eror == 1)
                        {
                            // Load lại data
                            loadData();

                            // clear panel_inp và đưa object về null
                            clear();

                            // Thông báo
                            MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        // Xóa không thành công
                        else
                        {
                            // Load lại data
                            loadData();

                            // Thông báo
                            MessageBox.Show("Xóa bị lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

            }
        }

        // Đóng formMonHoc
        private void button_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
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
    }
}
