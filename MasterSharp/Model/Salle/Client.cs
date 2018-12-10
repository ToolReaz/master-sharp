using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using MasterSharp.Model.Salle;
using MasterSharp.Model.Stock;
using Model.Stock;

namespace Model.Salle
{
     public class Client : IClient
    {
        private Thread thread;

        private List<Recette> Command { get; }
        private int EatTime { get; set; }

       private TypeClient Type { get; }
        
        public Client(TypeClient Type) 
        {
            this.Type = Type;
        }

        public void OrderMeal()
        {
            throw new NotImplementedException();
        }

        public void PayBill(int Bill)
        {
            Console.Out.WriteLine("Le client à payé: { 0}", Bill );
        }
    }
}
