﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Model.Stock
{
    public interface IVaisselle : IStockItem
    {

        void Wash();

        bool IsClean();
        
    }
}
