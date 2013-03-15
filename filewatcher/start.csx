using System;
using System.IO;
using System.Timers;

var count = 0;

  // Clean up directory
Console.WriteLine("cleaning up directory...");
foreach (var file in Directory.EnumerateFiles(Environment.CurrentDirectory, "*.txt"))
File.Delete(file);

Console.WriteLine("watching the directory...");
var watcher = new FileSystemWatcher(Environment.CurrentDirectory) { EnableRaisingEvents = true };
watcher.Created += (sender, eventArgs) => {
	Console.WriteLine("{0} was created!", eventArgs.FullPath);
};

// write a document every 5 seconds
var timer = new Timer { AutoReset = true, Enabled = true, Interval = 5000 };
timer.Elapsed +=
	(sender, eventArgs) => {	    
	    var path = Path.Combine(Environment.CurrentDirectory, ++count + ".txt");
	    File.WriteAllText(path, "hello from scriptcs");
	};

Console.ReadKey();