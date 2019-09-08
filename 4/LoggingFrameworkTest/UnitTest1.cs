using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Shouldly;
using LoggingFramework.Abstract;
using LoggingFramework.Concrete;

namespace LoggingFrameworkTest
{
    [TestClass]
    public class FileLoggerTests
    {
        private const string Path = "test.file.txt";
        private readonly ILogger logger = new FileLogger(Path);

        [ClassInitialize()]
        public static void Init(TestContext _)
        {
            File.Delete(Path);
        }

        [ClassCleanup()]
        public static void Cleanup()
        {
            File.Delete(Path);
        }

        [TestMethod]
        public void TestMethod1()
        {
            File.Exists(Path).ShouldBeTrue();
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string ToLog = "a nice little test string";
            logger.Log(ToLog);

            var read = File.ReadAllText(Path);

            read.ShouldBe($"{ToLog}\r\n");
        }
    }
}
