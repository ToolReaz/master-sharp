using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using System.Threading;


namespace Controller
{
    public class CuisineController
    {
        public CuisineController()
        {
            Console.WriteLine("CuisineController instancié !");
        }

        const int PORT_NO = 5000;
        const string SERVER_IP = "127.0.0.1";
        
        public void ServerSock()
        {
            Console.WriteLine("Chibre server lancé !");

            //---listen at the specified IP and port no.---
            IPAddress localAdd = IPAddress.Parse(SERVER_IP);
            TcpListener listener = new TcpListener(localAdd, PORT_NO);
            Console.WriteLine("Listening...");
            listener.Start();

            //---incoming client connected---
            TcpClient client = listener.AcceptTcpClient();

            //---get the incoming data through a network stream---
            NetworkStream nwStream = client.GetStream();
            byte[] buffer = new byte[client.ReceiveBufferSize];

            //---read incoming stream---
            int bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize);

            //---convert the data received into a string---
            string dataReceived = Encoding.ASCII.GetString(buffer, 0, bytesRead);
            Console.WriteLine("(server)Received : " + dataReceived);

            //---write back the text to the client---
            Console.WriteLine("(server)Sending back : " + dataReceived);
            nwStream.Write(buffer, 0, bytesRead);
            client.Close();
            listener.Stop();
        }

    }
}
