using log4net;
using log4net.Config;
using SampleWebApi.Core.Common.Contracts.Log;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWebApi.Core.Log
{
    public class Logger : ILogger
    {
        private readonly ILog _log;
        public Logger()
        {
            //XmlConfigurator.Configure(new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "log4net.Config"));
            _log = LogManager.GetLogger("JsonFileLogger");
        }
        void ILogger.Error(string message, Exception exception)
        {
            Contract.Assert(!string.IsNullOrEmpty(message));
            Contract.Assert(exception != null);
            _log.Error(message, exception);
        }

        void ILogger.Info(string message)
        {
            Contract.Assert(!string.IsNullOrEmpty(message));
            _log.Info(message);
        }
    }
}
