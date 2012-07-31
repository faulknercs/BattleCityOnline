using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace BattleCity.DedicatedSrever
{
    public class SocketListener
    {
        public SocketListener()
        {
            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Any, Server.serverPort);
            newsock = new Socket(AddressFamily.InterNetwork,
                                        SocketType.Stream, ProtocolType.Tcp);
            newsock.Bind(localEndPoint);
            newsock.Listen(10);
        }

        private Socket newsock;

        public static IPAddress getServerIP()
        {
            String direction;
            WebRequest request = WebRequest.Create("http://checkip.dyndns.org/");
            using (WebResponse response = request.GetResponse())
            using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                direction = stream.ReadToEnd();

            //Search for the ip in the html
            int first = direction.IndexOf("Address: ") + 9;
            int last = direction.LastIndexOf("</body>");
            direction = direction.Substring(first, last - first);

            return IPAddress.Parse(direction);
        }

        public static int getServerPort()
        {
            int port = 8010;
            while (true)
            {
                try
                {
                    IPAddress ipAddress = Dns.GetHostEntry("localhost").AddressList[0];
                    TcpListener tcpListener = new TcpListener(ipAddress, port);
                    tcpListener.Start();
                    return port;
                }
                catch (Exception) { port++; }
            }
        }

        public EndPoint getConnection()
        {
            Socket client = newsock.Accept();
            Console.Write("ASDA");
            return client.RemoteEndPoint;
        }
    }
}