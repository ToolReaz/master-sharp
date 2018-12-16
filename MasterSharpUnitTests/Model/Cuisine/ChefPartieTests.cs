using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Cuisine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Cuisine.Tests
{
    [TestClass()]
    public class ChefPartieTests
    {
        public Queue<string> ToDoAction;
        public Queue<int> TimeToDoAction;
        private ChefPartie chef;
        
        [TestMethod()]
        public void AddActionToDoTest()
        {
            ToDoAction = new Queue<string>();
            TimeToDoAction = new Queue<int>();
            chef.ActionToDo("find", 30);

            Assert.IsNotNull(ToDoAction.Enqueue("find"));
            Assert.IsNotNull(TimeToDoAction.Enqueue(30));

        }

        
    }
}