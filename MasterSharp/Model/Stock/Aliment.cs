﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterSharp.Model.Stock
{
    public class Aliment
    {

        private TypeAliment Type { get; }


        public Aliment(TypeAliment type) {
            Type = type;
        }

        public bool IsFresh() {
            throw new NotImplementedException();
        }
    }
}
