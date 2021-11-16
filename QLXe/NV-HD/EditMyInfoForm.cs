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
    public partial class EditMyInfoForm : Form
    {
        public EditMyInfoForm()
        {
            InitializeComponent();
        }
        int nvId = Globals.globalUserId;
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

        private void EditMyInfoForm_Load(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            table = nv.getNVById(nvId);
            textBoxTen.Text = table.Rows[0][1].ToString();
            textBoxPhone.Text = table.Rows[0][2].ToString();
            textBoxAddress.Text = table.Rows[0][3].ToString();
            dateTimePickerNgaySinh.Value = (DateTime)table.Rows[0][4];
            textBoxUname.Text = table.Rows[0][6].ToString();
            textBoxPass.Text = table.Rows[0][7].ToString();

            byte[] pic;
            pic = (byte[])table.Rows[0][5];
            MemoryStream picture = new MemoryStream(pic);
            pictureBox1.Image = Image.FromStream(picture);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            int id = 0;
            string ten = textBoxTen.Text;
            string sdt = textBoxPhone.Text;
            string diaChi = textBoxAddress.Text;
            DateTime ngaySinh = dateTimePickerNgaySinh.Value;
            string uname = textBoxUname.Text;
            string pass = textBoxPass.Text;
            MemoryStream pic = new MemoryStream();
            if (verif())
            {
                try
                {
                    pictureBox1.Image.Save(pic, pictureBox1.Image.RawFormat);
                    if (nv.updateNV(nvId, ten, sdt, diaChi, ngaySinh, pic, uname, pass))
                    {
                        MessageBox.Show("Information Updated", "Edit Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error", "Edit Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Edit Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            else
            {
                MessageBox.Show("Empty Fields", "Edit Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        bool verif()
        {
            if (textBoxTen.Text.Trim() == ""
                || textBoxPhone.Text.Trim() == ""
                || textBoxAddress.Text.Trim() == ""
                || textBoxUname.Text.Trim() == ""
                || textBoxPass.Text.Trim() == ""
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
    }
}
