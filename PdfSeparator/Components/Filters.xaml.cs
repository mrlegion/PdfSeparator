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

namespace PdfSeparator.Components
{
    /// <summary>
    /// Логика взаимодействия для Filters.xaml
    /// </summary>
    public partial class Filters : UserControl
    {
        public Filters()
        {
            InitializeComponent();

            var newfilter = new Grid()
            {
                ColumnDefinitions =
                {
                    new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) },
                }
            };

            var checkbox_1 = new CheckBox()
            {
                Content = "Print 1 + 1;",
                IsChecked = false,
            };
            var checkbox_2 = new CheckBox()
            {
                Content = "Print 1 + 0;",
                IsChecked = true,
            };
            var button = new Button()
            {
                Content = "Someone",
            };
        }
    }
}
