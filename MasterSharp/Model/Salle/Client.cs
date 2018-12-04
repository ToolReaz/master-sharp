using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasterSharp.Model.Salle;

namespace MasterSharp.Model
{
    class Client : IClient
    {

        private int _eatTime;

        public Client(int eatTime) {
            this._eatTime = eatTime;
        }

        public void Order(Recette recette) {
            throw new NotImplementedException();
        }
    }
}
