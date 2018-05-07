﻿using System;
using System.Collections.Generic;
using System.IO;
using PdfSeparator.Model.Interface;

namespace PdfSeparator.Model.Components
{
    public class Logger : ILogger
    {
        private Queue<string> _log;

        public Queue<string> Log => _log;

        public IController Controller { get; set; }

        public Logger()
        {
            _log = new Queue<string>();
        }

        public void Logging (string message)
        {
            _log.Enqueue(message);
        }

        public void SaveLogToFile()
        {
            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var directory = Path.GetDirectoryName(location);

            if (string.IsNullOrEmpty(directory) || string.IsNullOrWhiteSpace(directory))
                throw new DirectoryNotFoundException(nameof(directory));

            SaveLogToFile(new DirectoryInfo(directory));
        }

        public void SaveLogToFile(DirectoryInfo directory)
        {
            if (!directory.Exists) directory.Create();

            var file = Path.Combine(directory.FullName, "Log.txt");

            var streamFile = File.Create(file);
            var writer = new StreamWriter(streamFile);

            foreach (string s in Log)
            {
                writer.Write($"{s}\n");
            }

            writer.Close();
            streamFile.Close();
        }

        public void ClearLog()
        {
            _log.Clear();
        }
    }
}
