using System;
using System.Linq;
using System.Threading;
using MasterSharp.Model.Salle;
using Model.Stock;

namespace Model.Salle
{
    public class ChefRang : IEmployeSalle
    {
        private Salle salle;
        private Thread thread;
        private Table table;
        private Restaurant restaurant;

        public ChefRang(Restaurant _restaurant)
        {
            Console.Write("Chef de rang intancié > ");
            restaurant = _restaurant;

            this.thread = new Thread(new ThreadStart(this.DoWork));
            //thread.Start();
        }
      
        public void DoWork()
        {
            //manger ?
            //attendre ?
        }

        public void GiveMenu(GroupeClient grpClient)
        {
            foreach (Client client in grpClient.Groupe) 
            {
                client.ChooseMeal(restaurant.carte);
            }
        }

        public void TakeCommand(GroupeClient grpClient)
        {
            foreach (Client client in grpClient.Groupe)
            {
                
            }
        }

    }
}
