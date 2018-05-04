using System.IO;
using NUnit.Framework;
using PdfSeparator.Model.Interface;

namespace Logger.Component.Test
{
    [TestFixture]
    public class LoggerComponentTest
    {
        private ILogger _logger;

        [SetUp]
        public void Init()
        {
            _logger = new PdfSeparator.Model.Components.Logger();
        }

        [Test]
        public void Logger_Logging()
        {
            string message = "This a test message about Logger_RecordTest()";
            _logger.Logging(message: message);

            Assert.IsNotEmpty(_logger.Log);
            Assert.Contains(message, _logger.Log);
        }

        [Test]
        public void Logger_SaveLogToFile()
        {
            _logger.Logging(message: "This a test message about Logger_SaveLogToFile()");
            _logger.Logging(message: "This a test message about Logger_SaveLogToFile()");
            _logger.Logging(message: "This a test message about Logger_SaveLogToFile()");
            _logger.Logging(message: "This a test message about Logger_SaveLogToFile()");

            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var dir = System.IO.Path.GetDirectoryName(location);

            _logger.SaveLogToFile();

            var exist = File.Exists(Path.Combine(dir, "Log.txt"));

            Assert.IsTrue(exist);
        }

        [Test]
        public void Logger_SaveLogToFile_WithCustomPath()
        {
            _logger.Logging(message: "This a test message about Logger_SaveLogToFile_WithCustomPath()");

            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var dir = System.IO.Path.GetDirectoryName(location);
            var testDir = Path.Combine(dir, "Unit test");

            _logger.SaveLogToFile(testDir);

            var exist = File.Exists(Path.Combine(testDir, "Log.txt"));

            Assert.True(exist);
        }

        [Test]
        public void Logger_Clear()
        {
            _logger.ClearLog();

            Assert.IsEmpty(_logger.Log);
        }
    }
}
