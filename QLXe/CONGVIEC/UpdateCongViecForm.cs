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

namespace QLXe.CongViec
{
    public partial class UpdateCongViecForm : Form
    {
        public UpdateCongViecForm()
        {
            InitializeComponent();
        }
        ThoClass tho = new ThoClass();
        MyDB mydb = new MyDB();
        CONGVIEC congViec = new CONGVIEC();

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
        private void UpdateCongViecForm_Load(object sender, EventArgs e)
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

        private void btnAddCongViec_Click(object sender, EventArgs e)
        {
            int id;
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

            if (loaiCongViec == "Rửa Xe")
            {
                mucPhi *= 20;
            }
            else if (loaiCongViec == "Sửa Xe")
            {
                TimeSpan t = dateTimePickerNgayLay.Value.Subtract(dateTimePickerNgaySua.Value);
                int y = Convert.ToInt32(t.TotalHours);
                mucPhi = mucPhi * y;
            }


            if (verif() == true)
            {
                id = int.Parse(txtIDCV.Text);
                xeID = int.Parse(idXe.Text);
                idTho = int.Parse(comboBoxNhanVien.SelectedValue.ToString());
                pictureBoxHinhXe.Image.Save(hinhXe, pictureBoxHinhXe.Image.RawFormat);
                pictureBoxBangSo.Image.Save(bangSo, pictureBoxBangSo.Image.RawFormat);
                pictureBoxHinhTho.Image.Save(hinhTho, pictureBoxHinhTho.Image.RawFormat);
                if(MessageBox.Show("Mức Phí: " + mucPhi, "Cập Nhật Công Việc", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (congViec.updateCV(id, loaiCongViec, xeID, loaiXe, hinhXe, bangSo, idTho, tenTho, hinhTho, ngaySua, ngayLay, mucPhi))
                    {
                        MessageBox.Show("Công Việc Đã Được Cập Nhật", "Cập Nhật Công Việc", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Lỗi", "Cập Nhật Công Việc", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui Lòng Điền Đầy Đủ Thông Tin", "Cập Nhật Công Việc", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
