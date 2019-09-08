using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using LoggingFramework.Abstract;

namespace DependencyInjection
{
    class Application : IService
    {
        private readonly ILogger logger;
        private readonly IService longRunningProcess;

        public Application(ILogger logger, IService longRunningProcess)
        {
            this.logger = logger;
            this.longRunningProcess = longRunningProcess;
        }
        public void Start()
        {
            logger.Log("Application: Starting application");
            longRunningProcess.Start();
            logger.Log("Application: Shutting down");
        }
    }
}
