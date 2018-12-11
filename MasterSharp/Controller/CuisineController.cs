using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Model.EDM;

namespace Controller
{
    public class CuisineController
    {
        public CuisineController()
        {
            //Console.WriteLine("CuisineController instancié !");
        }

        const int PORT_NO = 5000;
        const string SERVER_IP = "127.0.0.1";
        

        public void ServerSockLaunch()
        {
            TcpListener serverListener = null;

            try
            {
                //---listen at the specified IP and port no.---
                IPAddress localAdd = IPAddress.Parse(SERVER_IP);
                serverListener = new TcpListener(localAdd, PORT_NO);

                while (true)
                {
                    Console.WriteLine("(server)Listening for a client command ...");
                    serverListener.Start();

                    //---incoming client connected---
                    TcpClient client = serverListener.AcceptTcpClient();
                    Console.WriteLine("Server socket launched !");

                    //---get the incoming data through a network stream---
                    NetworkStream nwStream = client.GetStream();
                    byte[] buffer = new byte[client.ReceiveBufferSize];

                    //---read incoming stream (loop version)---
                    int bytesRead;
                    while ((bytesRead = nwStream.Read(buffer, 0, buffer.Length)) != 0)
                    {

                        //---convert the data received into a string then int---
                        string dataReceived = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                        int receivedID = int.Parse(dataReceived);
                        Console.WriteLine("(server)Received : {0}", dataReceived);

                        //---Recover it in object
                        using (MasterSharpEntities db = new MasterSharpEntities())
                        {
                            var objRecipe = (from f in db.Recipes
                                             where f.ID == receivedID
                                             select f
                                         ).First();

                            Console.WriteLine("(server)Desc of object received : " + objRecipe.Description);

                            //Write into the command history
                            string line = DateTime.Today.ToString() + " - (" + objRecipe.ID + ") " + objRecipe.Name + "\n";
                            CommandLogWrite(line);

                            //Remove recipes from stock
                            RecipeTakeStock(receivedID);
                        }

                        //---write back text to the client---
                        string text = "(server) 5/5";
                        byte[] bytesResponse = ASCIIEncoding.ASCII.GetBytes(text);
                        nwStream.Write(bytesResponse, 0, bytesResponse.Length);

                        //serverListener.Stop();
                        client.Close();
                        Console.WriteLine("Client socket closed.");
                    }
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                // Stop listening for new clients.
                serverListener.Stop();
            }
        }

        public void RecipeTakeStock(int recipeID)
        {
            using (MasterSharpEntities db = new MasterSharpEntities())
            {
                var foods = (from f in db.Recipe_Step
                             where f.ID_Recipes == recipeID
                             select f).ToList();
                foreach (var f in foods)
                {
                    var oneFood = (from s in db.Food_Stock where s.ID_Foods == f.ID_Foods select s).First();
                    oneFood.Quantity = oneFood.Quantity - f.Food_Quantity;
                    db.SaveChanges();
                }
            }
        }

        private void CommandLogWrite(string _line)
        {
            // Write the text asynchronously to a new file
            string mydocpath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            File.AppendAllText(Path.Combine(mydocpath, "CommandLog.txt"), _line);
        }
    }
}


//TCPListener loop : "https://docs.microsoft.com/fr-fr/dotnet/api/system.net.sockets.tcplistener?view=netframework-4.7.2"

