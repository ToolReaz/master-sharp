using System;
using System.Collections.Generic;
using System.Linq;
using MasterSharp.Comptoir;
using Model.Stock;

namespace Model.Comptoir
{
    public class ComptoirPlatsPreparer : IComptoir
    {
        private Queue<Recette> RecipesReady;


        public ComptoirPlatsPreparer() {
            this.RecipesReady = new Queue<Recette>();
        }
        public void AddElement()
        {
            throw new NotImplementedException();
        }

        public void AddElement(int NbPlatsSalle)
        {
            throw new NotImplementedException();
        }

        public void RemoveElement()
        {
            throw new NotImplementedException();
        }

        public void RemoveElement(int NbRemoveElement)
        {
            throw new NotImplementedException();
        }
    }
}
