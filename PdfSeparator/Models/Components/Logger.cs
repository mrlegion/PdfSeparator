using System;
using PdfSeparator.Interface;
using Prism.Mvvm;

namespace PdfSeparator.Models.Components
{
    public class Logger : BindableBase, ILogger
    {
        private string _log;

        public string Log
        {
            get => _log;
            set => SetProperty(ref _log, value);
        }

        public IController Controller { get; set; }

        public void Logging (string message)
        {
            if (String.IsNullOrEmpty(Log) || String.IsNullOrWhiteSpace(Log))
                Log = message;
            else
                Log += Environment.NewLine + message;
        }

        public void SaveLogToFile()
        {
            throw new NotImplementedException();
        }
    }
}
