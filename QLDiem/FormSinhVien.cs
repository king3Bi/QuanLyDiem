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
        SinhVien modelSinhVien = new SinhVien();
        int status = 0;
        public FormSinhVien()
        {
            InitializeComponent();
        }

        private void FormSinhVien_Load(object sender, EventArgs e)
        {
            loadDataToDgv();
            loadDataToCmbMaK();
            clear();
            block_status();

            // Mặc định mã số sinh viên không thể sửa
            textBox_MaSV.Enabled = false;
        }

        private void loadData()
        {
            
            using (ModelQLD modelQLD = new ModelQLD())
            {
                comboBox_MaK.DisplayMember = "TenKhoa";
                comboBox_MaK.ValueMember = "MaK";
                comboBox_MaK.DataSource = modelQLD.Khoas.ToList();
                comboBox_MaK.SelectedIndex = -1;    // lỗi

                dataGridView1.DataSource = modelQLD.SinhViens.ToList();
                (dataGridView1.Columns["MaK"] as DataGridViewComboBoxColumn).DisplayMember = "TenKhoa";
                (dataGridView1.Columns["MaK"] as DataGridViewComboBoxColumn).ValueMember = "MaK";
                (dataGridView1.Columns["MaK"] as DataGridViewComboBoxColumn).DataSource = modelQLD.Khoas.ToList();
            }
        }

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

        private void loadDataToCmbMaK()
        {
            using (ModelQLD modelQLD = new ModelQLD())
            {
                comboBox_MaK.DisplayMember = "TenKhoa";
                comboBox_MaK.ValueMember = "MaK";
                comboBox_MaK.DataSource = modelQLD.Khoas.ToList();
                comboBox_MaK.SelectedIndex = -1;    // lỗi
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

        // Xóa các dữ liệu trên panel_inp
        private void clear()
        {
            textBox_MaSV.Text = textBox_HoVaTen.Text = "";
            comboBox_MaK.SelectedIndex = comboBox_Phai.SelectedIndex = -1;
            dateTimePicker_NgaySinh.CustomFormat = " ";
        }

        private void button_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dateTimePicker_NgaySinh.CustomFormat = "dd-MM-yyyy";
            if (dataGridView1.CurrentRow.Index != -1)
            {
                int ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["MaSV"].Value);
                using (ModelQLD modelQLD = new ModelQLD())
                {
                    modelSinhVien = modelQLD.SinhViens.Where(x => x.MaSV == ID).FirstOrDefault();
                    textBox_MaSV.Text = modelSinhVien.MaSV.ToString();
                    textBox_HoVaTen.Text = modelSinhVien.HoVaTen.ToString();
                    comboBox_Phai.SelectedItem = modelSinhVien.Phai.ToString();
                    dateTimePicker_NgaySinh.Value = modelSinhVien.NgaySinh;
                    comboBox_MaK.SelectedValue = modelSinhVien.MaK;
                }
            }
        }

        private void button_them_Click(object sender, EventArgs e)
        {
            un_block_status();

            if (status == 0)
            {
                status = 1;
                textBox_MaSV.Text = textBox_HoVaTen.Text = "";
                comboBox_Phai.SelectedIndex = comboBox_MaK.SelectedIndex = -1;
                dateTimePicker_NgaySinh.CustomFormat = " ";
                button_them.Text = "Lưu";
                button_sua.Text = "Hủy";
                button_xoa.Visible = false;
            }
            else if (status == 1)
            {
                using (ModelQLD modelQLD = new ModelQLD())
                {
                    modelSinhVien.MaSV = 0;
                    modelSinhVien.HoVaTen = textBox_HoVaTen.Text.Trim().ToString();
                    modelSinhVien.Phai = comboBox_Phai.SelectedItem.ToString();
                    modelSinhVien.NgaySinh = dateTimePicker_NgaySinh.Value.Date;
                    modelSinhVien.MaK = Convert.ToInt32(comboBox_MaK.SelectedValue);
                    modelQLD.SinhViens.Add(modelSinhVien);

                    int eror = modelQLD.SaveChanges();
                    if (eror == 1)
                    {
                        loadDataToDgv();
                        MessageBox.Show("Thêm thành công");
                    }
                    else
                    {
                        loadDataToDgv();
                        MessageBox.Show("Thêm bị lỗi");
                    }
                }
            }
            else if (status == 2)
            {
                using (ModelQLD modelQLD = new ModelQLD())
                {
                    modelSinhVien.HoVaTen = textBox_HoVaTen.Text.Trim().ToString();
                    modelSinhVien.Phai = comboBox_Phai.SelectedItem.ToString();
                    modelSinhVien.NgaySinh = dateTimePicker_NgaySinh.Value;
                    modelSinhVien.MaK = Convert.ToInt32(comboBox_MaK.SelectedValue);

                    modelQLD.Entry(modelSinhVien).State = System.Data.Entity.EntityState.Modified;
                    int eror = modelQLD.SaveChanges();
                    if (eror == 1)
                    {
                        loadDataToDgv();
                        MessageBox.Show("Sửa thành công");
                    }
                    else
                    {
                        loadDataToDgv();
                        MessageBox.Show("Sửa bị lỗi");
                    }
                }
            }
        }

        private void button_sua_Click(object sender, EventArgs e)
        {
            if (status == 1 || status == 2)
            {
                status = 0;
                button_them.Text = "Thêm";
                button_sua.Text = "Sửa";
                button_xoa.Visible = true;
                block_status();
            }
            else
            if (status == 0)
            {
                status = 2;
                button_them.Text = "Lưu";
                button_sua.Text = "Hủy";
                button_xoa.Visible = false;

                un_block_status();
            }
        }

        private void dateTimePicker_NgaySinh_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker_NgaySinh.CustomFormat = "dd/MM/yyyy";
        }

        private void button_xoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa?", "Cảnh báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (ModelQLD modelQLD = new ModelQLD())
                {
                    var entry = modelQLD.Entry(modelSinhVien);
                    if (entry.State == System.Data.Entity.EntityState.Detached)
                        modelQLD.SinhViens.Attach(modelSinhVien);
                    modelQLD.SinhViens.Remove(modelSinhVien);
                    int eror = modelQLD.SaveChanges();
                    if (eror == 1)
                    {
                        loadDataToDgv();
                        MessageBox.Show("Xóa thành công");
                    }
                    else
                    {
                        loadDataToDgv();
                        MessageBox.Show("Xóa bị lỗi");
                    }
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.ForeColor = Color.Red;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.ForeColor = Color.White;
        }
    }
}
