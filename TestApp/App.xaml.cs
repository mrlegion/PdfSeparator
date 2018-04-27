using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace TestApp
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnStartUp(object sender, StartupEventArgs e)
        {
            bool showForm = true;
            MainWindow window = new MainWindow();

            for (int i = 0; i != e.Args.Length; i++)
            {
                if (e.Args[i].EndsWith(".txt"))
                {
                    showForm = false;
                    if (MessageBox.Show("TXT File find. You need statr form?", "Title", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        showForm = true;
                        window.Show();
                        return;
                    }
                }
            }
            if (showForm)
                window.Show();
            else window.Close();
        }
    }
}
