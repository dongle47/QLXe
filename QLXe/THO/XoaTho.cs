using QLXe;
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

namespace QLXe
{
    public partial class XoaTho : Form
    {
        public XoaTho()
        {
            InitializeComponent();
        }
        ThoClass tho = new ThoClass();
        MyDB mydb = new MyDB();
        int thoID = 0;
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
        private void XoaTho_Load(object sender, EventArgs e)
        {
            radioButtonAll.Checked = true;
            radioButtonNo.Checked = true;
            SqlCommand command = new SqlCommand("SELECT * FROM THO ");
            fillGrid(command);
        }

        private void radioButtonAll_CheckedChanged(object sender, EventArgs e)
        {

            SqlCommand command = new SqlCommand("SELECT * FROM THO ");
            fillGrid(command);
        }

        private void radioButtonSuaXe_CheckedChanged(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM THO WHERE nhomTho=@xd", mydb.getConnection);
            command.Parameters.Add("@xd", SqlDbType.NVarChar).Value = "Sửa Xe";
            fillGrid(command);
        }

        private void radioButtonRuaXe_CheckedChanged(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM THO WHERE nhomTho=@xd", mydb.getConnection);
            command.Parameters.Add("@xd", SqlDbType.NVarChar).Value = "Rửa Xe";
            fillGrid(command);
        }

        private void radioButtonCoiXe_CheckedChanged(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM THO WHERE nhomTho=@xd", mydb.getConnection);
            command.Parameters.Add("@xd", SqlDbType.NVarChar).Value = "Trông coi xe";
            fillGrid(command);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string id = txtSearch.Text;
            SqlCommand command = new SqlCommand("SELECT * FROM THO WHERE CONCAT(id,ten) LIKE '%" + txtSearch.Text + "%'");
            fillGrid(command);
        }

        private void btnRm_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("Are You Sure You Want To Delete This Worker", "Delete Worker", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                if (tho.deleteTho(thoID))
                {
                    MessageBox.Show("Worker Deleted", "Delete Worker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Worker Not Deleted", "Delete Worker", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            SqlCommand command = new SqlCommand("SELECT * FROM THO ");
            fillGrid(command);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            thoID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
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
    }
}
