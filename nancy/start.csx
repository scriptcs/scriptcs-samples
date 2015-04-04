#load "module.csx"
#load "bootstrapper.csx"
#load "pathprovider.csx"
#load "customroutedescriptionprovider.csx"

using System.IO;
using Autofac;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Bootstrappers.Autofac;
using Nancy.Hosting.Self;
using Nancy.Routing;

NancyBootstrapperLocator.Bootstrapper = new Bootstrapper();

var address = "http://localhost:1234/";

var host = new NancyHost(new Uri(address));
host.Start();

Console.WriteLine("Nancy is running at " + address);
Console.WriteLine("Press any key to end");
Console.ReadKey();

host.Stop();
