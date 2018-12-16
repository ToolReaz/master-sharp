using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Controller;
using MasterSharp.Model.Salle;
using Model.Stock;

namespace Model.Salle
{
    public class ChefRang : IEmployeSalle
    {
        private Salle salle;
        private Thread thread;
        private Table table;

        public ChefRang(Salle _salle)
        {
            //Console.WriteLine("Chef de rang intancié > ");
            salle = _salle;

            this.thread = new Thread(new ThreadStart(this.DoWork));
            thread.Start();
        }
      
        public void DoWork()
        {
            while (true)
            {
                if (salle._justArrivedClients.Count >= 1)
                {
                    for (int i = 0; i <= salle._justArrivedClients.Count; i++)
                    {
                        GroupeClient grpClients = salle._justArrivedClients.Peek();

                        //selection de la table + les placer 
                        GiveMenu(grpClients);

                        //puis dequeue
                        salle._justArrivedClients.Dequeue();

                        //le groupe est ajouté à la liste de clients prêt à commander
                        salle._readyToOrderClients.Enqueue(grpClients);
                    }
                }
                else if (salle._readyToOrderClients.Count >= 1)
                {
                    for (int i = 0; i <= salle._readyToOrderClients.Count; i++)
                    {
                        GroupeClient grpClients = salle._readyToOrderClients.Peek();

                        //selection de la table + les placer 
                        TakeCommand(grpClients);

                        //puis dequeue
                        salle._readyToOrderClients.Dequeue();

                        //Le groupe est ajouté à la liste de clients qui attendent leur commande
                        salle._waitingClients.Enqueue(grpClients);
                    }
                }

                Thread.Sleep(4000);
            }
        }

        public void GiveMenu(GroupeClient grpClient)
        {
            Console.WriteLine("ChefRang donne le menu au groupe de clients {0}", grpClient.idGroupe);

            foreach (Client client in grpClient.Groupe) 
            {
                client.ChooseMeal();
                Carte.Instance.GiveCard(1);
            }
        }

        public void TakeCommand(GroupeClient grpClient)
        {
            List<Commande> Commandes = new List<Commande>();

            foreach (Client client in grpClient.Groupe)
            {
                foreach (Commande cmd in client.Commandes)
                {
                    Commandes.Add(cmd);
                }
                Carte.Instance.ReclaimCard(1);
            }
            Console.WriteLine("Le chef de rang a récupéré les commandes du groupe de clients {0}", grpClient.idGroupe);

            //transmettre à SalleController pour qu'ensuite la commande soit transmise par le socket à la cuisine
            SalleController.Instance.SalleCommandSend(Commandes);

        }

    }
}
