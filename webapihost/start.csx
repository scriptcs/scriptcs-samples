#load "webapiconfig.csx"
#load "testcontroller.csx"

using System.Reflection;
using System.IO;
using System.Web.Http;
using System.Web.Http.SelfHost;
using System.Web.Http.Dispatcher;

Console.WriteLine(Assembly.GetAssembly(typeof(TestController)).FullName);	
Console.WriteLine(Assembly.GetAssembly(typeof(TestController)).IsDynamic);	

var server = new HttpSelfHostServer(conf);
server.OpenAsync().Wait();
Console.WriteLine("Listening...");
Console.ReadKey();