using MasterSharp.Model.EDM;
using MasterSharp.Model.Salle;
using Model.Salle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;


namespace Controller
{
    public sealed class SalleController
    {
        //static ref to the object (Singleton DP)
        private static SalleController instance = null;
        //Thread-safe : only one thread can instanciate the class
        private static readonly object padlock = new object();

        /*---SOCKET---*/
        const int PORT_NO = 5000;
        const string SERVER_IP = "127.0.0.1";
        TcpClient client;
        NetworkStream nwStream;

        /*---OTHER VAR---*/
        Salle salle;


        //Private unique constructor & without parameters (Singleton DP)
        private SalleController()
        {
            Console.WriteLine("SalleController instancié :");
            salle = new Salle();
        }

        public void CriateMi() { }
        

        public void SalleCommandSend(List<Commande> commandes)
        {
            foreach (Commande cmd in commandes)
            {
                ClientSockOpen();

                int recetteNbr = cmd.recetteNbr;
                string recetteType = cmd.type;
                string returnConcat = recetteType + ";" + recetteNbr;

                //---send the text---
                Console.Write("(Salle)Sending Carte recipe : " + returnConcat + " -----> ");
                byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(returnConcat);
                nwStream.Write(bytesToSend, 0, bytesToSend.Length);

                //---read back the text---
                byte[] bytesToRead = new byte[client.ReceiveBufferSize];
                int bytesRead = nwStream.Read(bytesToRead, 0, bytesToRead.Length);
                Console.WriteLine("(Salle)Received : " + Encoding.ASCII.GetString(bytesToRead, 0, bytesRead));

                ClientSockClose();
            }
        }

        private void ClientSockOpen()
        {
            try
            {
                //---create a TCPClient object at the IP and port no.---
                client = new TcpClient(SERVER_IP, PORT_NO);
                nwStream = client.GetStream();
                //Console.WriteLine("(Salle)Client socket launched !");
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
            //Console.WriteLine("(Salle)Client socket closed.");
        }

        public static SalleController Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new SalleController();
                    }
                    return instance;
                }
            }
        }
    }
}
