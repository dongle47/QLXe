using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using LiveCharts;
using LiveCharts.Wpf;

namespace QLXe
{
    public partial class DanhSachXeForm : Form
    {
        public DanhSachXeForm()
        {
            InitializeComponent();
        }
        Func<ChartPoint, string> labelPoint = chartpoint => string.Format("{0} ({1:P})", chartpoint.Y, chartpoint.Participation);
        XE xe = new XE();
        MyDB mydb = new MyDB();
        private void dataGridViewList_DoubleClick(object sender, EventArgs e)
        {
            DanhSachCongViecXe f = new DanhSachCongViecXe();
            f.labelIdXe.Text = dataGridViewList.CurrentRow.Cells[0].Value.ToString();
            f.Show();
        }
        private void DanhSachXeForm_Load(object sender, EventArgs e)
        {
            radioButtonAll.Checked = true;
            radioButtonNo.Checked = true;
            SqlCommand command = new SqlCommand("SELECT * FROM XE ");
            fillGrid(command);

            int totalXeDap = Convert.ToInt32(xe.totalXeDap());
            int totalXeMay = Convert.ToInt32(xe.totalXeMay());
            int totalXeHoi = Convert.ToInt32(xe.totalXeHoi());

            SeriesCollection series = new SeriesCollection();
            series.Add(new PieSeries() { Title = "Số Xe Đạp", Values = new ChartValues<double> { totalXeDap }, DataLabels = true, LabelPoint = labelPoint });
            series.Add(new PieSeries() { Title = "Số Xe Máy", Values = new ChartValues<double> { totalXeMay }, DataLabels = true, LabelPoint = labelPoint });
            series.Add(new PieSeries() { Title = "Số Xe Hơi", Values = new ChartValues<double> { totalXeHoi }, DataLabels = true, LabelPoint = labelPoint });

            pieChart1.Series = series;

            pieChart1.LegendLocation = LegendLocation.Bottom;
        }
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("Select * from XE");
            fillGrid(command);
        }

        private void dataGridViewList_Click(object sender, EventArgs e)
        {
            labelId.Text = dataGridViewList.CurrentRow.Cells[0].Value.ToString();
            labelLoaiXe.Text = dataGridViewList.CurrentRow.Cells[1].Value.ToString();
            labelNgayKetThuc.Text = Convert.ToString(dataGridViewList.CurrentRow.Cells[9].Value);
            string guiTheo = dataGridViewList.CurrentRow.Cells[4].Value.ToString();
            DateTime tNow = DateTime.Now;
            DateTime ngKT = Convert.ToDateTime(labelNgayKetThuc.Text);
            int mucPhat = xe.MucPhat(labelLoaiXe.Text, guiTheo,ngKT, tNow);
            xe.updateMucPhat(Convert.ToInt32(labelId.Text), mucPhat);
        }

        private void pieChart1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32( textBoxID.Text);
            SqlCommand command = new SqlCommand("SELECT * FROM XE WHERE id=" +Id);
            fillGrid(command);

            int totalXeDap = Convert.ToInt32(xe.totalXeDap());
            int totalXeMay = Convert.ToInt32(xe.totalXeMay());
            int totalXeHoi = Convert.ToInt32(xe.totalXeHoi());

            SeriesCollection series = new SeriesCollection();
            series.Add(new PieSeries() { Title = "Số Xe Đạp", Values = new ChartValues<double> { totalXeDap }, DataLabels = true, LabelPoint = labelPoint });
            series.Add(new PieSeries() { Title = "Số Xe Máy", Values = new ChartValues<double> { totalXeMay }, DataLabels = true, LabelPoint = labelPoint });
            series.Add(new PieSeries() { Title = "Số Xe Hơi", Values = new ChartValues<double> { totalXeHoi }, DataLabels = true, LabelPoint = labelPoint });

            pieChart1.Series = series;

            pieChart1.LegendLocation = LegendLocation.Bottom;
        }
        public void fillGrid(SqlCommand command)
        {
            dataGridViewList.ReadOnly = true;
            dataGridViewList.RowTemplate.Height = 80;
            dataGridViewList.DataSource = xe.getXe(command);
            DataGridViewImageColumn picCol1 = new DataGridViewImageColumn();
            DataGridViewImageColumn picCol2 = new DataGridViewImageColumn();
            picCol1 = (DataGridViewImageColumn)dataGridViewList.Columns[2];
            picCol1.ImageLayout = DataGridViewImageCellLayout.Stretch;
            picCol2 = (DataGridViewImageColumn)dataGridViewList.Columns[3];
            picCol2.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridViewList.AllowUserToAddRows = false;
        }

        private void radioButtonAll_CheckedChanged(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM XE ");
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
            SqlCommand command = new SqlCommand("SELECT * FROM XE WHERE loaiXe=@xd", mydb.getConnection);
            command.Parameters.Add("@xd", SqlDbType.NVarChar).Value = "Xe Máy";
            fillGrid(command);
        }

        private void radioButtonSearchXeHoi_CheckedChanged(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM XE WHERE loaiXe=@xd", mydb.getConnection);
            command.Parameters.Add("@xd", SqlDbType.NVarChar).Value = "Xe Hơi";
            fillGrid(command);
        }

        private void dataGridViewList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
                else if (radioButtonSearchXeDap.Checked == true)
                {
                    query = "SELECT * FROM XE WHERE loaiXe=@lx AND ngayBatDau BETWEEN '" + dateNBD + "' AND '" + dateNKT + "'";
                    command = new SqlCommand(query, mydb.getConnection);
                    command.Parameters.Add("@lx", SqlDbType.NVarChar).Value = "Xe Đạp";
                }
                else if (radioButtonSearchXeMay.Checked == true)
                {
                    query = "SELECT * FROM XE WHERE loaiXe=@lx AND ngayBatDau BETWEEN '" + dateNBD + "' AND '" + dateNKT + "'";
                    command = new SqlCommand(query, mydb.getConnection);
                    command.Parameters.Add("@lx", SqlDbType.NVarChar).Value = "Xe Máy";
                }
                else if (radioButtonSearchXeHoi.Checked == true)
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
                else if (radioButtonSearchXeDap.Checked == true)
                {
                    query = "SELECT * FROM XE WHERE loaiXe=@xd";
                    command = new SqlCommand(query, mydb.getConnection);
                    command.Parameters.Add("@xd", SqlDbType.NVarChar).Value = "Xe Đạp";
                }
                else if (radioButtonSearchXeMay.Checked == true)
                {
                    query = "SELECT * FROM XE WHERE loaiXe=@xd";
                    command = new SqlCommand(query, mydb.getConnection);
                    command.Parameters.Add("@xd", SqlDbType.NVarChar).Value = "Xe Máy";
                }
                else if (radioButtonSearchXeHoi.Checked == true)
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
            dateTimePickerNBD.Enabled = true   ;
            dateTimePickerNKT.Enabled = true   ;
        }
    }
}
