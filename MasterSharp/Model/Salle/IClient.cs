using Model.Salle;
using Model.Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterSharp.Model.Salle
{
    public interface IClient
    {
         void ChooseMeal();
         void PayBill(int Bill);
    }
}
