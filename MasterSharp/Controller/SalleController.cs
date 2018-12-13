using MasterSharp.Model.EDM;
using Model.Salle;
using System;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;


namespace Controller
{
    public class SalleController
    {
        Salle salle;

        /*---SOCKET---*/
        const int PORT_NO = 5000;
        const string SERVER_IP = "127.0.0.1";
        TcpClient client;
        NetworkStream nwStream;

        public SalleController()
        {
            //Console.WriteLine("SalleController instancié :");
            salle = new Salle();            
        }

       

        public void SalleCommandSend(int _recipeID)
        {
            ClientSockOpen();

            string recipeID = _recipeID.ToString();

            //---send the text---
            Console.WriteLine("\n(client)Sending ID : " + recipeID);
            byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(recipeID);
            nwStream.Write(bytesToSend, 0, bytesToSend.Length);

            //---read back the text---
            byte[] bytesToRead = new byte[client.ReceiveBufferSize];
            int bytesRead = nwStream.Read(bytesToRead, 0, bytesToRead.Length);
            Console.WriteLine("\n(client)Received : " + Encoding.ASCII.GetString(bytesToRead, 0, bytesRead));

            ClientSockClose();
        }

        private void ClientSockOpen()
        {
            try
            {
                //---create a TCPClient object at the IP and port no.---
                client = new TcpClient(SERVER_IP, PORT_NO);
                nwStream = client.GetStream();
                Console.WriteLine("\nClient socket launched !");
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
        }
        private void ClientSockClose()
        {
            client.Close();
            nwStream.Close();
            Console.WriteLine("\nClient socket closed.");
        }
    }
}
