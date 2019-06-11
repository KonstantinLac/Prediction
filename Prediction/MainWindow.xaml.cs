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
using System.Windows.Media.Animation;
using Prediction.View;

namespace Prediction
{
   
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DownloadData maindata_panel;
        PredictionPanel prediction_panel;
        AnaliticsPanel analitics_panel;
        OutputePanel out_panel;

        public MainWindow()
        {
            InitializeComponent();
            out_panel        = new OutputePanel();
            maindata_panel   = new DownloadData();
            analitics_panel  = new AnaliticsPanel();
            prediction_panel = new PredictionPanel();
            //toolTipDate.Content = "Основная информация о программе\nНа: " + DateTime.Now.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            mainPanel.Content = maindata_panel;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            mainPanel.Content = prediction_panel;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            mainPanel.Content = analitics_panel;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            mainPanel.Content = out_panel;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            mainPanel.Content = maindata_panel;
        }

        private void PackIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
           
            //180 49
            if (leftPanel.Width == 49)
            {
                ThicknessAnimation ta = new ThicknessAnimation();
                ThicknessAnimation ta2 = new ThicknessAnimation();

                ta.From = new Thickness(49, 0, 0, 0);
                ta.To = new Thickness(180, 0, 0, 0);
                ta.Duration = TimeSpan.FromSeconds(0.3);
                ta2.From = new Thickness(49, 33, 0, 0);
                ta2.To = new Thickness(180, 33, 0, 0);
                ta2.Duration = TimeSpan.FromSeconds(0.3);

                DoubleAnimation buttonAnimation = new DoubleAnimation();
                buttonAnimation.From = leftPanel.ActualWidth;
                buttonAnimation.To = 180;
                buttonAnimation.Duration = TimeSpan.FromSeconds(0.3);
                leftPanel.BeginAnimation(WidthProperty, buttonAnimation);
                //leftDownPanel.BeginAnimation(WidthProperty, buttonAnimation);
                upPanel.BeginAnimation(MarginProperty, ta);
                mainPanel.BeginAnimation(MarginProperty, ta2);
                //upPanel.Margin = new Thickness(180,0,0,0);
                //mainPanel.Margin = new Thickness(180, 33, 0, 0);
            }
            else if (leftPanel.Width == 180)
            {
                ThicknessAnimation ta = new ThicknessAnimation();
                ThicknessAnimation ta2 = new ThicknessAnimation();

                ta.From = new Thickness(180, 0, 0, 0);
                ta.To = new Thickness(49, 0, 0, 0);
                ta.Duration = TimeSpan.FromSeconds(0.3);
                ta2.From = new Thickness(180, 33, 0, 0);
                ta2.To = new Thickness(49, 33, 0, 0);
                ta2.Duration = TimeSpan.FromSeconds(0.3);

                DoubleAnimation buttonAnimation = new DoubleAnimation();
                buttonAnimation.From = leftPanel.ActualWidth;
                buttonAnimation.To = 49;
                buttonAnimation.Duration = TimeSpan.FromSeconds(0.3);
                leftPanel.BeginAnimation(WidthProperty, buttonAnimation);
                //leftDownPanel.BeginAnimation(WidthProperty, buttonAnimation);
                upPanel.BeginAnimation(MarginProperty, ta);
                mainPanel.BeginAnimation(MarginProperty, ta2);
                //upPanel.Margin = new Thickness(49, 0, 0, 0);
                //mainPanel.Margin = new Thickness(49, 33, 0, 0);
            }

        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (leftPanel.Width == 49)
            {
                ThicknessAnimation ta = new ThicknessAnimation();
                ThicknessAnimation ta2 = new ThicknessAnimation();

                ta.From = new Thickness(49, 0, 0, 0);
                ta.To = new Thickness(180, 0, 0, 0);
                ta.Duration = TimeSpan.FromSeconds(0.3);
                ta2.From = new Thickness(49, 33, 0, 0);
                ta2.To = new Thickness(180, 33, 0, 0);
                ta2.Duration = TimeSpan.FromSeconds(0.3);

                DoubleAnimation buttonAnimation = new DoubleAnimation();
                buttonAnimation.From = leftPanel.ActualWidth;
                buttonAnimation.To = 180;
                buttonAnimation.Duration = TimeSpan.FromSeconds(0.3);
                leftPanel.BeginAnimation(WidthProperty, buttonAnimation);
                //leftDownPanel.BeginAnimation(WidthProperty, buttonAnimation);
                upPanel.BeginAnimation(MarginProperty, ta);
                mainPanel.BeginAnimation(MarginProperty, ta2);
                //upPanel.Margin = new Thickness(180, 0, 0, 0);
                //mainPanel.Margin = new Thickness(180, 33, 0, 0);
            }
            else if (leftPanel.Width == 180)
            {
                DoubleAnimation buttonAnimation = new DoubleAnimation();
                buttonAnimation.From = leftPanel.ActualWidth;
                buttonAnimation.To = 49;
                buttonAnimation.Duration = TimeSpan.FromSeconds(0.3);

                ThicknessAnimation ta = new ThicknessAnimation();
                ThicknessAnimation ta2 = new ThicknessAnimation();
               
                ta.From = new Thickness(180, 0, 0, 0);
                ta.To = new Thickness(49, 0, 0, 0);
                ta.Duration = TimeSpan.FromSeconds(0.3);
                ta2.From = new Thickness(180, 33, 0, 0);
                ta2.To = new Thickness(49, 33, 0, 0);
                ta2.Duration = TimeSpan.FromSeconds(0.3);
                leftPanel.BeginAnimation(WidthProperty, buttonAnimation);
                //leftDownPanel.BeginAnimation(WidthProperty, buttonAnimation);

                upPanel.BeginAnimation(MarginProperty,ta);
                mainPanel.BeginAnimation(MarginProperty, ta2);
                //upPanel.Margin = new Thickness(49, 0, 0, 0);
                //mainPanel.Margin = new Thickness(49, 33, 0, 0);
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Добро пожаловать!\nЗагрузите данные для того что бы начать работу.");
        }
    }
}
