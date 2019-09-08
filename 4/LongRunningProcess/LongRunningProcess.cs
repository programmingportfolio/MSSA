using LoggingFramework.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Service.Abstract;

namespace LongRunningProcess
{
    public class MyGreatProcess : IService
    {
        private readonly ILogger logger;

        public MyGreatProcess(ILogger logger)
        {
            this.logger = logger;
        }

        public void Start()
        {
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(1000);
                logger.Log($"Long running process: Iteration {i}");
            }
        }
    }
}
