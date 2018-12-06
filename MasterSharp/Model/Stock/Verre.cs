using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterSharp.Model.Stock
{
    class Verre : IVaisselle
    {

        private TypeVerres Type { get; }

        private bool Clean { get; set; }


        public Verre(TypeVerres type) {
            Type = type;
            Clean = true;
        }


        public void Wash() {
            throw new NotImplementedException();
        }
    }
}
