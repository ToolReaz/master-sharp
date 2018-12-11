using MasterSharp.Model.Salle;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Model.Salle
{
    public class GroupeClient
    {
        private List<IClient> Groupe = new List<IClient>();

        public GroupeClient(int NbPersonneGroupe)
        {
            this.Groupe = new List<IClient>();

            Random TypeClient = new Random();
            int version = TypeClient.Next(1, 3);

            for (int i = 0; i<=NbPersonneGroupe; i++)
            { 
                switch (version)
                {
                    case 1: Groupe.Add(FactoryClient.CreateBusyClient());
                        break;
                    case 2: Groupe.Add(FactoryClient.CreateCoolClient());
                        break;
                    case 3: Groupe.Add(FactoryClient.CreateStandardClient());
                        break;
                    default: Groupe.Add(FactoryClient.CreateStandardClient());
                        break;
                }
            }


        }

    }
}
