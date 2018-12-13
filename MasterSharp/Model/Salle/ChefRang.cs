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

        public ChefRang(Salle _salle)
        {
            Console.Write("Chef de rang intancié > ");
            salle = _salle;

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
                client.ChooseMeal(salle.carte);
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
