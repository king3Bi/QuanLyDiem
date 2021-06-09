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
            block_status();
            textBox_MaK.Enabled = false;
            clear();
        }

        private void loadData()
        {
            dataGridView1.AutoGenerateColumns = false;
            using (ModelQLD modelQLD=new ModelQLD())
            {
                dataGridView1.DataSource = modelQLD.Khoas.ToList();
            }
        }

        private void dataBindingPanel_inp()
        {
            if (status == 1)
            {
                textBox_MaK.Text = "";
            }
            else
            {
                textBox_MaK.Text = modelKhoa.MaK.ToString();
            }
            textBox_TenKhoa.Text = modelKhoa.TenKhoa.ToString();
        }

        private bool check_panel_inp()
        {
            if(textBox_TenKhoa.Text!="")
            {
                return true;
            }
            MessageBox.Show("Nhập thiếu dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        private bool check_exist_ob()
        {
            if(modelKhoa!=null)
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
            textBox_MaK.Text = textBox_TenKhoa.Text = "";
            modelKhoa = null;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.CurrentRow.Index!=-1)
            {
                int ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["MaK"].Value);
                using (ModelQLD modelQLD=new ModelQLD())
                {
                    modelKhoa = modelQLD.Khoas.Where(x => x.MaK == ID).FirstOrDefault();
                    dataBindingPanel_inp();
                }
            }
        }

        private void button_them_Click(object sender, EventArgs e)
        {
            if(status==0)
            {
                status = 1;
                clear();
                label_status.Text = "Thêm";
                button_them.Text = "Lưu";
                button_sua.Text = "Hủy";
                un_block_status();
                button_xoa.Visible = false;
            }
            else if(status==1 && check_panel_inp())
            {
                modelKhoa = new Khoa();
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
            else if(status==2 && check_exist_ob() && check_panel_inp())
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
                label_status.Text = "";
                clear();
                block_status();
            }
            else
            if(status==0)
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
            if(MessageBox.Show("Bạn có chắc chắn xóa?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)==DialogResult.Yes)
            {
                using (ModelQLD modelQLD=new ModelQLD())
                {
                    if(check_exist_ob())
                    {
                        var entry = modelQLD.Entry(modelKhoa);
                        if (entry.State == System.Data.Entity.EntityState.Detached)
                            modelQLD.Khoas.Attach(modelKhoa);
                        modelQLD.Khoas.Remove(modelKhoa);
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

        private void button_thoat_MouseEnter(object sender, EventArgs e)
        {
            button_thoat.ForeColor = Color.Red;
        }

        private void button_thoat_MouseLeave(object sender, EventArgs e)
        {
            button_thoat.ForeColor = Color.White;
        }

        private void button_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
