using System.Collections.Generic;

var net = Require<Net>();

var mappings = new Dictionary<EmmiterTcpClient, int>();

var members = 0;

var server = net.CreateServer(socket =>
{
	members++;

    Console.WriteLine("Member {0} joined", members);

    socket.WriteAsync(string.Format("Welcome member {0}", members).AsBytes());

    mappings[socket] = members;

    socket.On(
        data: data => 
        	{
        		var message = string.Format("Member {0} says: {1}", mappings[socket], data.AsString());
        		foreach (var s in mappings.Keys)
        		{
        			if (s != socket)
        			{
        				s.WriteAsync(message.AsBytes());
        			}
        		}
        	},
        close: () =>
    		{
        		Console.WriteLine(string.Format("Member {0} left", mappings[socket]));
        		mappings.Remove(socket);
        	},
        error: e => Console.WriteLine("Error: {0}\r\nStackTrace: {1}", e.Message, e.StackTrace));
});

Console.WriteLine("Listening at 127.0.0.1:8080");

server.Listen(8080, "127.0.0.1").Wait();

Console.WriteLine("Closing server");

server.Close();