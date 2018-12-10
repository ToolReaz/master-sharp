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
                    case 1: Groupe.Add(new Client(Model.Salle.TypeClient.COOL));
                        NewClient();
                        break;
                    case 2: Groupe.Add(new Client(Model.Salle.TypeClient.BUSY));
                        NewClient();
                        break;
                    case 3: Groupe.Add(new Client(Model.Salle.TypeClient.STANDARD));
                        NewClient();
                        break;
                    default: Groupe.Add(new Client(Model.Salle.TypeClient.STANDARD));
                        NewClient();
                        break;
                }

            }
        }

        //MARK-- need to check
        public bool NewClient()
        {
            return true;
        }

        public void RemoveClient(Client client)
        {
            Groupe.Remove(client);

        }
    }
}
