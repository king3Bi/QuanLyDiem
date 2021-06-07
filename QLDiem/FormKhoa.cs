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
    public partial class FormKhoa : Form
    {
        Khoa modelKhoa = new Khoa();
        int status = 0;

        public FormKhoa()
        {
            InitializeComponent();
        }

        private void FormKhoa_Load(object sender, EventArgs e)
        {
            loadData();
            panel_inp.Enabled = false;
            textBox_MaK.Enabled = false;
        }

        private void loadData()
        {
            dataGridView1.AutoGenerateColumns = false;
            using (ModelQLD modelQLD=new ModelQLD())
            {
                dataGridView1.DataSource = modelQLD.Khoas.ToList();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.CurrentRow.Index!=-1)
            {
                int ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["MaK"].Value);
                using (ModelQLD modelQLD=new ModelQLD())
                {
                    modelKhoa = modelQLD.Khoas.Where(x => x.MaK == ID).FirstOrDefault();
                    if(status==1)
                    {
                        textBox_MaK.Text = "";
                    }
                    else
                    {
                        textBox_MaK.Text = modelKhoa.MaK.ToString();
                    }
                    textBox_TenKhoa.Text = modelKhoa.TenKhoa.ToString();
                }
            }
        }

        private void button_them_Click(object sender, EventArgs e)
        {
            if(panel_inp.Enabled==false)
            {
                panel_inp.Enabled = true;
            }

            if(status==0)
            {
                status = 1;
                textBox_MaK.Text = textBox_TenKhoa.Text = "";
                button_them.Text = "Lưu";
                button_sua.Text = "Hủy";
                button_xoa.Visible = false;
            }
            else if(status==1)
            {
                using (ModelQLD modelQLD = new ModelQLD())
                {
                    modelKhoa.TenKhoa = textBox_TenKhoa.Text.Trim().ToString();
                    modelKhoa.MaK = 0;
                    modelQLD.Khoas.Add(modelKhoa);
                    int eror = modelQLD.SaveChanges();
                    if(eror==1)
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
            else if(status==2)
            {
                using (ModelQLD modelQLD=new ModelQLD())
                {
                    modelKhoa.TenKhoa = textBox_TenKhoa.Text.Trim().ToString();
                    modelQLD.Entry(modelKhoa).State = System.Data.Entity.EntityState.Modified;
                    int eror = modelQLD.SaveChanges();
                    if(eror==1)
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
            if(status==1 || status==2)
            {
                status = 0;
                button_them.Text = "Thêm";
                button_sua.Text = "Sửa";
                button_xoa.Visible = true;
                if(panel_inp.Enabled==true)
                {
                    panel_inp.Enabled = false;
                }
            }
            else
            if(status==0)
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
            if(MessageBox.Show("Bạn có chắc chắn xóa?", "Cảnh báo", MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                using (ModelQLD modelQLD=new ModelQLD())
                {
                    var entry = modelQLD.Entry(modelKhoa);
                    if (entry.State == System.Data.Entity.EntityState.Detached)
                        modelQLD.Khoas.Attach(modelKhoa);
                    modelQLD.Khoas.Remove(modelKhoa);
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
