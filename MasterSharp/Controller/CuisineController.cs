using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Model;
using Model.Cuisine;
using Model.EDM;
using Model.Stock;

namespace Controller
{
    public class CuisineController
    {
        Queue<Recette> recettesToDo;
        Cuisine cuisine;

        public CuisineController()
        {
            //Console.WriteLine("CuisineController instancié !");
            recettesToDo = new Queue<Recette>();
            cuisine = new Cuisine(recettesToDo);
        }

        public List<dynamic> GetStock()
        {
            using (MasterSharpEntities dbcontext = new MasterSharpEntities())
            {
                var stock = from h in dbcontext.Foods
                            join f in dbcontext.Food_Stock on h.ID equals f.ID_Foods
                            select new
                            {
                                ID = h.ID,
                                Name = h.Name,
                                Quantity = f.Quantity,
                                Expiry_Date = f.Expiry_Date
                            };

                return stock.ToList<dynamic>();
            }
        }

        /*---SOCKET/COMMAND LISTENER---*/
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

                // Start listening for client requests.
                serverListener.Start();

                // Buffer for reading data
                Byte[] buffer = new Byte[256];
                string dataReceived = null;

                while (true)
                {
                    Console.WriteLine("(server)Listening for a client command ...");

                    //---incoming client connected---
                    TcpClient client = serverListener.AcceptTcpClient();
                    Console.WriteLine("Server socket started !");

                    dataReceived = null;

                    //---get the incoming data through a network stream---
                    NetworkStream nwStream = client.GetStream();

                    int bytesRead = nwStream.Read(buffer, 0, buffer.Length);
                    
                    //---convert the data received into a string then int---
                    dataReceived = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    int receivedID = int.Parse(dataReceived);
                    Console.WriteLine("(server)Received : {0}", dataReceived);

                    //---Recover it in object
                    using (MasterSharpEntities db = new MasterSharpEntities())
                    {
                        //Search in the DB the first recipe which correspond to the given ID 
                        var objRecipe = (from f in db.Recipes
                                            where f.ID == receivedID
                                            select f
                                        ).First();

                        Console.WriteLine("(server)Name of object received : " + objRecipe.Name);

                        //Write into the command history/log file
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


        private void RecipeTakeStock(int recipeID)
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
            // Write the text asynchronously to "CommandLog.txt"
            string mydocpath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            File.AppendAllText(Path.Combine(mydocpath, "CommandLog.txt"), _line);
        }
    }
}


//TCPListener loop : "https://docs.microsoft.com/fr-fr/dotnet/api/system.net.sockets.tcplistener?view=netframework-4.7.2"

