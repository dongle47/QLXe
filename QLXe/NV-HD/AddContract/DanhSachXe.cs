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
    public partial class DanhSachXe : Form
    {
        public DanhSachXe()
        {
            InitializeComponent();
        }
        MyDB mydb = new MyDB();
        HDThue hdThue = new HDThue();
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            AddContractForm f = new AddContractForm();
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

            f.radioButtonNguoiKhac.Checked = true;
            f.dateTimePickerToiDa.Value = (DateTime)dataGridView1.CurrentRow.Cells[6].Value;
            f.labelIdThue.Text= dataGridView1.CurrentRow.Cells[0].Value.ToString();

            f.Show();
            this.Close();

        }

        private void DanhSachXe_Load(object sender, EventArgs e)
        {
            radioButtonNo.Checked = true;
            string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            SqlCommand command = new SqlCommand("SELECT id, hinhXe, bangSo, tenChuXe, hinhChuXe, ngayBatDau, ngayKetThuc FROM HDThue WHERE " +
                "ngayKetThuc > '" + date + "' AND daDuocThue='0'");
            fillGridThue(command);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            AddContractForm f = new AddContractForm();
            f.Show();
            this.Close();
        }

        private void radioButtonAll_CheckedChanged(object sender, EventArgs e)
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            SqlCommand command = new SqlCommand("SELECT id, hinhXe, bangSo, tenChuXe, hinhChuXe, ngayBatDau, ngayKetThuc FROM HDThue WHERE " +
                "ngayKetThuc > '" + date + "' AND daDuocThue='0'");
            fillGridThue(command);
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
        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            string query;
            SqlCommand command = new SqlCommand();
            string dateNBD = dateTimePickerNBD.Value.ToString("yyyy-MM-dd");
            string dateNKT = dateTimePickerNKT.Value.ToString("yyyy-MM-dd");
            query = "SELECT * FROM HDThue WHERE ngayBatDau BETWEEN '" + dateNBD + "' AND '" + dateNKT + "'" +
                   "AND ngayKetThuc BETWEEN '" + dateNBD + "' AND '" + dateNKT + "' ";
            command = new SqlCommand(query);
            fillGridThue(command);
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            int contractId = Convert.ToInt32(textBoxSearch.Text);
            SqlCommand command = new SqlCommand("SELECT * FROM HDChoThue WHERE CONCAT(id,tenChuXe) LIKE '%" + textBoxSearch.Text + "%'");
            fillGridThue(command);
        }
    }
}
