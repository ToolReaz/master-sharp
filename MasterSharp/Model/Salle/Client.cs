using System;
using System.Collections.Generic;
using System.Linq;
using MasterSharp.Model.Salle;
using MasterSharp.Model.Stock;
using Model.Stock;

namespace Model.Salle
{
     public class Client : IClient
    {
        private List<Recette> Command { get; }
        private int EatTime { get; set; }

       private TypeClient type { get; }
        
        public Client(TypeClient type) 
        {
            this.type = type;
        }

        public void OrderMeal()
        {
            throw new NotImplementedException();
        }

        public void PayBill()
        {
            throw new NotImplementedException();
        }
    }
}
