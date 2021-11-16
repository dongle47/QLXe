using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using QLXe;

namespace QLXe
{
    public partial class ListTho : Form
    {
        public ListTho()
        {
            InitializeComponent();
        }
        ThoClass tho = new ThoClass();
        MyDB mydb = new MyDB();
        public void fillGrid(SqlCommand command)
        {
            dataGridView1.ReadOnly = true;
            DataGridViewImageColumn picCol1 = new DataGridViewImageColumn();
            DataGridViewImageColumn picCol2 = new DataGridViewImageColumn();
            dataGridView1.RowTemplate.Height = 80;
            dataGridView1.DataSource = tho.getTho(command);
            picCol1 = (DataGridViewImageColumn)dataGridView1.Columns[6];
            picCol1.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.AllowUserToAddRows = false;
        }
        private void ListTho_Load(object sender, EventArgs e)
        {
            radioButtonAll.Checked = true;
            radioButtonNo.Checked = true;
            SqlCommand command = new SqlCommand("SELECT * FROM Tho");
            fillGrid(command);
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            UpdateTho updateTho = new UpdateTho();

            updateTho.textBoxID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            updateTho.txtName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            updateTho.txtPhone.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            updateTho.txtAddress.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            updateTho.dateTimePicker.Value = (DateTime)dataGridView1.CurrentRow.Cells[4].Value;

            
            string nhomTho = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            
            if (nhomTho == "Rửa Xe")
            {
                updateTho.radioButtonRuaXe.Checked = true;
            } else if (nhomTho == "Sửa Xe")
            {
                updateTho.radioButtonSuaXe.Checked = true;
            } else
            {
                updateTho.radioButtonCoiXe.Checked = true;
            }

            byte[] picHinhTho;
            picHinhTho = (byte[])dataGridView1.CurrentRow.Cells[6].Value;
            MemoryStream pictureHinhTho = new MemoryStream(picHinhTho);
            updateTho.pictureBox1.Image = Image.FromStream(pictureHinhTho);

            updateTho.Show();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string id = txtSearch.Text;
            SqlCommand command = new SqlCommand("SELECT * FROM THO WHERE CONCAT(id,ten) LIKE '%" + txtSearch.Text + "%'");
            fillGrid(command);
        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand();
            string query;
            if (radioButtonYes.Checked == true)
            {
                string dateNBD = dateTimePickerNBD.Value.ToString("yyyy-MM-dd");
                string dateNKT = dateTimePickerNKT.Value.ToString("yyyy-MM-dd");
                if (radioButtonAll.Checked == true)
                {
                    query = "SELECT * FROM THO WHERE ngaySinh BETWEEN '" + dateNBD + "' AND '" + dateNKT + "' ";
                    command = new SqlCommand(query, mydb.getConnection);

                }
                else if (radioButtonSuaXe.Checked == true)
                {
                    query = "SELECT * FROM THO WHERE nhomTho=@lx AND ngaySinh BETWEEN '" + dateNBD + "' AND '" + dateNKT + "'";
                    command = new SqlCommand(query, mydb.getConnection);
                    command.Parameters.Add("@lx", SqlDbType.NVarChar).Value = "Sửa Xe";
                }
                else if (radioButtonRuaXe.Checked == true)
                {
                    query = "SELECT * FROM THO WHERE nhomTho=@lx AND ngaySinh BETWEEN '" + dateNBD + "' AND '" + dateNKT + "'";
                    command = new SqlCommand(query, mydb.getConnection);
                    command.Parameters.Add("@lx", SqlDbType.NVarChar).Value = "Rửa Xe";
                }
                else if (radioButtonCoiXe.Checked == true)
                {
                    query = "SELECT * FROM THO WHERE nhomTho=@lx AND ngaySinh BETWEEN '" + dateNBD + "' AND '" + dateNKT + "'";
                    command = new SqlCommand(query, mydb.getConnection);
                    command.Parameters.Add("@lx", SqlDbType.NVarChar).Value = "Trông coi xe";
                }
                fillGrid(command);
            }
            else if (radioButtonNo.Checked == true)
            {
                if (radioButtonAll.Checked == true)
                {
                    query = "SELECT * FROM THO ";
                    command = new SqlCommand(query, mydb.getConnection);
                }
                else if (radioButtonSuaXe.Checked == true)
                {
                    query = "SELECT * FROM THO WHERE nhomTho=@xd";
                    command = new SqlCommand(query, mydb.getConnection);
                    command.Parameters.Add("@xd", SqlDbType.NVarChar).Value = "Sửa Xe";
                }
                else if (radioButtonRuaXe.Checked == true)
                {
                    query = "SELECT * FROM THO WHERE nhomTho=@xd";
                    command = new SqlCommand(query, mydb.getConnection);
                    command.Parameters.Add("@xd", SqlDbType.NVarChar).Value = "Rửa Xe";
                }
                else if (radioButtonCoiXe.Checked == true)
                {
                    query = "SELECT * FROM THO WHERE nhomTho=@xd";
                    command = new SqlCommand(query, mydb.getConnection);
                    command.Parameters.Add("@xd", SqlDbType.NVarChar).Value = "Coi Xe";
                }
                fillGrid(command);
            }
        }

        private void radioButtonSuaXe_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButtonCoiXe_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButtonAll_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM THO ");
            fillGrid(command);
        }
    }
}
