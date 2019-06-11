using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Prediction.Model
{
    class Drawer
    {
        public CartesianChart Charts { get; set; }

        public Drawer(CartesianChart cartesianChart)
        {
            Charts = cartesianChart;
        }

        public void DrawLinerChart(double[] data, string title)
        {
            ChartValues<ObservablePoint> points = new ChartValues<ObservablePoint>();
            int length = data.Length;
            for (int i = 0; i < length; i++)
            {
                points.Add(new ObservablePoint(i,data[i]));
            }
            LineSeries line = new LineSeries();
            line.Values = points;
            line.Title = title;
            Charts.Series.Add(line);
        }

        public void DrawLinerChart(double[] data, int start, string title)
        {
            ChartValues<ObservablePoint> points = new ChartValues<ObservablePoint>();
            int length = data.Length;
            foreach (var item in data)
            {
                points.Add(new ObservablePoint(start, item));
                start++;
            }
            //for (int i = start; i < length; i++)
            //{
            //    points.Add(new ObservablePoint(i, data[i]));
            //}
            LineSeries line = new LineSeries();
            line.Values = points;
            line.Title = title;
            Charts.Series.Add(line);
        }

        public void DrawColumnChart(double[] data, string title)
        {
            try
            {
                ChartValues<double> values = new ChartValues<double>();
                int length = data.Length;
                for (int i = 0; i < length; i++)
                {
                    values.Add(data[i]);
                }

                ColumnSeries spector = new ColumnSeries();

                spector.Values = values;
                spector.Title = title;

                Charts.Series.Add(spector);
            }
            catch
            {
                MessageBox.Show("Данные еще не загружены. Вернитесь в раздел загрузки данных.");
            }
        }
    }
}
