using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
//using PlatformDesktop.Charts;

namespace PlatformDesktop
{
    /// <summary>
    /// Логика взаимодействия для TelemetryWindow.xaml
    /// </summary>
    public partial class TelemetryWindow : Window
    {

        public TelemetryWindow(double[] x, double[] y, double[] z, double[] xA, double[] yA, double[] zA, double[] xM, double[] yM, double[] zM, double[] Lcurr, double[] Rcurr, double[] vbat)
        {
            InitializeComponent();
            var Ser = (this.DataContext as TelemetryViewModel).Series;
            Ser.Add(new LineSeries
            {
                Title = "X",
                Values = new ChartValues<double>(x)
            });
            Ser.Add(new LineSeries
            {
                Title = "Y",
                Values = new ChartValues<double>(y)
            });
            Ser.Add(new LineSeries
            {
                Title = "Z",
                Values = new ChartValues<double>(z)
            });


            var SerA = (this.DataContext as TelemetryViewModel).SeriesA;
            SerA.Add(new LineSeries
            {
                Title = "X",
                Values = new ChartValues<double>(xA)
            });
            SerA.Add(new LineSeries
            {
                Title = "Y",
                Values = new ChartValues<double>(yA)
            });
            SerA.Add(new LineSeries
            {
                Title = "Z",
                Values = new ChartValues<double>(zA)
            });


            var SerM = (this.DataContext as TelemetryViewModel).SeriesM;
            SerM.Add(new LineSeries
            {
                Title = "X",
                Values = new ChartValues<double>(xM)
            });
            SerM.Add(new LineSeries
            {
                Title = "Y",
                Values = new ChartValues<double>(yM)
            });
            SerM.Add(new LineSeries
            {
                Title = "Z",
                Values = new ChartValues<double>(zM)
            });

            var SerCurr = (this.DataContext as TelemetryViewModel).SeriesCurr;
            SerCurr.Add(new LineSeries
            {
                Title = "LeftCurr",
                Values = new ChartValues<double>(Lcurr)
            });
            SerCurr.Add(new LineSeries
            {
                Title = "RightCurr",
                Values = new ChartValues<double>(Rcurr)
            });
            var SerV = (this.DataContext as TelemetryViewModel).SeriesV;
            SerV.Add(new ColumnSeries
            {
                Title = "Battery",
                Values = new ChartValues<double>(vbat)
            });

        }
        public void AddValueSeries(SeriesType st, double value)
        {
            (this.DataContext as TelemetryViewModel).AddValueSeries(st, value);
        }
        public void AddValueSeriesA(SeriesType stA, double value)
        {
            (this.DataContext as TelemetryViewModel).AddValueSeriesA(stA, value);
        }
        public void AddValueSeriesM(SeriesType stM, double value)
        {
            (this.DataContext as TelemetryViewModel).AddValueSeriesM(stM, value);
        }
        public void AddValueSeriesCurr(SeriesType stCurr, double value)
        {
            (this.DataContext as TelemetryViewModel).AddValueSeriesCurr(stCurr, value);
        }
        public void AddValueSeriesV(SeriesType stV, double value)
        {
            (this.DataContext as TelemetryViewModel).AddValueSeriesV(stV, value);
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

       
    }
}

