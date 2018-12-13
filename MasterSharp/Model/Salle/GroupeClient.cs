using MasterSharp.Model.Salle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Model.Salle
{
    public class GroupeClient
    {
        private List<IClient> Groupe;
        private Thread thread;

        public GroupeClient(int NbPersonneGroupe, int idGroupe)
        {
            Console.Write("GroupeClient intancié > ");
            //need to create thread?



            //init groupe
            this.Groupe = new List<IClient>();

            //select type client
            Random TypeClient = new Random();
            int version = TypeClient.Next(1, 3);

            //adding client in groupe
            for (int i = 0; i <= NbPersonneGroupe; i++)
            {
                switch (version)
                {
                    case 1:
                        {
                            //Console.WriteLine("Je suis busy");
                            Groupe.Add(FactoryClient.CreateBusyClient());
                        }
                        break;
                    case 2:
                        {
                            //Console.WriteLine("Je suis cooool");
                            Groupe.Add(FactoryClient.CreateCoolClient());
                        }
                        break;
                    case 3:
                        {
                            //Console.WriteLine("Je suis standard");
                            Groupe.Add(FactoryClient.CreateStandardClient());
                        }
                        break;
                    default:
                        {
                            //Console.WriteLine("Je suis default");
                            Groupe.Add(FactoryClient.CreateStandardClient());
                        }
                        break;
                }

            }

        }
    }
}
