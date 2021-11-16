using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace QLXe
{
    public partial class themXeForm : Form
    {
        public themXeForm()
        {
            InitializeComponent();
        }
        XE xe = new XE();
        int maxChoTrong = Globals.maxChoTrong;
        private void buttonThemXe_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("" + maxChoTrong);
            string loaiXe="";
            int mucPhat = 0;
            int soChoTrong=0;
            if (radioButtonXeDap.Checked)
            {
                loaiXe = "Xe Đạp";
                soChoTrong = maxChoTrong - Convert.ToInt32(xe.totalXeDap());
            }
            else if (radioButtonXeMay.Checked)
            {
                loaiXe = "Xe Máy";
                soChoTrong = maxChoTrong - Convert.ToInt32(xe.totalXeMay());
            }
            else if (radioButtonXeHoi.Checked)
            {
                loaiXe = "Xe Hơi";
                soChoTrong = maxChoTrong - Convert.ToInt32(xe.totalXeHoi());
            }
            MemoryStream nguoiGuiHieuXe = new MemoryStream();
            MemoryStream hinhXeBangSo = new MemoryStream();
            string guiTheo = comboBoxGuiTheo.SelectedItem.ToString();
            int thoiGianGui = Convert.ToInt32(numericUpDownThoiGianGui.Value);
            int mucPhi = xe.MucPhi(loaiXe, guiTheo, thoiGianGui);
            DateTime ngayBatDau = dateTimePickerNgayBatDau.Value;
            DateTime ngayKetThuc = dateTimePickerNgayKetThuc.Value;
            if (verif()==true)
            {
                if(soChoTrong!=0)
                {
                    pictureBoxNguoiGuiHoacHieuXe.Image.Save(nguoiGuiHieuXe, pictureBoxNguoiGuiHoacHieuXe.Image.RawFormat);
                    pictureBoxHinhXeHoacBangSo.Image.Save(hinhXeBangSo, pictureBoxHinhXeHoacBangSo.Image.RawFormat);
                    if (xe.insertXe(loaiXe, nguoiGuiHieuXe, hinhXeBangSo, guiTheo, thoiGianGui, mucPhi, mucPhat, ngayBatDau, ngayKetThuc))
                    {
                        MessageBox.Show("Xe Đã Được Thêm", "Thêm Xe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Lỗi", "Thêm Xe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Đã Hết Chỗ Trống", "Thêm Xe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Vui Lòng Điền Đầy Đủ Thông Tin", "Thêm Xe", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void buttonUpNguoiGuiHoacHieuXe_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select image(*.jpg; *.png; *.gif)| *.jpg; *.png; *.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBoxNguoiGuiHoacHieuXe.Image = Image.FromFile(opf.FileName);
            }
        }
        private void buttonUpHinhXeHoacBangSo_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select image(*.jpg; *.png; *.gif)| *.jpg; *.png; *.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBoxHinhXeHoacBangSo.Image = Image.FromFile(opf.FileName);
            }
        }
        private void radioButtonXeDap_Click(object sender, EventArgs e)
        {
            labelNguoiGuiHoacHieuXe.Text = "Người Gửi";
            labelHinhXeHoacBangSo.Text = "Hình Xe";
            int soChoTrong = maxChoTrong - Convert.ToInt32(xe.totalXeDap());
            labelSoChoTrong.Text = "Số Lượng Chỗ Trống: " + soChoTrong;
        }
        private void radioButtonXeMay_Click(object sender, EventArgs e)
        {
            labelNguoiGuiHoacHieuXe.Text = "Người Gửi";
            labelHinhXeHoacBangSo.Text = "Bảng Số";
            int soChoTrong = maxChoTrong - Convert.ToInt32(xe.totalXeMay());
            labelSoChoTrong.Text = "Số Lượng Chỗ Trống: " + soChoTrong;
        }
        private void radioButtonXeHoi_Click(object sender, EventArgs e)
        {
            labelHinhXeHoacBangSo.Text = "Bảng Số";
            labelNguoiGuiHoacHieuXe.Text = "Hiệu Xe";
            //int soChoTrong = Convert.ToInt32(xe.totalXe()) - Convert.ToInt32(xe.totalXeDap()) - Convert.ToInt32(xe.totalXeDap());
            int soChoTrong = maxChoTrong -  Convert.ToInt32(xe.totalXeHoi());
            labelSoChoTrong.Text = "Số Lượng Chỗ Trống: " + soChoTrong;
        }

        private void numericUpDownThoiGianGui_ValueChanged(object sender, EventArgs e)
        {
            //XE xe = new XE();
            string loaiXe = "";
            if (radioButtonXeDap.Checked)
            {
                loaiXe = "Xe Đạp";
            }
            else if (radioButtonXeMay.Checked)
            {
                loaiXe = "Xe Máy";
            }
            else if (radioButtonXeHoi.Checked)
            {
                loaiXe = "Xe Hơi";
            }
            string guiTheo = comboBoxGuiTheo.SelectedItem.ToString();
            int thoiGianGui = Convert.ToInt32(numericUpDownThoiGianGui.Value);
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
                tgThem = new System.TimeSpan(0, tgG+thoiGianGui, 0, 0);
            }
            else
            {
                tgThem = new System.TimeSpan(tgN * thoiGianGui, 0, 0, 0);
            }
            dateTimePickerNgayKetThuc.Value = dateTimePickerNgayBatDau.Value + tgThem;
        }
        private void comboBoxGuiTheo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string loaiXe = "";
            if (radioButtonXeDap.Checked)
            {
                loaiXe = "Xe Đạp";
            }
            else if (radioButtonXeMay.Checked)
            {
                loaiXe = "Xe Máy";
            }
            else if (radioButtonXeHoi.Checked)
            {
                loaiXe = "Xe Hơi";
            }
            string guiTheo = comboBoxGuiTheo.SelectedItem.ToString();
            int thoiGianGui = Convert.ToInt32(numericUpDownThoiGianGui.Value);
            int mucPhi = xe.MucPhi(loaiXe, guiTheo, thoiGianGui);
            labelMucPhi.Text = "Mức Phí: " + mucPhi;
        }

        private void themXeForm_Load(object sender, EventArgs e)
        {
            comboBoxGuiTheo.SelectedItem = "Giờ";
            radioButtonXeDap.Checked = true;
            dateTimePickerNgayBatDau.Value = DateTime.Now;
        }
        bool verif()
        {
            if (comboBoxGuiTheo.SelectedItem.ToString() == ""
                || pictureBoxHinhXeHoacBangSo.Image == null || pictureBoxNguoiGuiHoacHieuXe.Image == null

                )
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void dateTimePickerNgayKetThuc_ValueChanged(object sender, EventArgs e)
        {
            //string guiTheo = comboBoxGuiTheo.SelectedItem.ToString();
            //int thoiGianGui=0;
            //if (guiTheo == "Giờ")
            //{
            //    TimeSpan t = dateTimePickerNgayKetThuc.Value.Subtract(dateTimePickerNgayBatDau.Value);
            //    thoiGianGui = Convert.ToInt32(t.TotalHours);
            //}
            //else if (guiTheo == "Ngày")
            //{
            //    TimeSpan t = dateTimePickerNgayKetThuc.Value.Subtract(dateTimePickerNgayBatDau.Value);
            //    thoiGianGui = Convert.ToInt32(t.TotalDays);
            //}
            //int mucPhi = xe.MucPhi(labelLoaiXe.Text, "Ngày", thoiGianGui);
            //labelMucPhi.Text = "Mức Phí: " + mucPhi;
        }
    }
}
