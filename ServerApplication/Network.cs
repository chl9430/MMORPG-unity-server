using System.Net;
using System.Net.Sockets;

namespace ServerApplication
{
    class Network
    {
        public TcpListener serverSocket = null;
        public static Network instance = new Network();
        public static Client[] clients = new Client[100];

        public void ServerStart()
        {
            for (int i = 0; i < 100; i++)
            {
                clients[i] = new Client();
            }

            serverSocket = new TcpListener(IPAddress.Any, 5500);
            serverSocket.Start();
            serverSocket.BeginAcceptTcpClient(OnClientConnect, null);
            Console.WriteLine("Server has successfully started!");
        }

        void OnClientConnect(IAsyncResult result)
        {
            TcpClient client = serverSocket.EndAcceptTcpClient(result);
            client.NoDelay = false;
            serverSocket.BeginAcceptTcpClient(OnClientConnect, null);
        }
    }
}