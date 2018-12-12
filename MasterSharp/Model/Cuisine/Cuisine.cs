﻿using MasterSharp.Model.Stock;
using Model.Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Model.Cuisine
{
    public class Cuisine
    {
        // Stocks
        public IStock StockVaisselle { get; set; }
        public IStock StockTextille { get; set; }
        private IStock StockAliment { get; set; }


        // Actions
        public List<Action> Actions { get; set; }


        // Employees
        public ChefCuisine ChefCuisine { get; private set; }
        public Plongeur PlongeurCuisine { get; private set; }
        public List<CommisCuisine> Commis { get; private set; }
        public List<ChefPartie> ChefParties { get; private set; }


        // Recettes queue
        private Queue<Recette> _commandsToDo;


        // Cuisine's thread
        private Thread _thread;


        public Cuisine() {
            init();


            _thread = new Thread(
                new ThreadStart(
                    () => {
                        while (true) {
                            if (_commandsToDo.Count > 0) {
                                ChefCuisine.Dispatch(_commandsToDo.Dequeue());
                            }

                            // Sleep to avoid processor saturation
                            Thread.Sleep(2000);
                        }
                    }));
            _thread.Start();
        }

        public void AddCommand(Recette r) {
            _commandsToDo?.Enqueue(r);
        }

        public Queue<Recette> GetCommandQueue() {
            return _commandsToDo;
        }



        private void init() {
            _commandsToDo = new Queue<Recette>();
            StockVaisselle = new StockVaisselle();
            StockTextille = new StockTextille();
            StockAliment = new StockAliment();
            Actions = new List<Action>();


            ChefCuisine = new ChefCuisine(this);
            PlongeurCuisine = new Plongeur(this);
            Commis = new List<CommisCuisine> {new CommisCuisine(), new CommisCuisine()};
            ChefParties = new List<ChefPartie> {new ChefPartie(), new ChefPartie()};


            // Load actions from DB

        }
    }
}
