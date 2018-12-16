using MasterSharp.Model.Stock;
using Model.Stock;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using MasterSharp.Model.Cuisine;
using MasterSharp.Model.EDM;

namespace Model.Cuisine
{
    public class ChefPartie
    {
        // Queue of all actions to do
        public Queue<string> ToDoAction { get; }
        public Queue<int> TimeToDoAction { get; }

        // ChefPartie's thread
        private Thread _thread;

        // Current usticil used
        private string ustencilToUse;

        // Current action
        private string CurrentAction;

        public ChefPartie() {
            ToDoAction = new Queue<string>();
            TimeToDoAction = new Queue<int>();

            this._thread = new Thread(
                new ThreadStart(
                    () => {
                        while (true) {
                            // If the ChefPartie has an action to do
                            if (this.ToDoAction.Count > 0) {

                                // Determines which ustensil to use depending on the action
                                lock (ToDoAction) {
                                    this.CurrentAction = this.ToDoAction.Dequeue();
                                }

                                switch (this.CurrentAction) {
                                    case "Frire":
                                        this.ustencilToUse = "Poele";
                                        break;
                                }


                                // Request DB
                                Utensil_Stock ustensilUsed;
                                do {
                                    // Try to get a clean cut
                                    using (MasterSharpEntities db = new MasterSharpEntities()) {
                                        ustensilUsed = (
                                            from u in db.Utensil_Stock
                                            where u.Utensil.Name == this.ustencilToUse && u.Clean == true
                                            select u).FirstOrDefault();
                                    }

                                    // Time needed to complete the action (this time is also used to not spam connections if any cut where found)
                                    lock (this.TimeToDoAction) {
                                        try {
                                            Thread.Sleep(TimeToDoAction.Dequeue());
                                        } catch (Exception e) {
                                            Thread.Sleep(10000);
                                        }
                                    }

                                    // Do it until a clean cut is available
                                } while (ustensilUsed == null);

                                // If the unstencil where found use it (the cut become dirty)
                                using (MasterSharpEntities db = new MasterSharpEntities()) {
                                    var tmp = (
                                        from u in db.Utensil_Stock
                                        where u.Utensil.ID == ustensilUsed.ID_Utensils
                                        select u).FirstOrDefault();

                                    tmp.Clean = false;
                                    db.SaveChanges();
                                }
                            }
                            // Sleep to prevent high usage of processor
                            Thread.Sleep(2000);
                        }
                    }));
            _thread.Start();
        }


        public void AddActionToDo(string action, int time) {
            lock (this.ToDoAction) {
                this.ToDoAction.Enqueue(action);
            }

            lock (this.TimeToDoAction) {
                this.TimeToDoAction.Enqueue(time);
            }
        }
    }
}
