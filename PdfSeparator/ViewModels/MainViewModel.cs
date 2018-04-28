using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Windows;
using MVVMBase;
using PdfSeparator.Common;

namespace PdfSeparator.ViewModels
{
    public class MainViewModel : BindableBase
    {
        #region Fields

        /// <summary>
        /// Родительский каталог выбранной директории
        /// </summary>
        private string _parent;

        /// <summary>
        /// Путь до выбранного файла
        /// </summary>
        private string _fileOutPath;

        /// <summary>
        /// Колекция фильтров, которые необходимо применить к сортрировке
        /// </summary>
        private readonly ObservableCollection<FilterItem> _filters;

        #endregion

        #region Properties

        /// <summary>
        /// Получение или установка основного пути до файла
        /// </summary>
        public string FileOutPath
        {
            get => _fileOutPath;
            set
            {
                if (File.Exists(value)) SetProperty(ref _fileOutPath, value);
                else throw new FileNotFoundException();
            }
        }

        /// <summary>
        /// Получение колекции фильтров сортировки
        /// </summary>
        public ReadOnlyObservableCollection<FilterItem> Filters => new ReadOnlyObservableCollection<FilterItem>(_filters);

        #endregion

        #region Commands

        /// <summary>
        /// Получение команды добавления строки фильтров
        /// </summary>
        public DelegateCommand AddFilterCommand { get; }

        /// <summary>
        /// Получение команды для удаления строки фильтров
        /// </summary>
        public DelegateCommand<object> DeleteFilterCommand { get; }

        /// <summary>
        /// Получение команды для закрытия формы и приложения
        /// </summary>
        public DelegateCommand<object> CloseWindowCommand { get; }

        /// <summary>
        /// Получение команды для открытия диалогового окна выбора файла
        /// </summary>
        public DelegateCommand BrowseCommand { get; }

        #endregion

        #region Construct

        public MainViewModel()
        {
            // Инициализация коллекции фильтров
            _filters = new ObservableCollection<FilterItem>();

            // Инициализация команд
            // Создание комнды добавления нового фильтра в колекцию
            AddFilterCommand = new DelegateCommand(() => _filters.Add(new FilterItem()));

            // Создание комнды удаления фильтра из колекции
            DeleteFilterCommand = new DelegateCommand<object>(o =>
            {
                var del = (o as FrameworkElement)?.DataContext as FilterItem;
                if (Filters.Contains(del))
                {
                    _filters.Remove(del);
                }
            });

            // Создание комнды для открытия диалогового окна выбора файла
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

            // Создание комнды для закрытия формы и приложения
            CloseWindowCommand = new DelegateCommand<object>(obj => { if (obj is Window window) window.Close(); });
        }

        #endregion
    }
}