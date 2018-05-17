using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using PdfSeparator.Model;
using PdfSeparator.Model.Common;
using PdfSeparator.Model.Interface;
using PdfSeparator.Views;

namespace PdfSeparator
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        Process _proccess;

        private void OnStartup(object sender, StartupEventArgs e)
        {
            bool startUpApp = true;

            var file = e.Args.FirstOrDefault(s => s.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase) && File.Exists(s));
            if (!string.IsNullOrEmpty(file))
            {
                _proccess = new Process();
                startUpApp = false;

                var worker = new BackgroundWorker()
                {
                    WorkerSupportsCancellation = true,
                    WorkerReportsProgress = true,
                };
                worker.DoWork += (o, args) =>
                {
                    if (args.Argument is FileInfo info)
                    {
                        IController model = new ControllerModel()
                        {
                            DocumentSeparateType = SeparateType.InOneFile,
                            AddBlankPageToEnd = false,
                        };

                        model.Open(info);
                        model.Separate();
                    }
                };
                worker.RunWorkerCompleted += (o, args) =>
                {
                    _proccess?.Close();
                    Environment.Exit(0);
                };

                FileInfo fi = new FileInfo(file);

                worker.RunWorkerAsync(fi);
                _proccess.Show();
            }

            if (startUpApp)
            {
                Views.Main main = new Main();
                main.Show();
            }
        }
    }
}
