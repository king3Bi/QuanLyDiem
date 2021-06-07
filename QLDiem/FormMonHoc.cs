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
            textBox_MaMH.Enabled = false;
            panel_inp.Enabled = false;
        }

        private void loadData()
        {
            dataGridView2.AutoGenerateColumns = false;
            using (ModelQLD modelQLD = new ModelQLD())
            {
                dataGridView2.DataSource = modelQLD.MonHocs.ToList();
            }
        }

        private void button_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.CurrentRow.Index != -1)
            {
                int ID = Convert.ToInt32(dataGridView2.CurrentRow.Cells["MaMH"].Value);
                using (ModelQLD modelQLD = new ModelQLD())
                {
                    modelMonHoc = modelQLD.MonHocs.Where(x => x.MaMH == ID).FirstOrDefault();
                    textBox_MaMH.Text = modelMonHoc.MaMH.ToString();
                    textBox_TenMH.Text = modelMonHoc.TenMH.ToString();
                    textBox_SoTinChi.Text = modelMonHoc.SoTinChi.ToString();
                }
            }
        }

        private void button_them_Click(object sender, EventArgs e)
        {
            if (panel_inp.Enabled == false)
            {
                panel_inp.Enabled = true;
            }

            if (status == 0)
            {
                status = 1;
                textBox_MaMH.Text = textBox_TenMH.Text = textBox_SoTinChi.Text = "";
                button_them.Text = "Lưu";
                button_sua.Text = "Hủy";
                button_xoa.Visible = false;
            }
            else if (status == 1)
            {
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
            else if (status == 2)
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
                button_them.Text = "Thêm";
                button_sua.Text = "Sửa";
                button_xoa.Visible = true;
                if (panel_inp.Enabled == true)
                {
                    panel_inp.Enabled = false;
                }
            }
            else
            if (status == 0)
            {
                status = 2;
                button_them.Text = "Lưu";
                button_sua.Text = "Hủy";
                button_xoa.Visible = false;

                if (panel_inp.Enabled == false)
                {
                    panel_inp.Enabled = true;
                }
            }
        }

        private void button_xoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa?", "Cảnh báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (ModelQLD modelQLD = new ModelQLD())
                {
                    var entry = modelQLD.Entry(modelMonHoc);
                    if (entry.State == System.Data.Entity.EntityState.Detached)
                        modelQLD.MonHocs.Attach(modelMonHoc);
                    modelQLD.MonHocs.Remove(modelMonHoc);
                    int eror = modelQLD.SaveChanges();
                    if (eror == 1)
                    {
                        loadData();
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
}
