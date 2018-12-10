using System;
using System.Collections.Generic;
using System.Linq;

namespace Model.Salle
{
    public class GroupeClient
    {
        private List<Client> Groupe = new List<Client>();

        public GroupeClient(int NbPersonneGroupe)
        {
            this.Groupe = new List<Client>(); ;
            for(int i = 0; i<=NbPersonneGroupe; i++)
            {
                
                Random TypeClient = new Random();
                int version = TypeClient.Next(1, 3);

                switch (version)
                {
                    case 1: Groupe.Add(FactoryClient.CreateBusyClient());
                        break;
                    case 2: Groupe.Add(FactoryClient.CreateCoolClient());
                        break;
                    case 3: Groupe.Add(FactoryClient.CreateStandardClient);
                        break;
                    default: Groupe.Add(FactoryClient.CreateStandardClient);
                        break;
                }

            }
        }

        //MARK-- need to check
        public void AddClient(Client client)
        {
            Groupe.Add(client);
        }

        public void RemoveClient(Client client)
        {
            Groupe.Remove(client);

        }
    }
}
