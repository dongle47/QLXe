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
    public partial class TongDoanhThuNgay : Form
    {
        public TongDoanhThuNgay()
        {
            InitializeComponent();
        }
        XE xe = new XE();
        CONGVIEC congViec = new CONGVIEC();
        HDChoThue hdChoThue = new HDChoThue();
        HDThue hdThue = new HDThue();
        Func<ChartPoint, string> labelPoint = chartpoint => string.Format("{0} ({1:P})", chartpoint.Y, chartpoint.Participation);
        
        private void TongDoanhThuNgay_Load(object sender, EventArgs e)
        {
            labelNgay.Text = Convert.ToString(DateTime.Now);

            int dtXeDap = xe.doanhThuXeDap();
            int dtXeMay = xe.doanhThuXeMay();
            int dtXeHoi = xe.doanhThuXeHoi();
            labelXeDap.Text = "Xe Đạp: " + dtXeDap;
            labelXeMay.Text = "Xe Máy: " + dtXeMay;
            labelXeHoi.Text = "Xe Hơi: " + dtXeHoi;
            int sumXe = dtXeDap + dtXeMay + dtXeHoi;
            labelTongDtXe.Text = "Tổng Cộng: " + sumXe;

            int dtSua = congViec.dtSuaXeNgay();
            int dtRua = congViec.dtRuaXeNgay();
            int dtCoi = congViec.dtCoiXeNgay();
            labelDtSua.Text = "Sửa Xe: " + dtSua;
            labelDtRua.Text = "Rửa Xe: " + dtRua;
            labelDtCoi.Text = "Trông Xe: " + dtCoi;
            int sumDV = dtSua + dtRua + dtCoi;
            labelTongDtDV.Text = "Tổng Cộng: " + sumDV;

            int dtChoThue = hdChoThue.dtNgay();
            int dtThue = hdThue.dtNgay();
            labelChoThue.Text = "Cho Thuê: " + dtChoThue;
            labelThue.Text = "Ký Gửi: -" + dtThue;
            int sumHD = dtChoThue - dtThue;
            labelTongDtHD.Text = "Tổng Cộng: " + sumHD;


            int tongDT = sumXe + sumDV + sumHD;
            labelTongDT.Text = "TỔNG DOANH THU: " + tongDT;

            LiveCharts.SeriesCollection series = new LiveCharts.SeriesCollection();
            series.Add(new PieSeries() { Title = "Khu Vực Gửi Xe", Values = new ChartValues<double> { sumXe }, DataLabels = true, LabelPoint = labelPoint });
            series.Add(new PieSeries() { Title = "Khu Vực Sửa Chữa Và Chăm Sóc", Values = new ChartValues<double> { sumDV }, DataLabels = true, LabelPoint = labelPoint });
            series.Add(new PieSeries() { Title = "Khu Vực Cho Thuê Xe", Values = new ChartValues<double> { sumHD }, DataLabels = true, LabelPoint = labelPoint });

            pieChart1.Series = series;

            pieChart1.LegendLocation = LegendLocation.Bottom;
        }

        public void exportDataToWord(string ngay, string kvXe, string xeDap, string xeMay,
            string xeHoi, string sumXe, string kvDV, string suaXe, string ruaXe,
            string coiXe, string sumDV, string kvHD, string choThue, string thue, string sumHD,
            string tongDT, string fileName)
        {
            Document oDoc = new Document();
            oDoc.Application.Visible = true;
            oDoc.PageSetup.Orientation = WdOrientation.wdOrientLandscape;
            Object oMissing = System.Reflection.Missing.Value;
            string oTemp;
            oTemp = "DOANH THU " + ngay + "\n" + "\t" + kvXe + "\n" + xeDap + "\n" + xeMay + "\n"
                + xeHoi + "\n" + sumXe + "\n\n\t" + kvDV + "\n" + suaXe + "\n" + ruaXe + "\n" + coiXe + "\n" + sumDV + "\n\n\t" +
                kvHD + "\n" + choThue + "\n" + thue + "\n" + sumHD + "\n\n\n\t\t" + tongDT;
            var oPara1 = oDoc.Content.Paragraphs.Add(ref oMissing);
            oPara1.Range.Text = oTemp;
            oPara1.Range.InsertParagraphAfter();
            var oPara2 = oDoc.Content.Paragraphs.Add(ref oMissing);
            oPara2.Range.Paste();
            oPara2.Range.InsertParagraphAfter();
            oDoc.SaveAs2(fileName);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.DefaultExt = "*.docx";
            saveFile.Filter = "DOCX files(*.docx|*.docx";
            if (saveFile.ShowDialog() == DialogResult.OK && saveFile.FileName.Length > 0)
            {
                exportDataToWord(labelNgay.Text, labelKvXe.Text, labelXeDap.Text, labelXeMay.Text, labelXeHoi.Text,
                labelTongDtXe.Text, labelKvDV.Text, labelDtSua.Text, labelDtRua.Text, labelDtCoi.Text,
                labelTongDtDV.Text, labelKvHD.Text, labelChoThue.Text, labelThue.Text, labelTongDtHD.Text, labelTongDT.Text,saveFile.FileName);
                MessageBox.Show("File saved!", "Message Dialog", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
