using LoggingFramework.Abstract;
using LoggingFramework.Concrete;
using LongRunningProcess;
using Service.Abstract;
using SimpleInjector;

namespace DependencyInjection
{
    class Program
    {
        static readonly Container container;
        
        static Program()
        {
            container = new Container();

            container.Register<ILogger, ConsoleLogger>();
            container.Register<IService, MyGreatProcess>();
            container.Register<Application>();

        }

        static void Main(string[] args)
        {
            //var logger = new ConsoleLogger();
            //var service = new MyGreatProcess(logger);
            //new Application(logger, service).Start();

            var app = container.GetInstance<Application>();
            app.Start();
        }
    }
}
