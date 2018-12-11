using MasterSharp.Model.Stock;
using Model.Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using MasterSharp.Model.Cuisine;

namespace Model.Cuisine
{
    public class ChefPartie
    {
        public Queue<ActionRecette> ToDoAction { get; }
        public Queue<Aliment> Aliments { get; }

        private Thread _thread;

        public ChefPartie()
        {
            ToDoAction = new Queue<ActionRecette>();
            Aliments = new Queue<Aliment>();

            _thread = new Thread(
                new ThreadStart(
                    () => {
                        while (true)
                        {
                            if (ToDoAction.Count > 0)
                            {
                                // Go find aliment in stock

                            }

                            // Sleep to prevent high usage of processor
                            Thread.Sleep(2);
                        }
                    }));
        }


        public void AddActionToDo(ActionRecette action, Aliment aliment)
        {
            throw new NotImplementedException();
        }
    }
}
