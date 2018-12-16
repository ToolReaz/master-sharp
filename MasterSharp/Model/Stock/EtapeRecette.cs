using System;
using MasterSharp.Model.Cuisine;
using Model.Stock;

namespace MasterSharp.Model.Stock
{
    // This class define a step in a recipe
    public class EtapeRecette
    {
        public string Aliment { get; } = null;
        public string ActionName { get; } = null;
        public int ActionTime { get; } = 0;
        public bool Completed { get; set; }


        public EtapeRecette(string aliment, string actionName, int actionTime) {
            this.Aliment = aliment;
            this.ActionName = actionName;
            this.ActionTime = actionTime;
            this.Completed = false;
        }
    }
}