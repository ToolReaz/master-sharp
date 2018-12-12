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

        public GroupeClient(int NbPersonneGroupe)
        {
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
                            Groupe.Add(FactoryClient.CreateBusyClient());
                        }
                        break;
                    case 2:
                        {
                            Groupe.Add(FactoryClient.CreateCoolClient());
                        }
                        break;
                    case 3:
                        {
                            Groupe.Add(FactoryClient.CreateStandardClient());
                        }
                        break;
                    default:
                        {
                            Groupe.Add(FactoryClient.CreateStandardClient());
                        }
                        break;
                }

            }

        }
    }
}
