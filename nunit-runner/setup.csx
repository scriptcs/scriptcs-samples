using System.Reflection;
using NUnit.Core;

    public static class TestSetup
    {
        public static SimpleTestRunner GetRunner(string[] paths)
        {
            var runner = new SimpleTestRunner();
            var package = new TestPackage("MyPackage");

            foreach (var path in paths) {
                package.Assemblies.Add(path);
            }

            runner.Load(package);
            return runner;
        }
    }

    public class ConsoleListener : EventListener
    {
        private readonly Action<string> _logger;

        public ConsoleListener(Action<string> logger)
        {
            _logger = logger;
        }

        public void RunStarted(string name, int testCount)
        {
            _logger(string.Format("Run started "));
        }

        public void RunFinished(TestResult result)
        {
            _logger("");
            _logger("-------------------------------");
            _logger(string.Format("Overall result: {0} ", result.ResultState));
        }

        public void RunFinished(Exception exception)
        {
            _logger(string.Format("Exception occurred: {0}", exception.StackTrace.Replace(Environment.NewLine, "")));
        }

        public void SuiteFinished(TestResult result)
        {
        }

        public void SuiteStarted(TestName testName)
        {
        }

        public void TestFinished(TestResult result)
        {
            _logger(string.Format("Result: {0} ", result.ResultState));
        }

        public void TestOutput(TestOutput testOutput)
        {
            _logger(string.Format(testOutput.Text.Replace(Environment.NewLine, "")));
        }

        public void TestStarted(TestName testName)
        {
            _logger("");
            _logger(string.Format("Test started: {0} ", testName.FullName.Replace(Environment.NewLine, "")));
        }

        public void UnhandledException(Exception exception)
        {
            _logger(string.Format("Unhandled exception occurred: {0}", exception.StackTrace.Replace(Environment.NewLine, "")));
        }
    }

        CoreExtensions.Host.InitializeService();
