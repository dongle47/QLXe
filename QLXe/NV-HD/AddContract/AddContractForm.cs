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
    public partial class AddContractForm : Form
    {
        public AddContractForm()
        {
            InitializeComponent();
        }
        int userId = Globals.globalUserId;
        HDChoThue hdChoThue = new HDChoThue();
        HDThue hdThue = new HDThue();
        public void setHinhXe(Image pic)
        {
            pictureBoxHinhXe.Image = pic;
        }
        private void AddContractForm_Load(object sender, EventArgs e)
        {
            radioButtonChoThue.Checked = true;
            radioButtonNguoiKhac.Checked = true;
        }

        private void buttonUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select image(*.jpg; *.png; *.gif)| *.jpg; *.png; *.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBoxHinhXe.Image = Image.FromFile(opf.FileName);
            }
        }
        private void buttonUpload2_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select image(*.jpg; *.png; *.gif)| *.jpg; *.png; *.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBoxBangSo.Image = Image.FromFile(opf.FileName);
            }
        }
        private void buttonUpload4_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select image(*.jpg; *.png; *.gif)| *.jpg; *.png; *.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBoxHinhChuXe.Image = Image.FromFile(opf.FileName);
            }
        }
        private void buttonUpload3_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select image(*.jpg; *.png; *.gif)| *.jpg; *.png; *.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBoxHinhNguoiThue.Image = Image.FromFile(opf.FileName);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            int id ;
            MemoryStream hinhXe = new MemoryStream();
            MemoryStream bangSo = new MemoryStream();
            string tenChuXe = textBoxTenChuXe.Text;
            MemoryStream hinhChuXe = new MemoryStream();
            DateTime NBD = dateTimePickerNBD.Value;
            DateTime NKT = dateTimePickerNKT.Value;

            int mucPhi = 0;
            TimeSpan t = dateTimePickerNKT.Value.Subtract(dateTimePickerNBD.Value);
            if (radioButtonThue.Checked == true)
            {
                mucPhi = 10000;
            }
            else if (radioButtonChoThue.Checked == true)
            {
                mucPhi = 50000;
            }

            mucPhi *= Convert.ToInt32(t.TotalDays);

            if (radioButtonChoThue.Checked == true)
            {
                string tenNgThue = textBoxTenNguoiThue.Text;
                MemoryStream hinhNgThue = new MemoryStream();
                if (verif())
                {
                    id = Convert.ToInt32(textBoxID.Text);
                    if (radioButtonNguoiKhac.Checked == true)
                    {
                        if (DateTime.Compare(dateTimePickerNKT.Value, dateTimePickerToiDa.Value) < 0)
                        {
                            pictureBoxHinhXe.Image.Save(hinhXe, pictureBoxHinhXe.Image.RawFormat);
                            pictureBoxBangSo.Image.Save(bangSo, pictureBoxBangSo.Image.RawFormat);
                            pictureBoxHinhChuXe.Image.Save(hinhChuXe, pictureBoxHinhChuXe.Image.RawFormat);
                            pictureBoxHinhNguoiThue.Image.Save(hinhNgThue, pictureBoxHinhNguoiThue.Image.RawFormat);
                            if (hdChoThue.insertContract(id, hinhXe, bangSo, tenChuXe, hinhChuXe, NBD, NKT, tenNgThue, hinhNgThue, userId, mucPhi)
                                && hdThue.danhDauContract(Convert.ToInt32( labelIdThue.Text),1))
                            {
                                MessageBox.Show("New Contract Added", "Add Contract", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Error", "Add Contract", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Vượt Quá Ngày Thuê Tối Đa", "Add Contract", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else if (radioButtonCongTy.Checked == true)
                    {
                        pictureBoxHinhXe.Image.Save(hinhXe, pictureBoxHinhXe.Image.RawFormat);
                        pictureBoxBangSo.Image.Save(bangSo, pictureBoxBangSo.Image.RawFormat);
                        pictureBoxHinhChuXe.Image.Save(hinhChuXe, pictureBoxHinhChuXe.Image.RawFormat);
                        pictureBoxHinhNguoiThue.Image.Save(hinhNgThue, pictureBoxHinhNguoiThue.Image.RawFormat);
                        if (hdChoThue.insertContract(id, hinhXe, bangSo, tenChuXe, hinhChuXe, NBD, NKT, tenNgThue, hinhNgThue, userId, mucPhi))
                        {
                            MessageBox.Show("New Contract Added", "Add Contract", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Error", "Add Contract", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Empty Fields", "Add Contract", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else if (radioButtonThue.Checked == true)
            {
                if (verif())
                {
                    id = Convert.ToInt32(textBoxID.Text);
                    pictureBoxHinhXe.Image.Save(hinhXe, pictureBoxHinhXe.Image.RawFormat);
                    pictureBoxBangSo.Image.Save(bangSo, pictureBoxBangSo.Image.RawFormat);
                    pictureBoxHinhChuXe.Image.Save(hinhChuXe, pictureBoxHinhChuXe.Image.RawFormat);
                    if (hdThue.insertContract(id, hinhXe, bangSo, tenChuXe, hinhChuXe, NBD, NKT, userId, mucPhi,0))
                    {
                        MessageBox.Show("New Contract Added", "Add Contract", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error", "Add Contract", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Empty Fields", "Add Contract", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            
        }
        bool verif()
        {
            if ((textBoxID.Text.Trim() == "")
                    || (pictureBoxHinhXe.Image==null)
                    || (pictureBoxBangSo.Image==null)
                    || (textBoxTenChuXe.Text.Trim() == "")
                    || (pictureBoxHinhChuXe.Image==null)
                    )
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void radioButtonThue_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Enabled = false;
            radioButtonCongTy.Enabled = false;
            radioButtonNguoiKhac.Enabled = false;
            buttonSelect.Enabled = false;
            dateTimePickerToiDa.Enabled = false;
            labelNTTD.Enabled = false;
        }

        private void radioButtonCongTy_CheckedChanged(object sender, EventArgs e)
        {
            buttonSelect.Enabled = false;
            textBoxTenChuXe.Text = "Công Ty ABC";
            labelNTTD.Text = "Không Giới Hạn Ngày Thuê";
            pictureBoxHinhChuXe.Image = Image.FromFile("C:/Users/PC/Pictures/matt-bagshaw-showroomdusk-viewthroughmedium.jpg");
        }

        private void radioButtonChoThue_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Enabled = true;
            radioButtonCongTy.Enabled = true;
            radioButtonNguoiKhac.Enabled = true;
            buttonSelect.Enabled = true;
            dateTimePickerToiDa.Enabled = false;
        }

        private void radioButtonNguoiKhac_CheckedChanged(object sender, EventArgs e)
        {
            buttonSelect.Enabled = true;
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            DanhSachXe f = new DanhSachXe();
            f.Show();
            this.Close();
        }
        private void dateTimePickerNKT_ValueChanged(object sender, EventArgs e)
        {
            int mucPhi = 0;
            TimeSpan t = dateTimePickerNKT.Value.Subtract(dateTimePickerNBD.Value);
            if (radioButtonThue.Checked == true)
            {
                mucPhi = 10000;
            }
            else if (radioButtonChoThue.Checked == true)
            {
                mucPhi = 50000;
            }

            mucPhi *= Convert.ToInt32(t.TotalDays);
            labelMucPhi.Text = "Mức Phí: " + mucPhi;
        }
    }
}
