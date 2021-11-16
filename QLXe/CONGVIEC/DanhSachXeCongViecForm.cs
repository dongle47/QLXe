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
    public partial class DanhSachXeCongViecForm : Form
    {
        public DanhSachXeCongViecForm()
        {
            InitializeComponent();
        }
        MyDB mydb = new MyDB();
        XE xe = new XE();
        public void fillGrid(SqlCommand command)
        {
            dataGridView1.ReadOnly = true;
            DataGridViewImageColumn picCol1 = new DataGridViewImageColumn();
            DataGridViewImageColumn picCol2 = new DataGridViewImageColumn();
            dataGridView1.RowTemplate.Height = 80;
            dataGridView1.DataSource = xe.getXe(command);
            picCol1 = (DataGridViewImageColumn)dataGridView1.Columns[2];
            picCol1.ImageLayout = DataGridViewImageCellLayout.Stretch;
            picCol2 = (DataGridViewImageColumn)dataGridView1.Columns[3];
            picCol2.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.AllowUserToAddRows = false;
        }
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string id = textBoxSearch.Text;
            SqlCommand command = new SqlCommand("SELECT * FROM XE WHERE id=" + id);
            fillGrid(command);
        }

        private void radioButtonAll_CheckedChanged(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM XE");
            fillGrid(command);
        }

        private void radioButtonSearchXeDap_CheckedChanged(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM XE WHERE loaiXe=@xd", mydb.getConnection);
            command.Parameters.Add("@xd", SqlDbType.NVarChar).Value = "Xe Đạp";
            fillGrid(command);
        }

        private void radioButtonSearchXeMay_CheckedChanged(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM XE WHERE loaiXe=@xm", mydb.getConnection);
            command.Parameters.Add("@xm", SqlDbType.NVarChar).Value = "Xe Máy";
            fillGrid(command);
        }

        private void radioButtonSearchXeHoi_CheckedChanged(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM XE WHERE loaiXe=@xh", mydb.getConnection);
            command.Parameters.Add("@xh", SqlDbType.NVarChar).Value = "Xe Hơi";
            fillGrid(command);
        }

        private void DanhSachXeCongViecForm_Load(object sender, EventArgs e)
        {
            radioButtonAll.Checked = true;
            radioButtonNo.Checked = true;
            //this line load data into 
            SqlCommand command = new SqlCommand("SELECT * FROM XE");
            dataGridView1.ReadOnly = true;
            
            //xu ly hinh anh
            DataGridViewImageColumn picCol1 = new DataGridViewImageColumn();
            DataGridViewImageColumn picCol2 = new DataGridViewImageColumn();
            dataGridView1.RowTemplate.Height = 80;
            dataGridView1.DataSource = xe.getXe(command);
            picCol1 = (DataGridViewImageColumn)dataGridView1.Columns[2];
            picCol1.ImageLayout = DataGridViewImageCellLayout.Stretch;
            picCol2 = (DataGridViewImageColumn)dataGridView1.Columns[3];
            picCol2.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.AllowUserToAddRows = false;


            dataGridView1.Columns[0].Width = 70;
            dataGridView1.Columns[1].Width = 70;
            dataGridView1.Columns[2].Width = 70;
            dataGridView1.Columns[3].Width = 70;
            dataGridView1.Columns[4].Width = 70;
            dataGridView1.Columns[5].Width = 70;
            dataGridView1.Columns[6].Width = 70;
            dataGridView1.Columns[7].Width = 70;
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {

            ThemCongViecForm f = new ThemCongViecForm();
            byte[] picHinhXe, picbangSo;
            picHinhXe = (byte[])dataGridView1.CurrentRow.Cells[2].Value;
            picbangSo = (byte[])dataGridView1.CurrentRow.Cells[3].Value;
            MemoryStream hinhXe = new MemoryStream(picHinhXe);
            MemoryStream bangSo = new MemoryStream(picbangSo);

            f.pictureBoxHinhXe.Image = Image.FromStream(hinhXe);
            f.pictureBoxBangSo.Image = Image.FromStream(bangSo);
            f.labelLoaiXe.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            f.idXe.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();



            f.Show();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ThemCongViecForm themCongViecForm = new ThemCongViecForm();
            themCongViecForm.Show();
            this.Close();
        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand();
            string query;
            if (radioButtonYes.Checked == true)
            {
                string dateNBD = dateTimePickerNBD.Value.ToString("yyyy-MM-dd HH:mm:ss");
                string dateNKT = dateTimePickerNKT.Value.ToString("yyyy-MM-dd HH:mm:ss");
                if (radioButtonAll.Checked == true)
                {
                    query = "SELECT * FROM XE WHERE ngayBatDau BETWEEN '" + dateNBD + "' AND '" + dateNKT + "' ";
                    command = new SqlCommand(query, mydb.getConnection);
                }
                else if (radioButtonXeDap.Checked == true)
                {
                    query = "SELECT * FROM XE WHERE loaiXe=@lx AND ngayBatDau BETWEEN '" + dateNBD + "' AND '" + dateNKT + "'";
                    command = new SqlCommand(query, mydb.getConnection);
                    command.Parameters.Add("@lx", SqlDbType.NVarChar).Value = "Xe Đạp";
                }
                else if (radioButtonXeMay.Checked == true)
                {
                    query = "SELECT * FROM XE WHERE loaiXe=@lx AND ngayBatDau BETWEEN '" + dateNBD + "' AND '" + dateNKT + "'";
                    command = new SqlCommand(query, mydb.getConnection);
                    command.Parameters.Add("@lx", SqlDbType.NVarChar).Value = "Xe Máy";
                }
                else if (radioButtonXeHoi.Checked == true)
                {
                    query = "SELECT * FROM XE WHERE loaiXe=@lx AND ngayBatDau BETWEEN '" + dateNBD + "' AND '" + dateNKT + "'";
                    command = new SqlCommand(query, mydb.getConnection);
                    command.Parameters.Add("@lx", SqlDbType.NVarChar).Value = "Xe Hơi";
                }
                fillGrid(command);
            }
            else if (radioButtonNo.Checked == true)
            {
                if (radioButtonAll.Checked == true)
                {
                    query = "SELECT * FROM XE ";
                    command = new SqlCommand(query, mydb.getConnection);
                }
                else if (radioButtonXeDap.Checked == true)
                {
                    query = "SELECT * FROM XE WHERE loaiXe=@xd";
                    command = new SqlCommand(query, mydb.getConnection);
                    command.Parameters.Add("@xd", SqlDbType.NVarChar).Value = "Xe Đạp";
                }
                else if (radioButtonXeMay.Checked == true)
                {
                    query = "SELECT * FROM XE WHERE loaiXe=@xd";
                    command = new SqlCommand(query, mydb.getConnection);
                    command.Parameters.Add("@xd", SqlDbType.NVarChar).Value = "Xe Máy";
                }
                else if (radioButtonXeHoi.Checked == true)
                {
                    query = "SELECT * FROM XE WHERE loaiXe=@xd";
                    command = new SqlCommand(query, mydb.getConnection);
                    command.Parameters.Add("@xd", SqlDbType.NVarChar).Value = "Xe Hơi";
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

        private void radioButtonYes_CheckedChanged(object sender, EventArgs e)
        {
            labelNBD.Enabled = true;
            labelNKT.Enabled = true;
            dateTimePickerNBD.Enabled = true;
            dateTimePickerNKT.Enabled = true;
        }

        private void radioButtonAll_CheckedChanged_1(object sender, EventArgs e)
        {

        }
    }
}
