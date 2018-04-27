using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Windows;
using MVVMBase;

namespace PdfSeparator.ViewModels
{
    public class MainViewModel : BindableBase
    {
        /// <summary>
        /// Родительский каталог выбранной директории
        /// </summary>
        private string _parent;

        private string _fileOutPath;

        public DelegateCommand<object> CloseWindowCommand { get; }

        public DelegateCommand BrowseCommand { get; }

        public string FileOutPath
        {
            get => _fileOutPath;
            set
            {
                _fileOutPath = File.Exists(value) ? value : throw new FileNotFoundException();
                OnPropertyChanged(nameof(FileOutPath));
            }
        }

        public MainViewModel()
        {
            BrowseCommand = new DelegateCommand(() =>
            {
                // Инициализация домашнего пути. если требуется
                // Так же это можно делать в конструкторе
                _parent = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);

                CommonOpenFileDialog dialog = new CommonOpenFileDialog()
                {
                    Multiselect = false,
                    InitialDirectory = _parent,
                    AllowNonFileSystemItems = true,
                    Filters = { new CommonFileDialogFilter("Файл формата pdf", "pdf") },
                    Title = "Выберете файл формата PDF, который необходимо разделить",
                    IsFolderPicker = false
                };

                if (dialog?.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    _parent = Path.GetDirectoryName(dialog.FileName);
                    FileOutPath = dialog.FileName;
                }
            });
            CloseWindowCommand = new DelegateCommand<object>(obj => { if (obj is Window window) window.Close(); });
        }
    }
}