//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MasterSharp.Model.EDM
{
    using System;
    using System.Collections.Generic;
    
    public partial class Food_Stock
    {
        public int Quantity { get; set; }
        public System.DateTime Expiry_Date { get; set; }
        public int ID_Foods { get; set; }
        public int ID_Stocks { get; set; }
    
        public virtual Food Food { get; set; }
        public virtual Stock Stock { get; set; }
    }
}
