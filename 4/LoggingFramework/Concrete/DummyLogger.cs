using LoggingFramework.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggingFramework.Concrete
{
    public class DummyLogger : ILogger
    {
        public void Log(string toLog) { ; }
    }
}
