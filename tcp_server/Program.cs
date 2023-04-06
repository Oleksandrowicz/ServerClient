using SharedData;
using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;

namespace tcp_server
{
    internal class Program
    {
        static int port = 8080;
        static void Main(string[] args)
        {
            IPAddress iPAddress = IPAddress.Parse("127.0.0.1");//Dns.GetHostEntry("localhost").AddressList[1]; //localhost
            IPEndPoint ipPoint = new IPEndPoint(iPAddress, port);

            TcpListener listener = new TcpListener(ipPoint); // bind
            listener.Start(10);
            while (true)
            {
                Console.WriteLine("Server started, waiting for connection");
                TcpClient client = new TcpClient();
                try
                {
                    while (client.Connected)
                    {
                        NetworkStream ns = client.GetStream();
                        BinaryFormatter formatter = new BinaryFormatter();
                        var checkfile = (CheckFile)formatter.Deserialize(ns);
                        
                    }
                    client.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Client finished with work");
                    Console.WriteLine(ex.Message);
                }
            }
            listener.Stop();
        }
    }
}
