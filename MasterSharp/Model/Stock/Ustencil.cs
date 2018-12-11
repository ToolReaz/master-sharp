using System;
using System.Linq;

namespace Model.Stock
{
    public class Ustencil : IUstencile
    {
        public string Name { get; set; }
        public string Size { get; set; }
        public bool Clean { get; set; }

        public Ustencil(string name, string size, bool clean) {
            Name = name;
            Size = size;
            Clean = clean;
        }

        public void Use() {
            this.Clean = false;
        }

        public void Wash() {
            this.Clean = true;
        }
    }
}
