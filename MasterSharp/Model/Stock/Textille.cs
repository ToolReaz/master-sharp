using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterSharp.Model.Stock
{
    class Textille : ITextille
    {

        private TypeTextille Type { get; }


        public Textille(TypeTextille type) {
            Type = type;
        }
    }
}
