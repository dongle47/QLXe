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
    public partial class DanhSachCongViecXe : Form
    {
        public DanhSachCongViecXe()
        {
            InitializeComponent();
        }
        MyDB mydb = new MyDB();
        public void fillGrid(SqlCommand command)
        {
            dataGridView1.ReadOnly = true;
            DataGridViewImageColumn picCol1 = new DataGridViewImageColumn();
            DataGridViewImageColumn picCol2 = new DataGridViewImageColumn();
            dataGridView1.RowTemplate.Height = 80;


            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);


            dataGridView1.DataSource = table;
            picCol1 = (DataGridViewImageColumn)dataGridView1.Columns[2];
            picCol1.ImageLayout = DataGridViewImageCellLayout.Stretch;

            dataGridView1.AllowUserToAddRows = false;
        }
        private void DanhSachCongViecXe_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(labelIdXe.Text);
            SqlCommand command = new SqlCommand("SELECT CONGVIEC.loaiCongViec, CONGVIEC.tenTho, CONGVIEC.hinhTho," +
                "CONGVIEC.ngayBatDau, CONGVIEC.ngayKetThuc FROM CONGVIEC INNER JOIN XE on CONGVIEC.idXe=XE.id WHERE XE.id="+id);
            fillGrid(command);
        }
    }
}
