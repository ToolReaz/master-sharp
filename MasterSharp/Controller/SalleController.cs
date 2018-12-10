using Model.EDM;
using System;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;


namespace Controller
{
    public class SalleController
    {
        public SalleController()
        {
            //Console.WriteLine("SalleController instancié Fils instancié :");
        }

        const int PORT_NO = 5000;
        const string SERVER_IP = "127.0.0.1";


        public void ClientSock()
        {
            Console.WriteLine("Chibre client lancé :");

            //---data to send to the server---
            //PROViSOIRE
            MenuOfTheDay menu = new MenuOfTheDay();
            Recipe recette = menu.ofTheDay("Entrée");
            string textToSend = recette.Name;

            //---create a TCPClient object at the IP and port no.---
            TcpClient client = new TcpClient(SERVER_IP, PORT_NO);
            NetworkStream nwStream = client.GetStream();
            byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(textToSend);

            //---send the text---
            Console.WriteLine("(client)Sending : " + textToSend);
            nwStream.Write(bytesToSend, 0, bytesToSend.Length);

            //---read back the text---
            byte[] bytesToRead = new byte[client.ReceiveBufferSize];
            int bytesRead = nwStream.Read(bytesToRead, 0, client.ReceiveBufferSize);
            Console.WriteLine("(client)Received : " + Encoding.ASCII.GetString(bytesToRead, 0, bytesRead));
            client.Close();
        }

        //TEXT FILE (command history)

    }
}
