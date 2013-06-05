var net = Require<Net>();

var client = net.Connect(8080, "127.0.0.1", onConnect: () => Console.WriteLine("Connected to chat room at 127.0.0.1:8080"));

client.On(
        data: data => Console.WriteLine(data.AsString()),
        close: () => Console.WriteLine("Exiting chat"),
        error: e => Console.WriteLine("Error: {0} \r\nStackTrace: {1}", e.Message, e.StackTrace));

var line = Console.ReadLine();

while (line != ":close"){
	client.WriteAsync(line.AsBytes());

	line = Console.ReadLine();
}

// still have to troubleshoot an issue when closing the socket
client.Close();