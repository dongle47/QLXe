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
    public partial class ThemTho : Form
    {
        public ThemTho()
        {
            InitializeComponent();
        }
        bool verif()
        {
            if (txtID.Text.Trim() == "" || txtName.Text.Trim() == "" || txtAddress.Text.Trim() == "" || txtPhone.Text.Trim() == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            ThoClass tho = new ThoClass();

            int id = 0;
            string ten = txtName.Text;
            string phone = txtPhone.Text;
            string adrs = txtAddress.Text;
            DateTime bdate = dateTimePicker.Value;
            string nhomTho = "";

            if(radioButtonSuaXe.Checked)
            {
                nhomTho = "Sửa Xe";
            } else if(radioButtonRuaXe.Checked)
            {
                nhomTho = "Rửa Xe";
            } else
            {
                nhomTho = "Trông coi xe";
            }

            MemoryStream hinhAnh = new MemoryStream();
            pictureBox1.Image.Save(hinhAnh, pictureBox1.Image.RawFormat);

            

            int born_year = dateTimePicker.Value.Year;
            int this_year = DateTime.Now.Year;

            if ((this_year - born_year) < 10 || (this_year - born_year) > 100)
            {
                MessageBox.Show("The Tho age must be between 10 and 100 year", "Invalid date of birth", MessageBoxButtons.OK);
            }
            else if (verif())
            {
                id = Int32.Parse(txtID.Text);
                if (tho.insertTho(id, ten, phone, adrs, bdate, nhomTho, hinhAnh))
                {
                    MessageBox.Show("Đã Thêm", "Add Tho", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Error", "Add Tho", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Empty Fields", "Add Tho", MessageBoxButtons.OK);
            }
        }

        private void ThemTho_Load(object sender, EventArgs e)
        {
            radioButtonRuaXe.Checked = true;
        }

        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {

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
