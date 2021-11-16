using LiveCharts;
using LiveCharts.Wpf;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLXe
{
    public partial class ThongKeCongViecForm : Form
    {
        public ThongKeCongViecForm()
        {
            InitializeComponent();
        
        }
        CONGVIEC congViec = new CONGVIEC();

        Func<ChartPoint, string> labelPoint = chartpoint => string.Format("{0} ({1:P})", chartpoint.Y, chartpoint.Participation);
        private void ThongKeCongViecForm_Load(object sender, EventArgs e)
        {
            labelNgay.Text = Convert.ToString(DateTime.Now);
            double dtSua = congViec.dtSuaXeNgay();
            double dtRua = congViec.dtRuaXeNgay();
            double dtCoi = congViec.dtCoiXeNgay();
            labelDtSua.Text ="Sửa Xe: " + dtSua;
            labelDtRua.Text ="Rửa Xe: " + dtRua;
            labelDtCoi.Text ="Trông Xe: " + dtCoi;
            labelTongDt.Text = "Tổng Cộng: " + (dtSua + dtRua + dtCoi);


            LiveCharts.SeriesCollection series = new LiveCharts.SeriesCollection();
            series.Add(new PieSeries() { Title = "Doanh Thu Sửa Xe", Values = new ChartValues<double> { dtSua }, DataLabels = true, LabelPoint = labelPoint });
            series.Add(new PieSeries() { Title = "Doanh Thu Rửa Xe", Values = new ChartValues<double> { dtRua }, DataLabels = true, LabelPoint = labelPoint });
            series.Add(new PieSeries() { Title = "Doanh Thu Trông Xe", Values = new ChartValues<double> { dtCoi }, DataLabels = true, LabelPoint = labelPoint });

            pieChart1.Series = series;

            pieChart1.LegendLocation = LegendLocation.Bottom;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public void exportDataToWord(string ngay, string sua, string rua, string coi, string sum, string fileName)
        {
            Document oDoc = new Document();
            oDoc.Application.Visible = true;
            oDoc.PageSetup.Orientation = WdOrientation.wdOrientLandscape;
            Object oMissing = System.Reflection.Missing.Value;
            string oTemp;
            oTemp = "DOANH THU " + ngay + "\n" + sua + "\n" + rua + "\n" + coi + "\n" + sum;
            var oPara1 = oDoc.Content.Paragraphs.Add(ref oMissing);
            oPara1.Range.Text = oTemp;
            oPara1.Range.InsertParagraphAfter();
            oDoc.SaveAs2(fileName);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.DefaultExt = "*.docx";
            saveFile.Filter = "DOCX files(*.docx|*.docx";
            if (saveFile.ShowDialog() == DialogResult.OK && saveFile.FileName.Length > 0)
            {
                exportDataToWord(labelNgay.Text, labelDtSua.Text, labelDtRua.Text, labelDtCoi.Text, labelTongDt.Text, saveFile.FileName);
                MessageBox.Show("File saved!", "Message Dialog", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
