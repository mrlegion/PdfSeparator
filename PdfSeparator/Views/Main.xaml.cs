using System;
using System.Collections.Generic;
using System.IO;
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
using PdfSeparator.ViewModels;

namespace PdfSeparator.Views
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        // ViewModel
        private MainViewModel _vm;

        public Main()
        {
            _vm = new MainViewModel();
            InitializeComponent();
            DataContext = _vm;
        }

        // ToDo: Нужно сделать по другому! Слишком много костылей

        private void DragEnterHandler(object sender, DragEventArgs e)
        {
            _vm.IsDrop = true;
            e.Effects = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Copy : DragDropEffects.None;
        }

        private void DragLeaveHandler(object sender, DragEventArgs e)
        {
            _vm.IsDrop = false;
        }

        private void DropEventHandler(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var dragFileList = ((DataObject)e.Data).GetFileDropList().Cast<string>().ToList();

                if (dragFileList.Any(s => s.EndsWith(".pdf") && File.Exists(s)))
                {
                    _vm.Init(dragFileList.First());
                    return;
                }
            }

            MessageBox.Show("Select incorrect file! Please, select only PDF File", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            _vm.IsDrop = false;
        }
    }
}
