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

namespace QLXe
{
    
    public partial class EditContractForm : Form
    {
        public EditContractForm()
        {
            InitializeComponent();
        }
        HDChoThue hdChoThue = new HDChoThue();
        HDThue hdThue = new HDThue();
        int nvId = Globals.globalUserId;
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (radioButtonChoThue.Checked == true)
            {
                EditContractChoThue f = new EditContractChoThue();
                f.textBoxID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                f.labelLoaiHD.Text = "choThue";
                byte[] picHinhXe, picbangSo, picChuXe, picNgThue;

                picHinhXe = (byte[])dataGridView1.CurrentRow.Cells[1].Value;
                picbangSo = (byte[])dataGridView1.CurrentRow.Cells[2].Value;
                picChuXe = (byte[])dataGridView1.CurrentRow.Cells[4].Value;
                picNgThue = (byte[])dataGridView1.CurrentRow.Cells[8].Value;

                MemoryStream hinhXe = new MemoryStream(picHinhXe);
                MemoryStream bangSo = new MemoryStream(picbangSo);
                MemoryStream chuXe = new MemoryStream(picChuXe);
                MemoryStream ngThue = new MemoryStream(picNgThue);

                f.pictureBoxHinhXe.Image = Image.FromStream(hinhXe);
                f.pictureBoxBangSo.Image = Image.FromStream(bangSo);
                f.pictureBoxHinhChuXe.Image = Image.FromStream(chuXe);
                f.pictureBoxHinhNguoiThue.Image = Image.FromStream(ngThue);

                f.textBoxTenChuXe.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                f.textBoxTenNguoiThue.Text=dataGridView1.CurrentRow.Cells[7].Value.ToString();

                f.dateTimePickerNBD.Value = (DateTime)dataGridView1.CurrentRow.Cells[5].Value;
                f.dateTimePickerNKT.Value = (DateTime)dataGridView1.CurrentRow.Cells[6].Value;

                f.Show();
            }
            else if(radioButtonThue.Checked==true)
            {
                EditContractChoThue f = new EditContractChoThue();
                f.textBoxID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                f.labelLoaiHD.Text = "thue";
                byte[] picHinhXe, picbangSo, picChuXe;
                picHinhXe = (byte[])dataGridView1.CurrentRow.Cells[1].Value;
                picbangSo = (byte[])dataGridView1.CurrentRow.Cells[2].Value;
                picChuXe = (byte[])dataGridView1.CurrentRow.Cells[4].Value;
                MemoryStream hinhXe = new MemoryStream(picHinhXe);
                MemoryStream bangSo = new MemoryStream(picbangSo);
                MemoryStream chuXe = new MemoryStream(picChuXe);
                f.pictureBoxHinhXe.Image = Image.FromStream(hinhXe);
                f.pictureBoxBangSo.Image = Image.FromStream(bangSo);
                f.pictureBoxHinhChuXe.Image = Image.FromStream(chuXe);

                f.textBoxTenChuXe.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();

                f.dateTimePickerNBD.Value = (DateTime)dataGridView1.CurrentRow.Cells[5].Value;
                f.dateTimePickerNKT.Value = (DateTime)dataGridView1.CurrentRow.Cells[6].Value;

                f.Show();
            }
        }
        private void EditContractForm_Load(object sender, EventArgs e)
        {
            radioButtonNo.Checked = true;
            radioButtonChoThue.Checked = true;
            SqlCommand command = new SqlCommand("SELECT id, hinhXe, bangSo, tenChuXe, hinhChuXe, " +
                "ngayBatDau, ngayKetThuc, tenNguoiThue, hinhNguoiThue FROM HDChoThue WHERE nv_id=" + nvId);
            fillGridChoThue(command);
        }
        public void fillGridChoThue(SqlCommand command)
        {
            dataGridView1.ReadOnly = true;
            DataGridViewImageColumn picCol1 = new DataGridViewImageColumn();
            DataGridViewImageColumn picCol2 = new DataGridViewImageColumn();
            DataGridViewImageColumn picCol3 = new DataGridViewImageColumn();
            DataGridViewImageColumn picCol4 = new DataGridViewImageColumn();
            dataGridView1.RowTemplate.Height = 80;
            dataGridView1.DataSource = hdChoThue.selectContractList(command);
            picCol1 = (DataGridViewImageColumn)dataGridView1.Columns[1];
            picCol1.ImageLayout = DataGridViewImageCellLayout.Stretch;
            picCol2 = (DataGridViewImageColumn)dataGridView1.Columns[2];
            picCol2.ImageLayout = DataGridViewImageCellLayout.Stretch;
            picCol3 = (DataGridViewImageColumn)dataGridView1.Columns[4];
            picCol3.ImageLayout = DataGridViewImageCellLayout.Stretch;
            picCol4 = (DataGridViewImageColumn)dataGridView1.Columns[8];
            picCol4.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.AllowUserToAddRows = false;
        }
        public void fillGridThue(SqlCommand command)
        {
            dataGridView1.ReadOnly = true;
            DataGridViewImageColumn picCol1 = new DataGridViewImageColumn();
            DataGridViewImageColumn picCol2 = new DataGridViewImageColumn();
            DataGridViewImageColumn picCol3 = new DataGridViewImageColumn();
            dataGridView1.RowTemplate.Height = 80;
            dataGridView1.DataSource = hdThue.selectContractList(command);
            picCol1 = (DataGridViewImageColumn)dataGridView1.Columns[1];
            picCol1.ImageLayout = DataGridViewImageCellLayout.Stretch;
            picCol2 = (DataGridViewImageColumn)dataGridView1.Columns[2];
            picCol2.ImageLayout = DataGridViewImageCellLayout.Stretch;
            picCol3 = (DataGridViewImageColumn)dataGridView1.Columns[4];
            picCol3.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.AllowUserToAddRows = false;

            //dataGridView1.Columns[0].Width = 70;
            //dataGridView1.Columns[1].Width = 70;
            //dataGridView1.Columns[2].Width = 70;
            //dataGridView1.Columns[3].Width = 70;
            //dataGridView1.Columns[4].Width = 70;
            //dataGridView1.Columns[5].Width = 70;
            //dataGridView1.Columns[6].Width = 70;
        }

        private void radioButtonChoThue_CheckedChanged(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT id, hinhXe, bangSo, tenChuXe, hinhChuXe, " +
                "ngayBatDau, ngayKetThuc, tenNguoiThue, hinhNguoiThue FROM HDChoThue WHERE nv_id=" + nvId);
            fillGridChoThue(command);
        }

        private void radioButtonThue_CheckedChanged(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT id, hinhXe, bangSo, tenChuXe, hinhChuXe, " +
                "ngayBatDau, ngayKetThuc FROM HDThue WHERE nv_id=" + nvId);
            fillGridThue(command);
        }

     

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            radioButtonChoThue.Checked = true;
            SqlCommand command = new SqlCommand("SELECT id, hinhXe, bangSo, tenChuXe, hinhChuXe, " +
                "ngayBatDau, ngayKetThuc, tenNguoiThue, hinhNguoiThue FROM HDChoThue WHERE nv_id=" + nvId);
            fillGridChoThue(command);
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (radioButtonChoThue.Checked == true)
            {
                SqlCommand command = new SqlCommand("SELECT * FROM HDChoThue WHERE WHERE CONCAT(HDChoTHue.id, HDChoThue.tenChuXe, HDChoThue.tenNguoiThue, NV.ten) LIKE '%" + textBoxSearch.Text + "%'"); 
                fillGridChoThue(command);
            }
            else if (radioButtonThue.Checked == true)
            {
                SqlCommand command = new SqlCommand("SELECT * FROM HDThue WHERE CONCAT(HDChoTHue.id, HDChoThue.tenChuXe, HDChoThue.tenNguoiThue, NV.ten) LIKE '%" + textBoxSearch.Text + "%'");
                fillGridThue(command);
            }
        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            string query;
            SqlCommand command = new SqlCommand();
            if (radioButtonYes.Checked == true)
            {
                string dateNBD = dateTimePickerNBD.Value.ToString("yyyy-MM-dd");
                string dateNKT = dateTimePickerNKT.Value.ToString("yyyy-MM-dd");
                if (radioButtonChoThue.Checked)
                {
                    query = "SELECT * FROM HDChoThue WHERE ngayBatDau BETWEEN '" + dateNBD + "' AND '" + dateNKT + "'" +
                         "AND ngayKetThuc BETWEEN '" + dateNBD + "' AND '" + dateNKT + "' ";
                    command = new SqlCommand(query);
                    fillGridChoThue(command);
                }
                else if (radioButtonThue.Checked)
                {
                    query = "SELECT * FROM HDThue WHERE ngayBatDau BETWEEN '" + dateNBD + "' AND '" + dateNKT + "'" +
                         "AND ngayKetThuc BETWEEN '" + dateNBD + "' AND '" + dateNKT + "' ";
                    command = new SqlCommand(query);
                    fillGridThue(command);
                }
            }
        }
    }
}
