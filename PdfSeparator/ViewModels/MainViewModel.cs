using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Windows;
using PdfSeparator.Model;
using PdfSeparator.Model.Common;
using PdfSeparator.Model.Interface;
using Prism.Commands;
using Prism.Mvvm;

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
        
        private IController _model;

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

        public bool DocumentIsOpened => _model.DocumentIsOpened;

        public SeparateType DocumentSeparateType
        {
            get => _model.DocumentSeparateType;
            set => _model.DocumentSeparateType = value;
        }

        public bool AddBlankPageToEnd
        {
            get => _model.AddBlankPageToEnd;
            set => _model.AddBlankPageToEnd = value;
        }

        #endregion

        #region Commands

        /// <summary>
        /// Получение команды для закрытия формы и приложения
        /// </summary>
        public DelegateCommand<object> CloseWindowCommand { get; }

        /// <summary>
        /// Получение команды для открытия диалогового окна выбора файла
        /// </summary>
        public DelegateCommand BrowseCommand { get; }

        /// <summary>
        /// Получение команды для деления документа по форматам
        /// </summary>
        public DelegateCommand SeparateDocumentCommand { get; }

        #endregion

        #region Construct

        public MainViewModel()
        {

            // Инициализация бизнес модели
            _model = new ControllerModel();
            ((ControllerModel) _model).PropertyChanged += (sender, args) => RaisePropertyChanged(args.PropertyName);
            
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
                    FileInfo fileInfo = new FileInfo(FileOutPath);
                    _model.Open(fileInfo);
                }
            });

            SeparateDocumentCommand = new DelegateCommand(() => _model.Separate() );

            // Создание комнды для закрытия формы и приложения
            CloseWindowCommand = new DelegateCommand<object>(obj => { if (obj is Window window) window.Close(); });
        }

        #endregion

        #region Private methods

        #endregion
    }
}