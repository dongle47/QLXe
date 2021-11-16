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

namespace QLXe.Tho
{
    public partial class ThongKeThoForm : Form
    {
        public ThongKeThoForm()
        {
            InitializeComponent();
        }
        ThoClass thoClass = new ThoClass();

        Func<ChartPoint, string> labelPoint = chartpoint => string.Format("{0} ({1:P})", chartpoint.Y, chartpoint.Participation);

        private void ThongKeThoForm_Load(object sender, EventArgs e)
        {
            int suaXe = thoClass.totalThoSuaXe();
            int ruaXe = thoClass.totalThoRuaXe();
            int trongCoiXe = thoClass.totalThoCoiXe();

            labelCoiXe.Text = "Tổng thợ coi xe: " + trongCoiXe;
            labelRuaXe.Text = "Tổng thợ rửa xe: " + ruaXe;
            labelSuaXe.Text = "Tổng thợ sửa xe: " + suaXe;


            LiveCharts.SeriesCollection series = new LiveCharts.SeriesCollection();
            series.Add(new PieSeries() { Title = "Thợ sửa xe", Values = new ChartValues<double> { suaXe }, DataLabels = true, LabelPoint = labelPoint });
            series.Add(new PieSeries() { Title = "Thợ rửa xe", Values = new ChartValues<double> { ruaXe }, DataLabels = true, LabelPoint = labelPoint });
            series.Add(new PieSeries() { Title = "Thợ trông coi xe", Values = new ChartValues<double> { trongCoiXe }, DataLabels = true, LabelPoint = labelPoint });

            pieChart1.Series = series;

            pieChart1.LegendLocation = LegendLocation.Bottom;

        }
     
        private void buttonSave_Click(object sender, EventArgs e)
        {

        }
    }
}
