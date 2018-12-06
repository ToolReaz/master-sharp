using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Cuisine
{
    interface IAction
    {
        /*Ustencil ObjUstencil { get; set; }        //va de paire avec : interface IAction<Ustencil>   */

        void DoAction();
    }
}
