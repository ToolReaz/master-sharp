using Model.Salle;
using Model.Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MasterSharp.Model.Salle
{
    public class Commande
    {
        public Client client { get; }       //le client a comme attribut utilisable son "idGroupe", lors de son tri par le chef de cuisine (table servie en même tps) et lors du service
        public Recette recette { get; }
        public String type { get; }     //Type de recette (entrée, plat ou dessert). Evitera au chef de cuisine de rechercher dans la DB le type pour ordonner ceux-ci, car la carte les a déjà triée.

        public Commande(Client _client, Recette _recette, String _type)
        {
            _client = client;
            _recette = recette;
            _type = type;
        }
    }
}
