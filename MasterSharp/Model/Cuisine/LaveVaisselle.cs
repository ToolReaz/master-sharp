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


        // Content lists
        private List<IStockItem> _assietes;
        private List<IStockItem> _verres;
        private List<IStockItem> _couverts;


        public LaveVaisselle() {
            _queue = new Queue<IStockItem>();
            _content = new List<IStockItem>();
            _output = new List<IStockItem>();

            // Init content lists
            _assietes = new List<IStockItem>();
            _verres = new List<IStockItem>();
            _couverts = new List<IStockItem>();

            
        }

        public void Start() {
            _thread = new Thread(
                new ThreadStart(
                    () => {
                        while (true) {

                            // Je lave et seche pendant 10 minutes



                            for (int i = 0; i < 25; i++) {
                                if (this._queue?.Count > 0) {
                                    _content.Add(_queue.Dequeue());
                                } else {
                                    break;
                                }
                            }

                            if (this._content?.Count > 0)
                            {
                                _working = true;
                                _content.ForEach(
                                    item => {
                                        item.Wash();
                                        _output.Add(item);
                                    });
                                _content.Clear();
                                Thread.Sleep(TimeToWash);
                            }

                            Thread.Sleep(2000);
                        }
                    }));
            _thread.Start();
        }


        public bool IsWorking() {
            return _working;
        }

        public void Queue(IStockItem v) {
            _queue?.Enqueue(v);
        }

        public bool AddAssiete(IStockItem a) {
            if (_assietes.Count < 24) {
                _assietes.Add(a);
                return true;
            } else {
                return false;
            }
        }


        public bool AddCouvert(IStockItem c) {
            if (_couverts.Count < 24) {
                _couverts.Add(c);
                return true;
            } else {
                return false;
            }
        }


        public bool AddVerre(IStockItem v) {
            if (_verres.Count < 24) {
                _verres.Add(v);
                return true;
            } else {
                return false;
            }
        }
    }
}
