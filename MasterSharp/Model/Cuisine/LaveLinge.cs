using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using MasterSharp.Model.Stock;

namespace Model.Cuisine
{
    public class LaveLinge
    {
        private Thread thread;
        private bool ShouldRun = true;
        private Queue<ITextille> _queue;
        private List<ITextille> _content;
        private List<ITextille> _output;
        private bool _working = false;

        private const int TimeToWash = 900000;


        public LaveLinge() {
            this._content = new List<ITextille>();
            this._output = new List<ITextille>();

            this.thread = new Thread(
                () => {
                    while (ShouldRun) {
                        if (_queue.Count > 10) {
                            _working = true;
                            for (int i = 0; i < 10; i++) {
                                _content.Add(_queue.Dequeue());
                            }

                            _content.ForEach(
                                item => {
                                    item.Wash();
                                    _output.Add(item);
                                });
                            _content.Clear();
                            Thread.Sleep(TimeToWash);
                        }
                    }
                });
        }


        public bool IsWorking() {
            return _working;
        }

        public void Queue(ITextille t) {
            _queue?.Enqueue(t);
        }
    }
}
