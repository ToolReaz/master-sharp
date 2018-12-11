using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Stock;

namespace MasterSharp.Model.Cuisine
{
    public class ActionRecette
    {
        public string Name { get; set; }
        public int DureeAction { get; set; }
        public IUstencile Ustencile { get; set; }

        public ActionRecette(int dureeAction, IUstencile ustencile) {
            Name = Name;
            DureeAction = dureeAction;
            Ustencile = ustencile;
        }
    }
}
