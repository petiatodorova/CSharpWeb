using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWebServer
{
    class SimpleWeb
    {
        static void Main(string[] args)
        {
            var address = IPAddress.Parse("127.0.0.1");
            var port = 1234;
            var server = new TcpListener(address, port);
            server.Start();
            Task.Run(async () => {await Connect(server); }).Wait();
        }

        static async Task Connect(TcpListener listener)
        {
            while (true)
            {
                // wait for browser to connect
                var client = await listener.AcceptTcpClientAsync();

                //read request
                var request = new byte[1024];
                await client.GetStream().ReadAsync(request, 0, request.Length);
                Console.WriteLine($"{Encoding.UTF8.GetString(request)}");

                var data = Encoding.UTF8.GetBytes("Hello from Petya!");
                await client.GetStream().WriteAsync(data, 0, data.Length);

                client.Dispose();
            }

        }
    }
}
