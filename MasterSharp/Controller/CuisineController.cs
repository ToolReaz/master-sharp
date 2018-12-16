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
using Model.Stock;
using MasterSharp.Model.EDM;
using Model.Salle;

namespace Controller
{
    public sealed class CuisineController
    {
        //static ref to the object (Singleton DP)
        private static CuisineController instance = null;
        //Thread-safe : only one thread can instanciate the class
        private static readonly object padlock = new object();

        /*---OTHER VAR---*/
        Cuisine cuisine;

        //Private unique constructor & without parameters (Singleton DP)
        private CuisineController()
        {
            Console.WriteLine("CuisineController instancié :");
            cuisine = new Cuisine();
        }

        public List<dynamic> GetFoodStock()
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

        public List<dynamic> GetDishStock()
        {
            using (MasterSharpEntities dbcontext = new MasterSharpEntities())
            {
                var stock = from h in dbcontext.Dishes
                            join f in dbcontext.Dish_Stock on h.ID equals f.ID_Dishes
                            select new
                            {
                                ID = h.ID,
                                Name = h.Name,
                                Quantity = f.Quantity,
                                Clean = f.Clean
                            };

                return stock.ToList<dynamic>();
            }
        }

        public List<dynamic> GetTextilStock()
        {
            using (MasterSharpEntities dbcontext = new MasterSharpEntities())
            {
                var stock = from h in dbcontext.Textils
                            join f in dbcontext.Textil_Stock on h.ID equals f.ID_Textils
                            select new
                            {
                                ID = h.ID,
                                Name = h.Name,
                                Quantity = f.Quantity,
                                Clean = f.Clean
                            };

                return stock.ToList<dynamic>();
            }
        }

        public List<dynamic> GetUtensilStock()
        {
            using (MasterSharpEntities dbcontext = new MasterSharpEntities())
            {
                var stock = from h in dbcontext.Utensils
                            join f in dbcontext.Utensil_Stock on h.ID equals f.ID_Utensils
                            select new
                            {
                                ID = h.ID,
                                Name = h.Name,
                                Quantity = f.Quantity,
                                Clean = f.Clean
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
                    //Console.WriteLine("(Cuisine)Listening for a client command ...");

                    //---incoming client connected---
                    TcpClient client = serverListener.AcceptTcpClient();
                    //Console.WriteLine("(Cuisine) Server socket started !");

                    dataReceived = null;

                    //---get the incoming data through a network stream---
                    NetworkStream nwStream = client.GetStream();

                    int bytesRead = nwStream.Read(buffer, 0, buffer.Length);

                    //---convert the data received into a string then int---
                    dataReceived = Encoding.ASCII.GetString(buffer, 0, bytesRead);          //data received seems like "Entrees;2" (recetteType;recetteNbr) to search in the Carte !

                    //Conversion du string reçu
                    string[] returnConcat = dataReceived.Split(';');
                    string recetteType = returnConcat[0];
                    int recetteNbr = int.Parse(returnConcat[1]);
                    int recipeID = 0;

                    //selon le type de la recette, on va pouvoir la récupérer dans la carte qui contient 1 liste/type
                    switch (recetteType)
                    {
                        case "Entrees":
                            recipeID = Carte.Instance.Entrees[recetteNbr].recipeID;
                            break;
                        case "Plats":
                            recipeID = Carte.Instance.Plats[recetteNbr].recipeID;
                            break;
                        case "Desserts":
                            recipeID = Carte.Instance.Desserts[recetteNbr].recipeID;
                            break;
                    }

                    //---Recover Recipe in object
                    using (MasterSharpEntities db = new MasterSharpEntities())
                    {
                        //Search in the DB the first recipe which correspond to the given ID 
                        var objRecipe = (from f in db.Recipes
                                         where f.ID == recipeID
                                         select f
                                        ).First();

                        Console.WriteLine("(Cuisine)Name of object received : " + objRecipe.Name);

                        //Write into the command history/log file
                        string line = DateTime.Today.ToString() + " - (" + recipeID + ") " + objRecipe.Name + "\n";
                        CommandLogWrite(line);

                        //Remove recipes from stock
                        RecipeTakeStock(recipeID);
                    }

                    //---write back text to the client---
                    string text = "(Cuisine) Commande en cours de preparation ...";
                    byte[] bytesResponse = ASCIIEncoding.ASCII.GetBytes(text);
                    nwStream.Write(bytesResponse, 0, bytesResponse.Length);

                    //serverListener.Stop();
                    client.Close();
                    //Console.WriteLine("(Cuisine)Server socket closed.");
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

        public static CuisineController Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new CuisineController();
                    }
                    return instance;
                }
            }
        }
    }
}


//TCPListener loop : "https://docs.microsoft.com/fr-fr/dotnet/api/system.net.sockets.tcplistener?view=netframework-4.7.2"

