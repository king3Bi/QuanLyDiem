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
    public partial class FormSinhVien : Form
    {
        // Tạo một object để lưu dữ liệu tạm
        SinhVien modelSinhVien = new SinhVien();

        // biến satatus lưu giữ trạng thái làm việc: thêm(1), sửa(2)
        int status = 0;     // 0 là trạng thái ban đầu
        public FormSinhVien()
        {
            InitializeComponent();
        }

        private void FormSinhVien_Load(object sender, EventArgs e)
        {
            // Load dữ liệu vào dataGridView khi form load
            loadDataToDgv();

            // Load dữ liệu vào combobox Khoa khi form load
            loadDataToCmbMaK();

            // Xóa các dữ liệu trên panel_inp và object lưu dữ liệu tạm
            clear();

            // Khóa panel_inp
            block_status();

            // Mặc định mã số sinh viên không thể sửa
            textBox_MaSV.Enabled = false;
        }

        // Load dữ liệu vào dataGridView
        private void loadDataToDgv()
        {
            dataGridView1.AutoGenerateColumns = false;
            using (ModelQLD modelQLD = new ModelQLD())
            {
                dataGridView1.DataSource = modelQLD.SinhViens.ToList();
                (dataGridView1.Columns["MaK"] as DataGridViewComboBoxColumn).DisplayMember = "TenKhoa";
                (dataGridView1.Columns["MaK"] as DataGridViewComboBoxColumn).ValueMember = "MaK";
                (dataGridView1.Columns["MaK"] as DataGridViewComboBoxColumn).DataSource = modelQLD.Khoas.ToList();
            }
        }

        // Load dữ liệu vào combobox Khoa
        private void loadDataToCmbMaK()
        {
            using (ModelQLD modelQLD = new ModelQLD())
            {
                comboBox_MaK.DisplayMember = "TenKhoa";
                comboBox_MaK.ValueMember = "MaK";
                comboBox_MaK.DataSource = modelQLD.Khoas.ToList();
                comboBox_MaK.SelectedIndex = -1;
            }
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
            textBox_MaSV.Text = textBox_HoVaTen.Text = "";
            comboBox_MaK.SelectedIndex = comboBox_Phai.SelectedIndex = -1;
            dateTimePicker_NgaySinh.CustomFormat = " ";
            modelSinhVien = null;
        }

        // Sự kiện click vào một dòng trong dataGridView
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                dateTimePicker_NgaySinh.CustomFormat = "dd-MM-yyyy";
                int ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["MaSV"].Value);
                using (ModelQLD modelQLD = new ModelQLD())
                {
                    modelSinhVien = modelQLD.SinhViens.Where(x => x.MaSV == ID).FirstOrDefault();
                    dataBindingPanel_inp();
                }
            }
        }

        // Đưa dữ liệu từ object lưu dữ liệu vào trong panel_inp
        private void dataBindingPanel_inp()
        {
            if (status == 1)
            {
                textBox_MaSV.Text = "";
            }
            else
            {
                textBox_MaSV.Text = modelSinhVien.MaSV.ToString();
            }
            textBox_HoVaTen.Text = modelSinhVien.HoVaTen.ToString();
            comboBox_Phai.SelectedItem = modelSinhVien.Phai.ToString();
            dateTimePicker_NgaySinh.Value = modelSinhVien.NgaySinh;
            comboBox_MaK.SelectedValue = modelSinhVien.MaK;
        }

        // Kiểm tra các dữ liệu trong panel_inp có được nhập đầy đủ
        private bool check_panel_inp()
        {
            if (textBox_HoVaTen.Text != "" &&
                comboBox_Phai.SelectedIndex!=-1 &&
                comboBox_MaK.SelectedIndex!=-1 &&
                dateTimePicker_NgaySinh.CustomFormat!=" ")
            {
                return true;
            }
            MessageBox.Show("Nhập thiếu dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        // Kiểm tra có tồn tại object không
        private bool check_exist_ob()
        {
            if (modelSinhVien != null)
            {
                return true;
            }
            MessageBox.Show("Chưa chọn đối tượng dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
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
                modelSinhVien = new SinhVien();
                using (ModelQLD modelQLD = new ModelQLD())
                {
                    // Gán dữ liệu cho object
                    modelSinhVien.MaSV = 0;
                    modelSinhVien.HoVaTen = textBox_HoVaTen.Text.Trim().ToString();
                    modelSinhVien.Phai = comboBox_Phai.SelectedItem.ToString();
                    modelSinhVien.NgaySinh = dateTimePicker_NgaySinh.Value.Date;
                    modelSinhVien.MaK = Convert.ToInt32(comboBox_MaK.SelectedValue);

                    // Thêm object vào tập thực thể
                    modelQLD.SinhViens.Add(modelSinhVien);

                    // Đưa dữ liệu xuống database
                    int eror = modelQLD.SaveChanges();

                    // Thêm thành công
                    if (eror == 1)
                    {
                        // Load lại data
                        loadDataToDgv();

                        // Thông báo ra màn hình
                        MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    // Thêm bị lỗi
                    else
                    {
                        // Load lại data
                        loadDataToDgv();

                        // Thông báo ra màn hình
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
                    modelSinhVien.HoVaTen = textBox_HoVaTen.Text.Trim().ToString();
                    modelSinhVien.Phai = comboBox_Phai.SelectedItem.ToString();
                    modelSinhVien.NgaySinh = dateTimePicker_NgaySinh.Value;

                    // Cập nhật lại dữ liệu trong tập thưc thể
                    modelSinhVien.MaK = Convert.ToInt32(comboBox_MaK.SelectedValue);

                    modelQLD.Entry(modelSinhVien).State = System.Data.Entity.EntityState.Modified;

                    // Đưa dữ liệu xuống database
                    int eror = modelQLD.SaveChanges();

                    // Sửa thành công
                    if (eror == 1)
                    {
                        // Load lại data
                        loadDataToDgv();

                        // Thông báo ra màn hình
                        MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    // Sửa bị lỗi
                    else
                    {
                        // Load lại data
                        loadDataToDgv();

                        // Thông báo ra màn hình
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
                button_them.Text = "Thêm";
                button_sua.Text = "Sửa";
                button_xoa.Visible = true;
                clear();
                block_status();
            }
            else

            // Nếu là trạng thái ban đầu
            if (status == 0)
            {
                // Lúc này button sửa mang chức năng sửa
                // Đưa về trạng thái sửa
                status = 2;
                button_them.Text = "Lưu";
                button_sua.Text = "Hủy";
                button_xoa.Visible = false;

                un_block_status();
            }
        }

        // Sự kiện khi value of dataTimePicker thay đổi
        private void dateTimePicker_NgaySinh_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker_NgaySinh.CustomFormat = "dd/MM/yyyy";
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
                        var entry = modelQLD.Entry(modelSinhVien);
                        if (entry.State == System.Data.Entity.EntityState.Detached)
                            modelQLD.SinhViens.Attach(modelSinhVien);
                        modelQLD.SinhViens.Remove(modelSinhVien);

                        // Đưa dữ liệu xuống database
                        int eror = modelQLD.SaveChanges();

                        // Xóa thành công
                        if (eror == 1)
                        {
                            // Load lại data
                            loadDataToDgv();

                            // clear panel_inp và đưa object về null
                            clear();

                            // Thông báo
                            MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        // Xóa không thành công
                        else
                        {
                            // Load lại data
                            loadDataToDgv();

                            // Thông báo
                            MessageBox.Show("Xóa bị lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

            }
        }

        // Đóng formSinhVien
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
