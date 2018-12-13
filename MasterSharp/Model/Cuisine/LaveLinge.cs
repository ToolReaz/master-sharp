using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using MasterSharp.Model.Stock;
using Model.Stock;

namespace Model.Cuisine
{
    public class LaveLinge
    {
        private Thread thread;
        private bool ShouldRun = true;
        private Queue<IStockItem> _queue;
        private List<IStockItem> _content;
        private List<IStockItem> _output;
        private bool _working = false;

        private const int TimeToWash = 900000;


        public LaveLinge() {
            this._queue = new Queue<IStockItem>();
            this._content = new List<IStockItem>();
            this._output = new List<IStockItem>();

            this.thread = new Thread(
                () => {
                    while (ShouldRun) {
                        if (_queue.Count > 10) {
                            _working = true;
                            for (int i = 0; i < 10; i++) {
                                _content.Add(_queue.Dequeue());
                            }

                            this._content.ForEach(
                                item => {
                                    item.Wash();
                                    _output.Add(item);
                                });
                            _content.Clear();
                            Thread.Sleep(TimeToWash);
                        }
                        Thread.Sleep(2000);
                    }
                });
            this.thread.Start();
        }


        public bool IsWorking() {
            return _working;
        }

        public void Queue(IStockItem t) {
            _queue?.Enqueue(t);
        }
    }
}
