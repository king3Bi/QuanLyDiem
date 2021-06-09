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
        // Tạo một object để lưu dữ liệu tạm
        Khoa modelKhoa = new Khoa();

        // biến satatus lưu giữ trạng thái làm việc: thêm(1), sửa(2)
        int status = 0; // 0 là trạng thái ban đầu

        public FormKhoa()
        {
            InitializeComponent();
        }

        private void FormKhoa_Load(object sender, EventArgs e)
        {
            // Load dữ liệu vào dataGridView khi form load
            loadData();

            // Khóa panel_inp
            block_status();

            // Mặc định MaK không thể sửa
            textBox_MaK.Enabled = false;

            // Xóa các dữ liệu trên panel_inp và object lưu dữ liệu tạm
            clear();
        }

        // Load dữ liệu vào dataGridView
        private void loadData()
        {
            dataGridView1.AutoGenerateColumns = false;
            using (ModelQLD modelQLD=new ModelQLD())
            {
                dataGridView1.DataSource = modelQLD.Khoas.ToList();
            }
        }

        // Đưa dữ liệu từ object lưu dữ liệu vào trong panel_inp
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

        // Kiểm tra các inp có dữ liệu hết chưa
        private bool check_panel_inp()
        {
            if(textBox_TenKhoa.Text!="")
            {
                return true;
            }
            MessageBox.Show("Nhập thiếu dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        // Kiểm tra object được tạo chưa
        private bool check_exist_ob()
        {
            if(modelKhoa!=null)
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
            textBox_MaK.Text = textBox_TenKhoa.Text = "";
            modelKhoa = null;
        }

        // Sự kiện click vào một dòng trong dataGridView
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

        // Sự kiện click button thêm
        private void button_them_Click(object sender, EventArgs e)
        {
            // Nếu ở trang thái ban đầu
            if(status==0)
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
            else if(status==1 && check_panel_inp())
            {
                // Lúc này button thêm mang chức năng lưu ở trạng thái thêm
                // thực hiện insert dữ liệu lên database

                // tạo mới một object Khoa
                modelKhoa = new Khoa();


                using (ModelQLD modelQLD = new ModelQLD())
                {
                    // Gán dữ liệu cho object
                    modelKhoa.TenKhoa = textBox_TenKhoa.Text.Trim().ToString();
                    modelKhoa.MaK = 0;

                    // Thêm object vào tập thực thể
                    modelQLD.Khoas.Add(modelKhoa);

                    // Đưa dữ liệu xuống database
                    int eror = modelQLD.SaveChanges();

                    // Thêm thành công
                    if(eror==1)
                    {
                        // Load lại data
                        loadData();

                        // Thông báo ra màn hình
                        MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    // Thêm bị lỗi
                    else
                    {
                        // Load lại data
                        loadData();

                        // Thông báo ra màn hình
                        MessageBox.Show("Thêm bị lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            // Nếu ở trạng thái sửa
            else if(status==2 && check_exist_ob() && check_panel_inp())
            {
                // Lúc này button thêm mang chức năng lưu ở trạng thái sửa
                // Thực hiện update dữ liệu lên database
                using (ModelQLD modelQLD=new ModelQLD())
                {
                    // Gán dữ liệu cho object
                    modelKhoa.TenKhoa = textBox_TenKhoa.Text.Trim().ToString();

                    // Cập nhật lại dữ liệu trong tập thưc thể
                    modelQLD.Entry(modelKhoa).State = System.Data.Entity.EntityState.Modified;

                    // Đưa dữ liệu xuống database
                    int eror = modelQLD.SaveChanges();

                    // Sửa thành công
                    if(eror==1)
                    {
                        // Load lại data
                        loadData();

                        // Thông báo ra màn hình
                        MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    // Sửa bị lỗi
                    else
                    {
                        loadData();
                        MessageBox.Show("Sửa bị lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // Sự kiện click button sửa
        private void button_sua_Click(object sender, EventArgs e)
        {
            // Nếu là trạng thái thêm hoặc sửa
            if(status==1 || status==2)
            {
                // Lúc này, nút thêm mang chức năng hủy
                // Đưa trạng thái về trạng thái ban đầu
                status = 0;
                button_them.Text = "Thêm";
                button_sua.Text = "Sửa";
                button_xoa.Visible = true;
                label_status.Text = "";
                clear();
                block_status();
            }
            else

            // Nếu là trạng thái ban đầu
            if(status==0)
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
            if(MessageBox.Show("Bạn có chắc chắn xóa?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)==DialogResult.Yes)
            {
                using (ModelQLD modelQLD=new ModelQLD())
                {
                    // Kiểm tra xem object có tồn tại không
                    if(check_exist_ob())
                    {
                        // xóa objcet trong tập thực thể
                        var entry = modelQLD.Entry(modelKhoa);
                        if (entry.State == System.Data.Entity.EntityState.Detached)
                            modelQLD.Khoas.Attach(modelKhoa);
                        modelQLD.Khoas.Remove(modelKhoa);

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

        // Đóng cửa formKhoa
        private void button_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
