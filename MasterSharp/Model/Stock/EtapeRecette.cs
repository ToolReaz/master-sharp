using System;
using MasterSharp.Model.Cuisine;
using Model.Stock;

namespace MasterSharp.Model.Stock
{
    public class EtapeRecette
    {
        public string Aliment { get; }
        public string ActionName { get; }
        public int ActionTime { get; }
        public bool Completed { get; set; }


        public EtapeRecette(string aliment, string actionName, int actionTime) {
            this.Aliment = aliment;
            this.ActionName = actionName;
            this.ActionTime = actionTime;
            this.Completed = false;
        }
    }
}