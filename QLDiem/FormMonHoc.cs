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
        MonHoc modelMonHoc = new MonHoc();
        int status = 0;
        public FormMonHoc()
        {
            InitializeComponent();
        }

        private void FormMonHoc_Load(object sender, EventArgs e)
        {
            loadData();
            clear();
            textBox_MaMH.Enabled = false;
            block_status();
        }

        private void loadData()
        {
            dataGridView2.AutoGenerateColumns = false;
            using (ModelQLD modelQLD = new ModelQLD())
            {
                dataGridView2.DataSource = modelQLD.MonHocs.ToList();
            }
        }

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

        private bool check_panel_inp()
        {
            if (textBox_TenMH.Text != "" && textBox_SoTinChi.Text != "")
            {
                return true;
            }
            MessageBox.Show("Nhập thiếu dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        private bool check_exist_ob()
        {
            if (modelMonHoc != null)
            {
                return true;
            }
            MessageBox.Show("Chưa có đối tượng dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void clear()
        {
            textBox_MaMH.Text = textBox_TenMH.Text = textBox_SoTinChi.Text = "";
            modelMonHoc = null;
        }

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

        private void button_them_Click(object sender, EventArgs e)
        {
            if (status == 0)
            {
                status = 1;
                clear();
                label_status.Text = "Thêm";
                button_them.Text = "Lưu";
                button_sua.Text = "Hủy";
                un_block_status();
                button_xoa.Visible = false;
            }
            else if (status == 1 && check_panel_inp())
            {
                modelMonHoc = new MonHoc();
                using (ModelQLD modelQLD = new ModelQLD())
                {
                    modelMonHoc.TenMH = textBox_TenMH.Text.Trim().ToString();
                    modelMonHoc.SoTinChi = Convert.ToInt32(textBox_SoTinChi.Text.Trim().ToString());
                    modelMonHoc.MaMH = 0;
                    modelQLD.MonHocs.Add(modelMonHoc);
                    int eror = modelQLD.SaveChanges();
                    if (eror == 1)
                    {
                        loadData();
                        MessageBox.Show("Thêm thành công");
                    }
                    else
                    {
                        loadData();
                        MessageBox.Show("Thêm bị lỗi");
                    }
                }
            }
            else if (status == 2 && check_exist_ob() && check_panel_inp())
            {
                using (ModelQLD modelQLD = new ModelQLD())
                {
                    modelMonHoc.TenMH = textBox_TenMH.Text.Trim().ToString();
                    modelMonHoc.SoTinChi = Convert.ToInt32(textBox_SoTinChi.Text.Trim().ToString());
                    modelQLD.Entry(modelMonHoc).State = System.Data.Entity.EntityState.Modified;
                    int eror = modelQLD.SaveChanges();
                    if (eror == 1)
                    {
                        loadData();
                        MessageBox.Show("Sửa thành công");
                    }
                    else
                    {
                        loadData();
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
                button_them.Text = "Thêm";
                button_sua.Text = "Sửa";
                clear();
                button_xoa.Visible = true;
                block_status();
            }
            else
            if (status == 0)
            {
                status = 2;
                label_status.Text = "Sửa";
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
                        var entry = modelQLD.Entry(modelMonHoc);
                        if (entry.State == System.Data.Entity.EntityState.Detached)
                            modelQLD.MonHocs.Attach(modelMonHoc);
                        modelQLD.MonHocs.Remove(modelMonHoc);
                        int eror = modelQLD.SaveChanges();
                        if (eror == 1)
                        {
                            loadData();
                            clear();
                            MessageBox.Show("Xóa thành công");
                        }
                        else
                        {
                            loadData();
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
