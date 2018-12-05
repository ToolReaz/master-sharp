using System;

interface IAction<Ustencil>
{
    Ustencil ObjUstencil;

    void DoAction();
}
