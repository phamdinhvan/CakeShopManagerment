using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using LiveCharts;
using LiveCharts.Wpf;

namespace CakeShop
{
    /// <summary>
    /// Interaction logic for Statics.xaml
    /// </summary>
    public partial class Statics : Window
    {
        public Statics()
        {
            InitializeComponent();
            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Thu nhập",
                    Values = new ChartValues<double> { 40, 50, 69, 50, 70, 100, 120, 100, 67, 73, 44, 64 }
                }
            };

            Labels = new[] { "Tháng1", "Tháng2", "Tháng3", "Tháng4", "Tháng5", "Tháng6", "Tháng7", "Tháng8", "Tháng9", "Tháng10", "Tháng11", "Tháng12" };
            Formatter = value => value.ToString("N");


            DataContext = this;
        }
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }

        public SeriesCollection Data => new SeriesCollection()
        {
            new PieSeries()
            {
                Values = new ChartValues<float> {420 } , Title = "Bánh Mì"
            },
            new PieSeries()
            {
                Values = new ChartValues<float> {300} , Title = "Bánh ngọt"
            },
            new PieSeries()
            {
                Values = new ChartValues<float> {100 } , Title = "Bánh kem nhỏ",
            },
            new PieSeries()
            {
                Values = new ChartValues<float> {350 } , Title = "Bánh kem",
            }
        };       
        private void PieChart_DataClick(object sender, LiveCharts.ChartPoint chartPoint)
        {
            var chart1 = chartPoint.ChartView as PieChart;
            foreach (PieSeries pie in chart1.Series)
            {
                pie.PushOut = 0;
            }

            var neo = chartPoint.SeriesView as PieSeries;
            neo.PushOut = 30;
        }
    }
}
