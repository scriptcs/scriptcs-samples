#load "setup.csx"
#r "nunit.core.dll"
#r "nunit.core.interfaces.dll"

var path = "MyUnitTests.dll";
var runner = TestSetup.GetRunner(new[] {path});
var result = runner.Run(new ConsoleListener(msg => Console.WriteLine(msg)), TestFilter.Empty, true, LoggingThreshold.All);

Console.ReadKey();