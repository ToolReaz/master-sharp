﻿using System;
using System.Linq;
using System.Threading;
using MasterSharp.Model.Salle;

namespace Model.Salle
{
    public class Serveur : IEmployeSalle
    {
        private Salle salle;
        private Thread thread;
        private Table table;
        private GroupeClient groupe;

        public Serveur(Salle _salle)
        {
            //Console.WriteLine("Serveur intancié > ");
            salle = _salle;
            this.thread = new Thread(new ThreadStart(this.DoWork));
            //thread.Start();
            
        }
        public void DoWork()
        {
            throw new NotImplementedException();
        }

        public void ServeClient(Client client)
        {
            throw new NotImplementedException();
        }

        //debarrasser la table
        public void RidOff()
        {
            throw new NotImplementedException();
        }

        public void BringFood()
        {
            throw new NotImplementedException();
        }
    }

}
