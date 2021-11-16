using QLXe;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLXe
{
    public partial class UpdateTho : Form
    {
        public UpdateTho()
        {
            InitializeComponent();
        }
        ThoClass tho = new ThoClass();
        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                int thoId = Convert.ToInt32(textBoxID.Text);

                if (MessageBox.Show("Are you sure you want to delete this Tho", "Delete Tho", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (tho.deleteTho(thoId))
                    {
                        MessageBox.Show("Tho Deleted", "Delete Tho", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        textBoxID.Text = "";
                        txtAddress.Text = "";
                        txtName.Text = "";
                        txtPhone.Text = "";
                        


                    }
                    else
                    {
                        MessageBox.Show("Tho not deleted", "Delete Tho", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
            catch
            {
                MessageBox.Show("Please enter a valid ID", "Delete Tho", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void UpdateTho_Load(object sender, EventArgs e)
        {

        }
        bool verif()
        {
            if (textBoxID.Text == ""
                || pictureBox1.Image == null

                )
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id;
            string ten = txtName.Text;
            string sdt = txtPhone.Text;
            string diaChi = txtAddress.Text;
            string nhomTho = "";
            if(radioButtonRuaXe.Checked)
            {
                nhomTho = "Rửa Xe";
            } else if(radioButtonSuaXe.Checked)
            {
                nhomTho = "Sửa Xe";
            } else
            {
                nhomTho = "Trông coi xe";
            }

            MemoryStream hinhTho = new MemoryStream();
            DateTime ngaySinh = dateTimePicker.Value;
            if (verif() == true)
            {
                id = int.Parse(textBoxID.Text);
                pictureBox1.Image.Save(hinhTho, pictureBox1.Image.RawFormat);
                if (tho.updateTho(id, ten, sdt, diaChi, ngaySinh, nhomTho, hinhTho))
                {
                    MessageBox.Show("Thợ Đã Được Cập Nhật", "Thêm Thợ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Lỗi", "Cập Nhật Thợ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Vui Lòng Điền Đầy Đủ Thông Tin", "Cập Nhật Thợ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select image(*.jpg; *.png; *.gif)| *.jpg; *.png; *.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(opf.FileName);
            }
        }
    }
}
