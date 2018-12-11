using MasterSharp.Model.Stock;
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
        private ChefCuisine _chefCuisine;
        private Plongeur _plongeurCuisine;


        private Queue<Recette> _commands;

        private Thread _thread;


        public Cuisine() {
            init();


            _thread = new Thread(
                new ThreadStart(
                    () => {
                        while (true) {
                            if (_commands.Count > 0) {
                                _chefCuisine.Dispatch(_commands.Dequeue());
                            }

                            // Sleep to avoid processor saturation
                            Thread.Sleep(2);
                        }
                    }));
            _thread.Start();
        }

        public void AddCommand(Recette r) {
            _commands?.Enqueue(r);
        }

        public Queue<Recette> GetCommandQueue() {
            return _commands;
        }



        private void init() {
            _commands = new Queue<Recette>();
            StockVaisselle = new StockVaisselle();
            StockTextille = new StockTextille();
            StockAliment = new StockAliment();
            Actions = new List<Action>();


            _chefCuisine = new ChefCuisine();
            _plongeurCuisine = new Plongeur(this);


            // Load actions from DB

        }
    }
}
