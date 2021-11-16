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
    public partial class RemoveContract : Form
    {
        public RemoveContract()
        {
            InitializeComponent();
        }
        HDChoThue hdChoThue = new HDChoThue();
        HDThue hdThue = new HDThue();
        int nvId = Globals.globalUserId;
        int contractId;
        string hd;
        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (radioButtonChoThue.Checked == true)
            {
                if ((MessageBox.Show("Are You Sure You Want To Delete This Contract", "Delete Contract", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    if (hdChoThue.deleteContract(contractId, nvId))
                    {
                        MessageBox.Show("Contract Deleted", "Delete Contract", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Contract Not Deleted", "Delete Contract", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                SqlCommand command = new SqlCommand("SELECT id, hinhXe, bangSo, tenChuXe, hinhChuXe, " +
                "ngayBatDau, ngayKetThuc, tenNguoiThue, hinhNguoiThue FROM HDChoThue WHERE nv_id=" + nvId);
                fillGridChoThue(command);
            }
            else if (radioButtonThue.Checked == true)
            {
                if ((MessageBox.Show("Are You Sure You Want To Delete This Contract", "Delete Contract", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    if (hdThue.deleteContract(contractId, nvId))
                    {
                        MessageBox.Show("Contract Deleted", "Delete Contract", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Contract Not Deleted", "Delete Contract", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                SqlCommand command = new SqlCommand("SELECT id, hinhXe, bangSo, tenChuXe, hinhChuXe, " +
                "ngayBatDau, ngayKetThuc FROM HDThue WHERE nv_id=" + nvId);
                fillGridThue(command);
            }
        }
        private void RemoveContract_Load(object sender, EventArgs e)
        {
            radioButtonNo.Checked = true;
            radioButtonChoThue.Checked = true;
        }
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (radioButtonChoThue.Checked == true)
            {
                hd = "choThue";
            }
            else if (radioButtonThue.Checked == true)
            {
                hd = "thue";
            }
            contractId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
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

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            int contractId = Convert.ToInt32( textBoxSearch.Text);
            if (radioButtonChoThue.Checked == true)
            {
                SqlCommand command = new SqlCommand("SELECT * FROM HDChoThue WHERE CONCAT(id,tenChuXe) LIKE '%" + textBoxSearch.Text + "%'");
                fillGridChoThue(command);
            }
            else if(radioButtonThue.Checked==true)
            {
                SqlCommand command = new SqlCommand("SELECT * FROM HDChoThue WHERE CONCAT(id,tenChuXe) LIKE '%" + textBoxSearch.Text + "%'");
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
