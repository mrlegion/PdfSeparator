using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using PdfSeparator.Views;

namespace PdfSeparator
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnStartup(object sender, StartupEventArgs e)
        {
            // TODO: Описать обход запуска приложения без запуска оболочки
            Views.Main main = new Main();
            main.Show();
        }
    }
}
