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
    public partial class EditContractChoThue : Form
    {
        public EditContractChoThue()
        {
            InitializeComponent();
        }
        HDChoThue hdChoThue = new HDChoThue();
        HDThue hdThue = new HDThue();
        int nvId = Globals.globalUserId;

        private void EditContract_Load(object sender, EventArgs e)
        {
            
            if (labelLoaiHD.Text == "thue")
            {
                panel1.Enabled = false;
                
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            int mucPhi = 0;
            TimeSpan t = dateTimePickerNKT.Value.Subtract(dateTimePickerNBD.Value);
            if (labelLoaiHD.Text == "choThue")
            {
                mucPhi = 10000;
            }
            else if (labelLoaiHD.Text == "thue")
            {
                mucPhi = 50000;
            }

            mucPhi *= Convert.ToInt32(t.TotalDays);

            if (labelLoaiHD.Text == "choThue")
            {
                int id = Convert.ToInt32(textBoxID.Text);
                MemoryStream hinhXe = new MemoryStream();
                MemoryStream bangSo = new MemoryStream();
                MemoryStream chuXe = new MemoryStream();
                MemoryStream ngThue = new MemoryStream();
                string tenChuXe = textBoxTenChuXe.Text;
                string tenNgThue = textBoxTenNguoiThue.Text;
                DateTime nbd = dateTimePickerNBD.Value;
                DateTime nkt = dateTimePickerNKT.Value;


                try
                {
                    pictureBoxHinhXe.Image.Save(hinhXe, pictureBoxHinhXe.Image.RawFormat);
                    pictureBoxBangSo.Image.Save(bangSo, pictureBoxBangSo.Image.RawFormat);
                    pictureBoxHinhChuXe.Image.Save(chuXe, pictureBoxHinhChuXe.Image.RawFormat);
                    pictureBoxHinhNguoiThue.Image.Save(ngThue, pictureBoxHinhNguoiThue.Image.RawFormat);
                    if (hdChoThue.updateContract(id, hinhXe, bangSo, tenChuXe, chuXe, nbd, nkt, tenNgThue, ngThue, nvId, mucPhi))
                    {
                        MessageBox.Show("Contract Information Updated", "Edit Contract", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error", "Edit Contract", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Edit Contract", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            else if (labelLoaiHD.Text == "thue")
            {
                int id = Convert.ToInt32(textBoxID.Text);
                MemoryStream hinhXe = new MemoryStream();
                MemoryStream bangSo = new MemoryStream();
                MemoryStream chuXe = new MemoryStream();
                string tenChuXe = textBoxTenChuXe.Text;
                DateTime nbd = dateTimePickerNBD.Value;
                DateTime nkt = dateTimePickerNKT.Value;
                try
                {
                    pictureBoxHinhXe.Image.Save(hinhXe, pictureBoxHinhXe.Image.RawFormat);
                    pictureBoxBangSo.Image.Save(bangSo, pictureBoxBangSo.Image.RawFormat);
                    pictureBoxHinhChuXe.Image.Save(chuXe, pictureBoxHinhChuXe.Image.RawFormat);
                    if (hdThue.updateContract(id, hinhXe, bangSo, tenChuXe, chuXe, nbd, nkt, nvId, mucPhi))
                    {
                        MessageBox.Show("Contract Information Updated", "Edit Contract", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error", "Edit Contract", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Edit Contract", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void buttonUploadHX_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select image(*.jpg; *.png; *.gif)| *.jpg; *.png; *.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBoxHinhXe.Image = Image.FromFile(opf.FileName);
            }
        }

        private void buttonUploadBS_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select image(*.jpg; *.png; *.gif)| *.jpg; *.png; *.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBoxBangSo.Image = Image.FromFile(opf.FileName);
            }
        }

        private void buttonUploadChuXe_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select image(*.jpg; *.png; *.gif)| *.jpg; *.png; *.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBoxHinhChuXe.Image = Image.FromFile(opf.FileName);
            }
        }

        private void buttonUploadNgThue_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select image(*.jpg; *.png; *.gif)| *.jpg; *.png; *.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBoxHinhNguoiThue.Image = Image.FromFile(opf.FileName);
            }
        }

        private void dateTimePickerNKT_ValueChanged(object sender, EventArgs e)
        {
            int mucPhi = 0;
            TimeSpan t = dateTimePickerNKT.Value.Subtract(dateTimePickerNBD.Value);
            if (labelLoaiHD.Text == "thue")
            {
                mucPhi = 10000;
            }
            else if (labelLoaiHD.Text == "choThue")
            {
                mucPhi = 50000;
            }

            mucPhi *= Convert.ToInt32(t.TotalDays);
            labelMucPhi.Text = "Mức Phí: " + mucPhi;


        }
    }
}
