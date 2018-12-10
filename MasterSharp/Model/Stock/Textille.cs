using System;
using System.Linq;
using MasterSharp.Model.Stock;

namespace Model.Stock
{
    public class Textille : ITextille
    {

        private TypeTextille Type { get; }

        public bool Clean;


        public Textille(TypeTextille type) {
            this.Type = type;
            this.Clean = true;
        }

        public void Wash() {
            this.Clean = true;
        }

        public void Use() {
            this.Clean = false;
        }

        public bool IsClean() {
            return Clean;
        }
    }
}
