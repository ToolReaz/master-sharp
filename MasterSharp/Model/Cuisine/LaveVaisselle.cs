using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using MasterSharp.Model.EDM;
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


        // Content ID lists
        private List<int> _assietesID;
        private List<int> _verresID;
        private List<int> _couvertsID;

        // Content QUANTITY lists
        private List<int> _assietesQuantity;
        private List<int> _verresQuantity;
        private List<int> _couvertsQuantity;


        public LaveVaisselle() {
            _queue = new Queue<IStockItem>();
            _content = new List<IStockItem>();
            _output = new List<IStockItem>();

            // Init content ID lists
            _assietesID = new List<int>();
            _verresID = new List<int>();
            _couvertsID = new List<int>();

            // Init content QUANTITY lists
            _assietesQuantity = new List<int>();
            _verresQuantity = new List<int>();
            _couvertsQuantity = new List<int>();
        }


        public void Start() {
            _thread = new Thread(
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

                        if (this._content?.Count > 0) {
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
                });
            _thread.Start();
        }


        public bool IsWorking() {
            return _working;
        }

        public void Queue(IStockItem v) {
            _queue?.Enqueue(v);
        }

        public bool AddAssiete(int id, int quantity) {
            if (_assietesID.Count < 24) {
                _assietesID.Add(id);
                _assietesQuantity.Add(quantity);
                return true;
            } else {
                return false;
            }
        }


        public bool AddCouvert(int id, int quantity) {
            if (_couvertsID.Count < 24) {
                _couvertsID.Add(id);
                _couvertsQuantity.Add(quantity);
                return true;
            } else {
                return false;
            }
        }


        public bool AddVerre(int id, int quantity) {
            if (_verresID.Count < 24) {
                _verresID.Add(id);
                _verresQuantity.Add(quantity);
                return true;
            } else {
                return false;
            }
        }
    }
}
