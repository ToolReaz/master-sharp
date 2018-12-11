using System;
using System.Linq;


namespace View
{
    //public access and sealed "scellée" (Singleton DP)
    public sealed class View 
    {
        //static ref to the object (Singleton DP)
        private static  View instance = null;
        //Thread-safe : only one thread can instanciate the class
        private static readonly object padlock = new object();

        //Private unique constructor & without parameters (Singleton DP)
        private View()
        {
            throw new NotImplementedException();
        }


        public static View Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance==null)
                    {
                        instance = new View();
                    }
                    return instance;
                }
            }
        }

        public void UpdateView()
        {
            throw new NotImplementedException();
        }

        public void GridView()
        {
            throw new NotImplementedException();
        }

        public void GetViewInstance()
        {
            throw new NotImplementedException();
        }
 
    }
}
