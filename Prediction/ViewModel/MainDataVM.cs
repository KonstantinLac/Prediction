using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prediction.Model;
using System.Windows;
using Microsoft.Office.Interop.Excel;
using LiveCharts.Wpf;
using System.Windows.Controls;

namespace Prediction.ViewModel
{
    class MainDataVM
    {
        public static double[] arr_data { get; set; }

        public static void StartWorkData(CartesianChart cc, DataGrid dg)
        {
            MainData main_data = new MainData();
            Drawer pen = new Drawer(cc);
            OpenFileDialog ofd = new OpenFileDialog();

            string path = "";

            if (ofd.ShowDialog() == true)
            {
                path = ofd.FileName;
            }
            main_data.Load_TXT(path);
            double[] arr_mainData = main_data.GetData();
            if (arr_mainData != null)
            {
                arr_data = arr_mainData;
                pen.DrawLinerChart(arr_mainData, "Основные данные");

                List<DataM> datato_table = new List<DataM>();

                int length = arr_mainData.Length;
                for (int i = 0; i < length; i++)
                {
                    datato_table.Add(new DataM { t = i, x = arr_mainData[i] });
                }

                
                dg.ItemsSource = datato_table;
            }
           
        }

        public static void StartWorkDataXls(CartesianChart cc, DataGrid dg)
        {
            MainData main_data = new MainData();
            Drawer pen = new Drawer(cc);
            OpenFileDialog ofd = new OpenFileDialog();
            string path = "";

            if (ofd.ShowDialog() == true)
            {
                path = ofd.FileName;
            }
            main_data.Load_XLS(path);
            double[] arr_mainData = main_data.GetData();
            if (arr_mainData !=null )
            {
                arr_data = arr_mainData;
                pen.DrawLinerChart(arr_mainData, "Основные данные");

                List<DataM> datato_table = new List<DataM>();

                int length = arr_mainData.Length;
                for (int i = 0; i < length; i++)
                {
                    datato_table.Add(new DataM { t = i, x = arr_mainData[i] });
                }


                dg.ItemsSource = datato_table;

            }
            
        }
    }
}
