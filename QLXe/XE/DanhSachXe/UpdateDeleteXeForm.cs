using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLXe
{
    public partial class UpdateDeleteXeForm : Form
    {
        public UpdateDeleteXeForm()
        {
            InitializeComponent();
        }
        XE xe = new XE();
        private void buttonXoa_Click(object sender, EventArgs e)
        {
            //xoa sv
            int id = Convert.ToInt32(labelID.Text);
            //Hien canh bao trc khi xoa
            if ((MessageBox.Show("Are You Sure You Want To Delete", "Delete Xe", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                
                if (xe.deleteXe(id))
                {
                    MessageBox.Show("Deleted", "Delete Xe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Xoa gia tri
                    comboBoxGuiTheo.SelectedItem="";
                    numericUpDownTgGui.Value = 0;
                    labelMucPhi.Text = "Mức Phí ";
                    pictureBoxHinhXe.Image = null;
                    pictureBoxNguoiGui.Image = null;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Not Deleted", "Delete Xe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32( labelID.Text);
            string loaiXe = labelLoaiXe.Text;
            string guiTheo = comboBoxGuiTheo.SelectedItem.ToString();
            int thoiGianGui = Convert.ToInt32(numericUpDownTgGui.Value);
            int mucPhi = xe.MucPhi(loaiXe,guiTheo,thoiGianGui);
            DateTime ngayBatDau = dateTimePickerNgayBatDau.Value;
            DateTime ngayKetThuc = dateTimePickerNgayKetThuc.Value;
            if (verif())
            {
                try
                {
                    if (xe.updateXe(id, guiTheo, thoiGianGui, mucPhi, ngayBatDau, ngayKetThuc))
                    {
                        MessageBox.Show("Đã Sửa", "Sửa Xe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Lỗi", "Sửa Xe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Sửa Xe", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Vui Lòng Điền Đầy Đủ Thông Tin", "Sửa Xe", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        bool verif()
        {
            if (comboBoxGuiTheo.SelectedItem.ToString() == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void numericUpDownTgGui_ValueChanged(object sender, EventArgs e)
        {
            string loaiXe = labelLoaiXe.Text;
            if (loaiXe=="Xe Đạp")
            {
                loaiXe = "Xe Đạp";
            }
            else if (loaiXe == "Xe Máy")
            {
                loaiXe = "Xe Máy";
            }
            else if (loaiXe == "Xe Hơi")
            {
                loaiXe = "Xe Hơi";
            }
            string guiTheo = comboBoxGuiTheo.SelectedItem.ToString();
            int thoiGianGui = Convert.ToInt32(numericUpDownTgGui.Value);
            int mucPhi = xe.MucPhi(loaiXe, guiTheo, thoiGianGui);
            labelMucPhi.Text = "Mức Phí: " + mucPhi;

            int tgN = 0;
            int tgG = 0;
            if (guiTheo == "Giờ")
            {
                tgG = 1;
            }
            else if (guiTheo == "Ngày")
            {
                tgN = 1;
            }
            else if (guiTheo == "Tuần")
            {
                tgN = 7;
            }
            else if (guiTheo == "Tháng")
            {
                tgN = DateTime.DaysInMonth(dateTimePickerNgayBatDau.Value.Year, dateTimePickerNgayBatDau.Value.Month);
            }
            TimeSpan tgThem;
            if (guiTheo == "Giờ")
            {
                tgThem = new System.TimeSpan(0, tgG + thoiGianGui, 0, 0);
            }
            else
            {
                tgThem = new System.TimeSpan(tgN * thoiGianGui, 0, 0, 0);
            }
            dateTimePickerNgayKetThuc.Value = dateTimePickerNgayBatDau.Value + tgThem;
        }

        private void comboBoxGuiTheo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string loaiXe = labelLoaiXe.Text;
            if (loaiXe == "Xe Đạp")
            {
                loaiXe = "Xe Đạp";
            }
            else if (loaiXe == "Xe Máy")
            {
                loaiXe = "Xe Máy";
            }
            else if (loaiXe == "Xe Hơi")
            {
                loaiXe = "Xe Hơi";
            }
            string guiTheo = comboBoxGuiTheo.SelectedItem.ToString();
            int thoiGianGui = Convert.ToInt32(numericUpDownTgGui.Value);
            int mucPhi = xe.MucPhi(loaiXe, guiTheo, thoiGianGui);
            labelMucPhi.Text = "Mức Phí: " + mucPhi;
        }

        private void UpdateDeleteXeForm_Load(object sender, EventArgs e)
        {

        }
    }
}
