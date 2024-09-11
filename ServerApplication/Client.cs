using System.Net.Sockets;

namespace ServerApplication
{
    class Client
    {
        public int index = 0;
        public string IP = null;
        public TcpClient socket;
        public NetworkStream myStream;
        private byte[] readBuff;

        public void Start()
        {
            socket.SendBufferSize = 4096;
            socket.ReceiveBufferSize = 4096;
            myStream = socket.GetStream();
            Array.Resize(ref readBuff, socket.ReceiveBufferSize);
            myStream.BeginRead(readBuff, 0, socket.ReceiveBufferSize, OnReceiveData, null);
        }

        void CloseConnection()
        {
            socket.Close();
            socket = null;
            Console.WriteLine("Player disconnected : " + IP);
        }

        void OnReceiveData(IAsyncResult result)
        {
            try
            {
                int readBytes = myStream.EndRead(result);

                if (socket == null)
                {
                    return;
                }

                if (readBytes <= 0)
                {
                    CloseConnection();
                    return;
                }

                byte[] newBytes = null;
                Array.Resize(ref newBytes, readBytes);
                Buffer.BlockCopy(readBuff, 0, newBytes, 0, readBytes);

                // Handle Data

                if (socket == null)
                {
                    return;
                }

                myStream.BeginRead(readBuff, 0, socket.ReceiveBufferSize, OnReceiveData, null);
            }
            catch (Exception ex)
            {
                CloseConnection();
                return;
            }
        }
    }
}
