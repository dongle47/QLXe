using LiveCharts;
using LiveCharts.Wpf;
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
    public partial class ThongKeHopDong : Form
    {
        HDChoThue hdChoThue = new HDChoThue();
        HDThue hdThue = new HDThue();
        public ThongKeHopDong()
        {
            InitializeComponent();
        }
        Func<ChartPoint, string> labelPoint = chartpoint => string.Format("{0} ({1:P})", chartpoint.Y, chartpoint.Participation);

        private void ThongKeHopDong_Load(object sender, EventArgs e)
        {
            labelNgay.Text = Convert.ToString(DateTime.Now);
            double dtChoThue = hdChoThue.dtNgay();
            double dtThue = hdThue.dtNgay();
            labelChoThue.Text = "Cho Thuê: " + dtChoThue;
            labelThue.Text = "Ký Gửi: -" + dtThue;
            labelTongDT.Text = "Tổng Cộng: " + (dtChoThue-dtThue);


            LiveCharts.SeriesCollection series = new LiveCharts.SeriesCollection();
            series.Add(new PieSeries() { Title = "Doanh Thu Cho Thuê: ", Values = new ChartValues<double> { dtChoThue }, DataLabels = true, LabelPoint = labelPoint });
            series.Add(new PieSeries() { Title = "Tiền Ký Gửi: ", Values = new ChartValues<double> { dtThue }, DataLabels = true, LabelPoint = labelPoint });

            pieChart1.Series = series;

            pieChart1.LegendLocation = LegendLocation.Bottom;
        }

        private void buttonToText_Click(object sender, EventArgs e)
        {

        }
    }
}
