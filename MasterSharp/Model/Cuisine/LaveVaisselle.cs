using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Model.Stock;

namespace Model.Cuisine
{
    public class LaveVaisselle
    {

        private Thread _thread;
        private Queue<IStockItem> _queue;
        private List<IStockItem> _content;
        private List<IStockItem> _output;
        private bool _working = false;
        private const int TimeToWash = 600000;



        public LaveVaisselle()
        {
            _queue = new Queue<IStockItem>();
            _content = new List<IStockItem>();

            _thread = new Thread(
                new ThreadStart(
                    () => {
                        while (true) {
                            for (int i = 0; i < 25; i++) {
                                if (_queue.Count > 0) {
                                    _content.Add(_queue.Dequeue());
                                } else {
                                    break;
                                }
                            }

                            if (_content.Count > 0) {
                                _working = true;
                                _content.ForEach(
                                    item => {
                                        item.Wash();
                                        _output.Add(item);
                                    });
                                _content.Clear();
                                Thread.Sleep(TimeToWash);
                            }
                        }
                    }));
        }


        public bool IsWorking() {
            return _working;
        }

        public void Queue(IStockItem v) {
            _queue?.Enqueue(v);
        }
    }
}
