using MasterSharp.Model.Salle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Model.Salle
{
    public class GroupeClient
    {
        public List<IClient> Groupe { get; }
        private Thread thread;
        public int idGroupe { get; }

        public GroupeClient(int NbPersonnesGroupe, int _idGroupe)
        {
            Console.Write("GroupeClient intancié > ");
            idGroupe = _idGroupe;
            //need to create thread?



            //init groupe
            this.Groupe = new List<IClient>();

            //select type client
            Random TypeClient = new Random();
            int version = TypeClient.Next(1, 3);

            //adding client in groupe
            for (int i = 0; i <= NbPersonnesGroupe; i++)
            {
                switch (version)
                {
                    case 1:
                        {
                            //Console.WriteLine("Je suis busy");
                            Groupe.Add(FactoryClient.CreateBusyClient(this));
                        }
                        break;
                    case 2:
                        {
                            //Console.WriteLine("Je suis cooool");
                            Groupe.Add(FactoryClient.CreateCoolClient(this));
                        }
                        break;
                    case 3:
                        {
                            //Console.WriteLine("Je suis standard");
                            Groupe.Add(FactoryClient.CreateStandardClient(this));
                        }
                        break;
                    default:
                        {
                            //Console.WriteLine("Je suis default");
                            Groupe.Add(FactoryClient.CreateStandardClient(this));
                        }
                        break;
                }

            }

        }
    }
}
