using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLXe;
using QLXe.CongViec;

namespace QLXe
{
    public partial class ThemCongViecForm : Form
    {
        public ThemCongViecForm()
        {
            InitializeComponent();
        }
        ThoClass tho = new ThoClass();
        MyDB mydb = new MyDB();
        CONGVIEC congViec = new CONGVIEC();
        private void btnSelectXe_Click(object sender, EventArgs e)
        {
            DanhSachXeCongViecForm danhSachXe = new DanhSachXeCongViecForm();
            danhSachXe.Show();
            this.Close();
        }

        private void ThemCongViecForm_Load(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Tho");


            comboBoxNhanVien.DataSource = tho.getTho(command);
            comboBoxNhanVien.DisplayMember = "ten";
            comboBoxNhanVien.ValueMember = "id";

            //danh sách công việc
            comboBoxCongViec.DisplayMember = "Text";
            comboBoxCongViec.ValueMember = "Value";

            comboBoxCongViec.Items.Add(new { Text = "Rửa Xe", Value = "rua-xe" });
            comboBoxCongViec.Items.Add(new { Text = "Sửa Xe", Value = "sua-xe" });
            comboBoxCongViec.Items.Add(new { Text = "Trông coi xe", Value = "trong-coi-xe" });
        }

        private void comboBoxCongViec_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Tho", mydb.getConnection);


            if (comboBoxCongViec.SelectedIndex == 0)
            {
                command = new SqlCommand("SELECT * FROM THO WHERE nhomTho=@nhomTho", mydb.getConnection);
                command.Parameters.Add("@nhomTho", SqlDbType.NVarChar).Value = "Rửa Xe";
                dateTimePickerNgayLay.Value = DateTime.Now;
                dateTimePickerNgaySua.Value = DateTime.Now;
                dateTimePickerNgayLay.Enabled = false;
                dateTimePickerNgaySua.Enabled = false;

                int mucPhi = 0;
                if (labelLoaiXe.Text == "Xe Đạp")
                {
                    mucPhi = 1000;
                }
                else if (labelLoaiXe.Text == "Xe Máy")
                {
                    mucPhi = 3000;
                }
                else if (labelLoaiXe.Text == "Xe Hơi")
                {
                    mucPhi = 5000;
                }
                labelMucPhi.Text = "Mức Phí: " + mucPhi * 20;

            }
            else if (comboBoxCongViec.SelectedIndex == 1)
            {
                command = new SqlCommand("SELECT * FROM THO WHERE nhomTho=@nhomTho", mydb.getConnection);
                command.Parameters.Add("@nhomTho", SqlDbType.NVarChar).Value = "Sửa Xe";
                dateTimePickerNgayLay.Enabled = true;
                dateTimePickerNgaySua.Enabled = true;
            }
            else
            {
                command = new SqlCommand("SELECT * FROM THO WHERE nhomTho=@nhomTho", mydb.getConnection);
                command.Parameters.Add("@nhomTho", SqlDbType.NVarChar).Value = "Trông coi xe";
                dateTimePickerNgayLay.Enabled = false;
                dateTimePickerNgaySua.Enabled = false;
            }

            comboBoxNhanVien.DataSource = tho.getTho(command);
            comboBoxNhanVien.DisplayMember = "ten";
            comboBoxNhanVien.ValueMember = "id";
        }


        private void comboBoxNhanVien_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int id = int.Parse(comboBoxNhanVien.SelectedValue.ToString());
            SqlCommand command = new SqlCommand("SELECT * FROM THO WHERE id=@id", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            DataTable dataTable = tho.getTho(command);

            byte[] picTho;
            picTho = (byte[])dataTable.Rows[0][6];
            MemoryStream Tho = new MemoryStream(picTho);
            pictureBoxHinhTho.Image = Image.FromStream(Tho);
        }
        bool verif()
        {
            if (txtIDCV.Text == ""
                || pictureBoxBangSo.Image == null || pictureBoxHinhXe.Image == null

                )
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void btnAddCongViec_Click(object sender, EventArgs e)
        {
            int id ;
            int xeID;
            string loaiXe = labelLoaiXe.Text;
            MemoryStream hinhXe = new MemoryStream();
            MemoryStream bangSo = new MemoryStream();
            string loaiCongViec = comboBoxCongViec.Text;
            string tenTho = comboBoxNhanVien.Text;
            int idTho;
            MemoryStream hinhTho = new MemoryStream();
            DateTime ngaySua = dateTimePickerNgaySua.Value;
            DateTime ngayLay = dateTimePickerNgayLay.Value;

            int mucPhi=0;
            if(labelLoaiXe.Text=="Xe Đạp")
            {
                mucPhi = 1000;
            }
            else if(labelLoaiXe.Text=="Xe Máy")
            {
                mucPhi = 3000;
            }
            else if(labelLoaiXe.Text=="Xe Hơi")
            {
                mucPhi = 5000;
            }

            if(loaiCongViec=="Rửa Xe")
            {
                mucPhi *= 20;
            }
            else if(loaiCongViec=="Sửa Xe")
            {
                TimeSpan t = dateTimePickerNgayLay.Value.Subtract(dateTimePickerNgaySua.Value);
                int y = Convert.ToInt32(t.TotalHours);
                mucPhi = mucPhi * y;
            }
            else if(loaiCongViec=="Trông coi xe")
            {
                mucPhi = 0;
            }
            if (verif() == true)
            {
                id = int.Parse(txtIDCV.Text);
                xeID = int.Parse(idXe.Text);
                idTho = int.Parse(comboBoxNhanVien.SelectedValue.ToString());
                pictureBoxHinhXe.Image.Save(hinhXe, pictureBoxHinhXe.Image.RawFormat);
                pictureBoxBangSo.Image.Save(bangSo, pictureBoxBangSo.Image.RawFormat);
                pictureBoxHinhTho.Image.Save(hinhTho, pictureBoxHinhTho.Image.RawFormat);
                if (congViec.insertCV(id, loaiCongViec, xeID, loaiXe, hinhXe,bangSo, idTho, tenTho, hinhTho,ngaySua, ngayLay, mucPhi))
                {
                    MessageBox.Show("Công Việc Đã Được Thêm", "Thêm Công Việc", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Lỗi", "Thêm Công Việc", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui Lòng Điền Đầy Đủ Thông Tin", "Thêm Công Việc", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dateTimePickerNgayLay_ValueChanged(object sender, EventArgs e)
        {
            int mucPhi = 0;
            if (labelLoaiXe.Text == "Xe Đạp")
            {
                mucPhi = 1000;
            }
            else if (labelLoaiXe.Text == "Xe Máy")
            {
                mucPhi = 3000;
            }
            else if (labelLoaiXe.Text == "Xe Hơi")
            {
                mucPhi = 5000;
            }

            if (comboBoxCongViec.Text == "Rửa Xe")
            {
                mucPhi *= 20;
            }
            else if (comboBoxCongViec.Text == "Sửa Xe")
            {
                TimeSpan t = dateTimePickerNgayLay.Value.Subtract(dateTimePickerNgaySua.Value);
                int y = Convert.ToInt32(t.TotalHours);
                mucPhi = mucPhi * y;
            }
            labelMucPhi.Text = "Mức Phí: " + mucPhi;
        }
    }

}
