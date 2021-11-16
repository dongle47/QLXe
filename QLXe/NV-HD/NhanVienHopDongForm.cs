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
    public partial class NhanVienHopDongForm : Form
    {
        public NhanVienHopDongForm()
        {
            InitializeComponent();
        }
        MyDB mydb = new MyDB();
        HDChoThue hdChoThue = new HDChoThue();
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            
            AddContractForm f = new AddContractForm();
            f.ShowDialog();
        }
 
        public void getImageAndUsername()
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            SqlCommand command = new SqlCommand("SELECT * FROM NV WHERE id=@id", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = Globals.globalUserId;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                byte[] pic = (byte[])table.Rows[0]["hinhAnh"];
                MemoryStream picture = new MemoryStream(pic);
                pictureBox1.Image = Image.FromStream(picture);
                labelWelcome.Text = "Welcome Back (" + table.Rows[0][1].ToString() + ")";
            }
        }
        private void NhanVienHopDongForm_Load(object sender, EventArgs e)
        {
            //SqlDataAdapter adapter = new SqlDataAdapter();
            //DataTable table = new DataTable();
            //SqlCommand command = new SqlCommand("SELECT * FROM NV WHERE id=@id", mydb.getConnection);
            //command.Parameters.Add("@id", SqlDbType.Int).Value = Globals.globalUserId;
            //adapter.SelectCommand = command;
            //adapter.Fill(table);
            //if (table.Rows.Count > 0)
            //{
            //    labelTenNV.Text = table.Rows[0][1].ToString() ;
            //}
            getImageAndUsername();
        }
        private void labelRefresh_Click(object sender, EventArgs e)
        {
            getImageAndUsername();
        }

        private void labelEditInfo_Click(object sender, EventArgs e)
        {
            EditMyInfoForm f = new EditMyInfoForm();
            f.ShowDialog();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            EditContractForm f = new EditContractForm();
            f.Show();
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            RemoveContract f = new RemoveContract();
            f.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowListContract f = new ShowListContract();
            f.Show();
        }
    }
}
