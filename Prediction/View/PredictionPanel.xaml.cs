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
using System.Windows.Navigation;
using System.Windows.Shapes;
using LiveCharts;
using LiveCharts.Wpf;
using Prediction.ViewModel;
namespace Prediction.View
{
    /// <summary>
    /// Логика взаимодействия для PredictionPanel.xaml
    /// </summary>
    public partial class PredictionPanel : UserControl
    {
        public PredictionPanel()
        {
            InitializeComponent();
            predictionChart.Zoom = ZoomingOptions.X;
            predictionChart.DisableAnimations = false;
            predictionChart.Hoverable = false;
            predictionColumn.Zoom = ZoomingOptions.X;
            predictionColumn.DisableAnimations = false;
            predictionColumn.Hoverable = false;
        }


        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (predictionChart.Series.Count == 0)
            {
                PredictionVM.DrawMainData(predictionChart, predictionColumn, MainDataVM.arr_data);
            }
            
        }

        private void TriggerColumn_Click(object sender, RoutedEventArgs e)
        {
            if (triggerColumn.IsChecked == true)
            {
                PredictionVM.ReDrawColumn(predictionColumn, false);
            }
            else if (triggerColumn.IsChecked == false)
            {
                PredictionVM.ReDrawColumn(predictionColumn);
            }
        }

        int tickclick = 0;
        int x = 0;
        int y = 0;
        private void PredictionChart_DataClick(object sender, ChartPoint chartPoint)
        {
            tickclick++;
            if (tickclick == 3)
            {
                tickclick = 0;
                predictionChart.AxisX.Clear();
                x = 0;
                y = 0;

                from.Text = x.ToString();
                to.Text = y.ToString();

                return;
            }

            if (tickclick == 1)
            {
                x = Convert.ToInt32(chartPoint.X);
            }

            if (x != 0 && x != y && tickclick == 2)
            {
                y = Convert.ToInt32(chartPoint.X);
            }

            from.Text = x.ToString();
            to.Text = y.ToString();
            if (x != 0 && y != 0)
            {

                SectionsCollection Sections = new SectionsCollection
                    {
                    new AxisSection
                    {

                        Value = Convert.ToInt32(from.Text),
                        SectionWidth = Convert.ToInt32(to.Text) - Convert.ToInt32(from.Text),
                        Fill = new System.Windows.Media.SolidColorBrush
                        {
                            Color = System.Windows.Media.Color.FromRgb(254,132,132),
                            Opacity = .4
                        }
                    }
                    };

                Axis a = new Axis();
                a.MaxValue = MainDataVM.arr_data.Length;
                a.MinValue = 0;
                a.Sections = Sections;
                predictionChart.AxisX.Clear();
                predictionChart.AxisX.Add(a);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (typePrediction.Text == "Полигармонический")
            {
                if (from.Text != "" && to.Text != "" || from.Text == "0" && to.Text == "0")
                {
                    PredictionVM.GetAnaliticsPoly(predictionChart, outDG, MainDataVM.arr_data, Convert.ToInt32(from.Text), Convert.ToInt32(to.Text));
                }
                else
                {
                    PredictionVM.GetAnaliticsPoly(predictionChart, outDG, MainDataVM.arr_data, 0, MainDataVM.arr_data.Length - 1);
                }
            }
            else if (typePrediction.Text == "Экспоненциальный")
            {
                if (from.Text != "" && to.Text != "")
                {
                    PredictionVM.GetAnaliticsExp(predictionChart, outDG, MainDataVM.arr_data, Convert.ToInt32(from.Text), Convert.ToInt32(to.Text),Convert.ToDouble(need_error.Text));
                }
                else
                {
                    PredictionVM.GetAnaliticsExp(predictionChart, outDG, MainDataVM.arr_data, 0, MainDataVM.arr_data.Length - 1, Convert.ToDouble(need_error.Text));
                }
            }
            else if (typePrediction.Text == "Скользящее среднее")
            {
                if (from.Text != "" && to.Text != "")
                {
                    PredictionVM.GetAnaliticsMidle(predictionChart, outDG, MainDataVM.arr_data, Convert.ToInt32(from.Text), Convert.ToInt32(to.Text),0);
                }
                else
                {
                    PredictionVM.GetAnaliticsMidle(predictionChart, outDG, MainDataVM.arr_data, 0, MainDataVM.arr_data.Length - 1,0);
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    (window as MainWindow).output.IsEnabled = true;
                }
            }
            if (number.Text == "" || number.Text == "0")
            {
                MessageBox.Show("Не введена длина прогноза.");
                return;
            }
            if (typePrediction.Text == "Полигармонический")
            {
                if (from.Text != "" && to.Text != "" || from.Text == "0" && to.Text == "0")
                {
                    PredictionVM.GetPredictionPoly(predictionChart, MainDataVM.arr_data, Convert.ToInt32(from.Text), Convert.ToInt32(to.Text), Convert.ToInt32( number.Text));
                }
                else
                {
                    PredictionVM.GetPredictionPoly(predictionChart, MainDataVM.arr_data, 0, MainDataVM.arr_data.Length - 1, Convert.ToInt32(number.Text));
                }
            }
            else if (typePrediction.Text == "Экспоненциальный")
            {
                if (from.Text != "" && to.Text != "")
                {
                    PredictionVM.GetPredictionExp(predictionChart, MainDataVM.arr_data, Convert.ToInt32(from.Text), PredictionVM.arr_analitics, Convert.ToInt32(number.Text));
                }
                else
                {
                    PredictionVM.GetPredictionExp(predictionChart, MainDataVM.arr_data, 0, PredictionVM.arr_analitics, Convert.ToInt32(number.Text));
                }
            }
            else if (typePrediction.Text == "Скользящее среднее")
            {
                if (from.Text != "" && to.Text != "")
                {
                    PredictionVM.GetAnaliticsMidle(predictionChart, outDG, MainDataVM.arr_data, Convert.ToInt32(from.Text), Convert.ToInt32(to.Text), Convert.ToInt32(number.Text));
                }
                else
                {
                    PredictionVM.GetAnaliticsMidle(predictionChart, outDG, MainDataVM.arr_data, 0, MainDataVM.arr_data.Length - 1, Convert.ToInt32(number.Text));
                }
            }
        }

        private void TypePrediction_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (typePrediction.SelectedIndex == 1)
            {
                need_error.IsEnabled = true;
            }
            else
            {
                need_error.IsEnabled = false;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Disintegreated dis = new Disintegreated(MainDataVM.arr_data);
            dis.Show();
        }
    }
}
