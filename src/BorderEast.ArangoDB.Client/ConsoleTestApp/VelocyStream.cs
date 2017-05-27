using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ConsoleTestApp
{
    public class VelocyStream
    {
        private TcpClient _client;
        public NetworkStream Stream { get; private set; }
        private CancellationTokenSource _token;

        public VelocyStream() {
            _token = new CancellationTokenSource();
            _client = new TcpClient();
        }

        public void Connect(string host, int port) {
            Console.WriteLine("connecting...");
            _client.ConnectAsync(host, port);
            Console.WriteLine("connected!");

            while (!_client.Connected) {
                Thread.Sleep(20);
            }

            Console.WriteLine("getting stream...");
            Stream = _client.GetStream(); // works because of Thread.Sleep above until the socket is connected
            Console.WriteLine("got stream!");
            
        }
    }
}
