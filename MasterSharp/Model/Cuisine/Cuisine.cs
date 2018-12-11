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


        // Recettes queue
        private Queue<Recette> _commandsToDo;

        private Thread _thread;


        public Cuisine(Queue<Recette> recettesToDo) {
            init();


            _thread = new Thread(
                new ThreadStart(
                    () => {
                        while (true) {
                            if (_commandsToDo.Count > 0) {
                                _chefCuisine.Dispatch(_commandsToDo.Dequeue());
                            }

                            // Sleep to avoid processor saturation
                            Thread.Sleep(2);
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


            _chefCuisine = new ChefCuisine();
            _plongeurCuisine = new Plongeur(this);


            // Load actions from DB

        }
    }
}
