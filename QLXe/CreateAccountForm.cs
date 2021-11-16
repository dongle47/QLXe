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
    public partial class CreateAccountForm : Form
    {
        public CreateAccountForm()
        {
            InitializeComponent();
        }
        NQL nql = new NQL();
        NV nv = new NV();
        private void buttonUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select image(*.jpg; *.png; *.gif)| *.jpg; *.png; *.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(opf.FileName);
            }
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBoxId.Text);
            string ten = textBoxName.Text;
            string sdt = textBoxPhone.Text;
            string diaChi = textBoxAddress.Text;
            string uname = textBoxUname.Text;
            string pass = textBoxPass.Text;
            DateTime ngaySinh = dateTimePickerNgaySinh.Value;
            MemoryStream picture = new MemoryStream();
            if (radioButtonQL.Checked == true)
            {
                if (verif() == true)
                {
                    pictureBox1.Image.Save(picture, pictureBox1.Image.RawFormat);
                    pictureBox1.Image.Save(picture, pictureBox1.Image.RawFormat);
                    if (nql.insertNQL(id, ten, sdt, diaChi, ngaySinh, picture, uname, pass))
                    {
                        MessageBox.Show("Đã Thêm NQL", "Thêm NQL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Lỗi", "Thêm NQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Vui Lòng Điền Đầy Đủ Thông Tin", "Thêm NQL", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else if (radioButtonNV.Checked == true)
            {
                if (verif() == true)
                {
                    pictureBox1.Image.Save(picture, pictureBox1.Image.RawFormat);
                    pictureBox1.Image.Save(picture, pictureBox1.Image.RawFormat);
                    if (nv.insertNV(id, ten, sdt, diaChi, ngaySinh, picture, uname, pass))
                    {
                        MessageBox.Show("Đã Thêm NV", "Thêm NV", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Lỗi", "Thêm NV", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Vui Lòng Điền Đầy Đủ Thông Tin", "Thêm NV", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
        bool verif()
        {
            if (   textBoxId.Text.Trim() == ""
                || textBoxName.Text.Trim()==""
                || textBoxPhone.Text.Trim()==""
                || textBoxAddress.Text.Trim()==""
                || textBoxUname.Text.Trim()==""
                || textBoxPass.Text.Trim()==""
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

        private void CreateAccountForm_Load(object sender, EventArgs e)
        {
            radioButtonNV.Checked = true;
        }
    }
}
