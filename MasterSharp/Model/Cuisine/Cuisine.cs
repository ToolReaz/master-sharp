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


            this._thread = new Thread(
                new ThreadStart(
                    () => {
                        while (true) {
                            // If the cuisine need to prepare a command, send it to the chef to dispatch tasks
                            if (this._commandsToDo.Count > 0) {
                                lock (this._commandsToDo) {
                                    ChefCuisine.Dispatch(_commandsToDo.Dequeue());
                                }
                            }

                            // Sleep to avoid processor saturation
                            Thread.Sleep(2000);
                        }
                    }));
            _thread.Start();
        }

        public void AddCommand(Recette r) {
            lock (this._commandsToDo) {
                this._commandsToDo?.Enqueue(r);
            }
        }

        public Queue<Recette> GetCommandQueue() {
            lock (this._commandsToDo) {
                return this._commandsToDo;
            }
        }



        private void init() {
            this._commandsToDo = new Queue<Recette>();

            this.ChefCuisine = new ChefCuisine(this);
            this.PlongeurCuisine = new Plongeur(this);
            this.Commis = new List<CommisCuisine> {new CommisCuisine(), new CommisCuisine()};
            this.ChefParties = new List<ChefPartie> {new ChefPartie(), new ChefPartie()};
        }
    }
}
