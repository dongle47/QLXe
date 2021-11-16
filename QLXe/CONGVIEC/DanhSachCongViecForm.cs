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
    public partial class DanhSachCongViecForm : Form
    {
        public DanhSachCongViecForm()
        {
            InitializeComponent();
        }
        CONGVIEC congViec = new CONGVIEC();
        ThoClass tho = new ThoClass();
        MyDB mydb = new MyDB();

        public void fillGrid(SqlCommand command)
        {
            dataGridView1.ReadOnly = true;
            DataGridViewImageColumn picCol1 = new DataGridViewImageColumn();
            DataGridViewImageColumn picCol2 = new DataGridViewImageColumn();
            DataGridViewImageColumn picCol3 = new DataGridViewImageColumn();
            dataGridView1.RowTemplate.Height = 80;
            dataGridView1.DataSource = congViec.getCV(command);
            picCol1 = (DataGridViewImageColumn)dataGridView1.Columns[4];
            picCol1.ImageLayout = DataGridViewImageCellLayout.Stretch;

            picCol2 = (DataGridViewImageColumn)dataGridView1.Columns[5];
            picCol2.ImageLayout = DataGridViewImageCellLayout.Stretch;

            picCol3 = (DataGridViewImageColumn)dataGridView1.Columns[8];
            picCol3.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.AllowUserToAddRows = false;
        }
        private void DanhSachCongViecForm_Load(object sender, EventArgs e)
        {
            radioButtonAll.Checked = true;
            radioButtonNo.Checked = true;

            SqlCommand command = new SqlCommand("SELECT * FROM CONGVIEC");
            fillGrid(command);
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            UpdateCongViecForm updateCongViecForm = new UpdateCongViecForm();

            updateCongViecForm.txtIDCV.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            updateCongViecForm.comboBoxCongViec.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            updateCongViecForm.idXe.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            updateCongViecForm.labelLoaiXe.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            updateCongViecForm.dateTimePickerNgaySua.Value = (DateTime)dataGridView1.CurrentRow.Cells[9].Value;
            updateCongViecForm.dateTimePickerNgayLay.Value = (DateTime)dataGridView1.CurrentRow.Cells[10].Value;

            updateCongViecForm.comboBoxNhanVien.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();


            byte[] picHinhXe;
            picHinhXe = (byte[])dataGridView1.CurrentRow.Cells[4].Value;
            MemoryStream pictureHinhXe = new MemoryStream(picHinhXe);
            updateCongViecForm.pictureBoxHinhXe.Image = Image.FromStream(pictureHinhXe);

            byte[] picBangSo;
            picBangSo = (byte[])dataGridView1.CurrentRow.Cells[5].Value;
            MemoryStream pictureBangSo = new MemoryStream(picBangSo);
            updateCongViecForm.pictureBoxBangSo.Image = Image.FromStream(pictureBangSo);

            byte[] picHinhTho;
            picHinhTho = (byte[])dataGridView1.CurrentRow.Cells[8].Value;
            MemoryStream pictureHinhTho = new MemoryStream(picHinhTho);
            updateCongViecForm.pictureBoxHinhTho.Image = Image.FromStream(pictureHinhTho);



            updateCongViecForm.Show();
        }

        private void radioButtonAll_CheckedChanged(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM CONGVIEC");
            
            fillGrid(command);
        }

        private void radioButtonRuaXe_CheckedChanged(object sender, EventArgs e)
        {
            
            SqlCommand command = new SqlCommand("SELECT * FROM CONGVIEC WHERE loaiCongViec =@loaiCongViec", mydb.getConnection);
            command.Parameters.Add("@loaiCongViec", SqlDbType.NVarChar).Value = "Rửa Xe";
            fillGrid(command);
        }

        private void radioButtonSuaXe_CheckedChanged(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM CONGVIEC WHERE loaiCongViec =@loaiCongViec", mydb.getConnection);
            command.Parameters.Add("@loaiCongViec", SqlDbType.NVarChar).Value = "Sửa Xe";
            fillGrid(command);
        }

        private void radioButtonCoiXe_CheckedChanged(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM CONGVIEC WHERE loaiCongViec=@loaiCongViec", mydb.getConnection);
            command.Parameters.Add("@loaiCongViec", SqlDbType.NVarChar).Value = "Trông coi xe";
            fillGrid(command);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string id = txtSearch.Text;
            SqlCommand command = new SqlCommand("SELECT * FROM CONGVIEC WHERE CONCAT(id,tenTho) LIKE '%" + txtSearch.Text + "%'");
            fillGrid(command);
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand();
            string query;
            if (radioButtonYes.Checked == true)
            {
                string dateNBD = dateTimePickerNBD.Value.ToString("yyyy-MM-dd");
                string dateNKT = dateTimePickerNKT.Value.ToString("yyyy-MM-dd");
                if (radioButtonAll.Checked == true)
                {
                    query = "SELECT * FROM CONGVIEC WHERE ngaySua BETWEEN '" + dateNBD + "' AND '" + dateNKT + "' ";
                    command = new SqlCommand(query, mydb.getConnection);

                }
                else if (radioButtonRuaXe.Checked == true)
                {
                    query = "SELECT * FROM CONGVIEC WHERE loaiCongViec=@lx AND ngaySua BETWEEN '" + dateNBD + "' AND '" + dateNKT + "'";
                    command = new SqlCommand(query, mydb.getConnection);
                    command.Parameters.Add("@lx", SqlDbType.NVarChar).Value = "Rửa Xe";
                }
                else if (radioButtonSuaXe.Checked == true)
                {
                    query = "SELECT * FROM CONGVIEC WHERE loaiCongViec=@lx AND ngaySua BETWEEN '" + dateNBD + "' AND '" + dateNKT + "'";
                    command = new SqlCommand(query, mydb.getConnection);
                    command.Parameters.Add("@lx", SqlDbType.NVarChar).Value = "Sửa Xe";
                }
                else if (radioButtonCoiXe.Checked == true)
                {
                    query = "SELECT * FROM CONGVIEC WHERE loaiCongViec=@lx AND ngaySua BETWEEN '" + dateNBD + "' AND '" + dateNKT + "'";
                    command = new SqlCommand(query, mydb.getConnection);
                    command.Parameters.Add("@lx", SqlDbType.NVarChar).Value = "Trông coi xe";
                }
                fillGrid(command);
            }
            else if (radioButtonNo.Checked == true)
            {

                if (radioButtonAll.Checked == true)
                {
                    query = "SELECT * FROM CONGVIEC";
                    command = new SqlCommand(query, mydb.getConnection);

                }
                else if (radioButtonRuaXe.Checked == true)
                {
                    query = "SELECT * FROM CONGVIEC WHERE loaiCongViec=@lx";
                    command = new SqlCommand(query, mydb.getConnection);
                    command.Parameters.Add("@lx", SqlDbType.NVarChar).Value = "Rửa Xe";
                }
                else if (radioButtonSuaXe.Checked == true)
                {
                    query = "SELECT * FROM CONGVIEC WHERE loaiCongViec=@lx";
                    command = new SqlCommand(query, mydb.getConnection);
                    command.Parameters.Add("@lx", SqlDbType.NVarChar).Value = "Sửa Xe";
                }
                else if (radioButtonCoiXe.Checked == true)
                {
                    query = "SELECT * FROM CONGVIEC WHERE loaiCongViec=@lx";
                    command = new SqlCommand(query, mydb.getConnection);
                    command.Parameters.Add("@lx", SqlDbType.NVarChar).Value = "Trông coi xe";
                }
                fillGrid(command);
            }
        }

        private void radioButtonNo_CheckedChanged(object sender, EventArgs e)
        {
            labelNBD.Enabled = false;
            labelNKT.Enabled = false;
            dateTimePickerNBD.Enabled = false;
            dateTimePickerNKT.Enabled = false;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
