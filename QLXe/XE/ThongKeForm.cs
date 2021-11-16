using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;
using System.Data.SqlClient;
using LiveCharts;
using LiveCharts.Wpf;

namespace QLXe
{
    public partial class ThongKeForm : Form
    {
        public ThongKeForm()
        {
            InitializeComponent();
        }
        XE xe = new XE();
        Func<ChartPoint, string> labelPoint = chartpoint => string.Format("{0} ({1:P})", chartpoint.Y, chartpoint.Participation);
        public void exportDataToWord(string ngay, string xd, string xm, string xh, string sum, string fileName)
        {
            Document oDoc = new Document();
            oDoc.Application.Visible = true;
            oDoc.PageSetup.Orientation = WdOrientation.wdOrientLandscape;
            Object oMissing = System.Reflection.Missing.Value;
            string oTemp;
            oTemp= "DOANH THU " + ngay +"\n"+ xd +"\n"+ xm +"\n" + xh + "\n" + sum;
            var oPara1 = oDoc.Content.Paragraphs.Add(ref oMissing);
            oPara1.Range.Text = oTemp;
            oPara1.Range.InsertParagraphAfter();
            oDoc.SaveAs2(fileName);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.DefaultExt = "*.docx";
            saveFile.Filter = "DOCX files(*.docx|*.docx";
            if (saveFile.ShowDialog() == DialogResult.OK && saveFile.FileName.Length > 0)
            {
                exportDataToWord(labelNgay.Text, labelXeDap.Text, labelXeMay.Text, labelXeHoi.Text, labelTongDoanhThu.Text, saveFile.FileName);
                MessageBox.Show("File saved!", "Message Dialog", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ThongKeForm_Load(object sender, EventArgs e)
        {

            labelNgay.Text = Convert.ToString(DateTime.Now);
            int dtXeDap = xe.doanhThuXeDap();
            int dtXeMay = xe.doanhThuXeMay();
            int dtXeHoi = xe.doanhThuXeHoi();
            labelXeDap.Text = "Xe Đạp: "  + dtXeDap;
            labelXeMay.Text = "Xe Máy: " + dtXeMay;
            labelXeHoi.Text = "Xe Hơi: " + dtXeHoi;
            labelTongDoanhThu.Text = "Tổng Cộng: " + (dtXeDap+dtXeMay+dtXeHoi);


            LiveCharts.SeriesCollection series = new LiveCharts.SeriesCollection();
            series.Add(new PieSeries() { Title = "Doanh Thu Xe Đạp", Values = new ChartValues<double> { dtXeDap }, DataLabels = true, LabelPoint = labelPoint });
            series.Add(new PieSeries() { Title = "Doanh Thu Xe Máy", Values = new ChartValues<double> { dtXeMay }, DataLabels = true, LabelPoint = labelPoint });
            series.Add(new PieSeries() { Title = "Doanh Thu Xe Hơi", Values = new ChartValues<double> { dtXeHoi }, DataLabels = true, LabelPoint = labelPoint });

            pieChart1.Series = series;

            pieChart1.LegendLocation = LegendLocation.Bottom;
        }

    }
}
