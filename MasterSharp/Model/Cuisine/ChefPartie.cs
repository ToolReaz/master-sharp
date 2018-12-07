using MasterSharp.Model.Stock;
using Model.Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Cuisine
{
    public class ChefPartie : IEmployeCuisine
    {
        public void DoAction(IAction<Ustencil> _Action, Aliment _ObjAliment)
        {
            throw new NotImplementedException();
        }

        public void DoWork()
        {
            throw new NotImplementedException();
        }
    }
}
