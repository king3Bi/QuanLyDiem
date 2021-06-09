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
    public partial class FormKetQua : Form
    {
        KetQua modelKetQua = new KetQua();
        int status = 0;
        public FormKetQua()
        {
            InitializeComponent();
        }

        private void FormKetQua_Load(object sender, EventArgs e)
        {
            loadDataToCmb();
            loadDataToDgv();
            block_status();
            clear();
        }

        private void loadDataToDgv()
        {
            dataGridView2.AutoGenerateColumns = false;
            using (ModelQLD modelQLD = new ModelQLD())
            {
                dataGridView2.DataSource = modelQLD.KetQuas.ToList();

                (dataGridView2.Columns["MaSV"] as DataGridViewComboBoxColumn).DisplayMember = "HoVaTen";
                (dataGridView2.Columns["MaSV"] as DataGridViewComboBoxColumn).ValueMember = "MaSV";
                (dataGridView2.Columns["MaSV"] as DataGridViewComboBoxColumn).DataSource = modelQLD.SinhViens.ToList();

                (dataGridView2.Columns["MaMH"] as DataGridViewComboBoxColumn).DisplayMember = "TenMH";
                (dataGridView2.Columns["MaMH"] as DataGridViewComboBoxColumn).ValueMember = "MaMH";
                (dataGridView2.Columns["MaMH"] as DataGridViewComboBoxColumn).DataSource = modelQLD.MonHocs.ToList();
            }
        }

        private void loadDataToCmb()
        {
            using (ModelQLD modelQLD = new ModelQLD())
            {
                comboBox_MaSV.DisplayMember = "HoVaTen";
                comboBox_MaSV.ValueMember = "MaSV";
                comboBox_MaSV.DataSource = modelQLD.SinhViens.ToList();
                comboBox_MaSV.SelectedIndex = -1;

                comboBox_MaMH.DisplayMember = "TenMH";
                comboBox_MaMH.ValueMember = "MaMH";
                comboBox_MaMH.DataSource = modelQLD.MonHocs.ToList();
                comboBox_MaMH.SelectedIndex = -1;
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
            textBox_Diem.Text = "";
            comboBox_MaSV.SelectedIndex = comboBox_MaMH.SelectedIndex = -1;
            modelKetQua = null;
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.CurrentRow.Index != -1)
            {
                int ID_SV = Convert.ToInt32(dataGridView2.CurrentRow.Cells["MaSV"].Value);
                int ID_MH = Convert.ToInt32(dataGridView2.CurrentRow.Cells["MaMH"].Value);
                using (ModelQLD modelQLD = new ModelQLD())
                {
                    modelKetQua = modelQLD.KetQuas.Where(x => (x.MaSV == ID_SV && x.MaMH == ID_MH)).FirstOrDefault();
                    dataBindingPanel_inp();
                }
            }
        }

        private void dataBindingPanel_inp()
        {
            comboBox_MaSV.SelectedValue = modelKetQua.MaSV;
            comboBox_MaMH.SelectedValue = modelKetQua.MaMH;
            textBox_Diem.Text = modelKetQua.Diem.ToString();
        }

        private bool check_panel_inp()
        {
            if (comboBox_MaSV.SelectedIndex!=-1 &&
                comboBox_MaMH.SelectedIndex!=-1 &&
                textBox_Diem.Text!="")
            {
                return true;
            }
            MessageBox.Show("Nhập thiếu dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        private bool check_exist_ob()
        {
            if (modelKetQua != null)
            {
                return true;
            }
            MessageBox.Show("Chưa có đối tượng dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        private void button_them_Click(object sender, EventArgs e)
        {
            if (status == 0)
            {
                status = 1;
                label_status.Text = "Thêm";
                clear();
                button_them.Text = "Lưu";
                button_sua.Text = "Hủy";
                un_block_status();
                button_xoa.Visible = false;
            }
            else if (status == 1 && check_panel_inp())
            {
                using (ModelQLD modelQLD = new ModelQLD())
                {
                    modelKetQua.MaSV = Convert.ToInt32(comboBox_MaSV.SelectedValue);
                    modelKetQua.MaMH = Convert.ToInt32(comboBox_MaMH.SelectedValue);
                    modelKetQua.Diem = Convert.ToDouble(textBox_Diem.Text.Trim().ToString());
                    modelQLD.KetQuas.Add(modelKetQua);
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
            else if (status == 2 && check_exist_ob() && check_panel_inp())
            {
                using (ModelQLD modelQLD = new ModelQLD())
                {
                    modelKetQua.Diem = Convert.ToDouble(textBox_Diem.Text.Trim().ToString());
                    modelQLD.Entry(modelKetQua).State = System.Data.Entity.EntityState.Modified;
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
                label_status.Text = "";
                comboBox_MaSV.Enabled = true;
                comboBox_MaMH.Enabled = true;
                button_them.Text = "Thêm";
                button_sua.Text = "Sửa";
                button_xoa.Visible = true;
                clear();
                block_status();
            }
            else if (status == 0)
            {
                status = 2;
                label_status.Text = "Sửa";
                comboBox_MaSV.Enabled = false;
                comboBox_MaMH.Enabled = false;
                button_them.Text = "Lưu";
                button_sua.Text = "Hủy";
                button_xoa.Visible = false;

                un_block_status();
            }
        }

        private void button_xoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                using (ModelQLD modelQLD = new ModelQLD())
                {
                    if(check_exist_ob())
                    {
                        var entry = modelQLD.Entry(modelKetQua);
                        if (entry.State == System.Data.Entity.EntityState.Detached)
                            modelQLD.KetQuas.Attach(modelKetQua);
                        modelQLD.KetQuas.Remove(modelKetQua);
                        int eror = modelQLD.SaveChanges();
                        if (eror == 1)
                        {
                            loadDataToDgv();
                            clear();
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
        }

        private void button_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_thoat_MouseEnter(object sender, EventArgs e)
        {
            button_thoat.ForeColor = Color.Red;
        }

        private void button_thoat_MouseLeave(object sender, EventArgs e)
        {
            button_thoat.ForeColor = Color.White;
        }
    }
}
