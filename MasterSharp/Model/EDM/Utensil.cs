//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model.EDM
{
    using System;
    using System.Collections.Generic;
    
    public partial class Utensil
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Utensil()
        {
            this.Utensil_Stock = new HashSet<Utensil_Stock>();
            this.Actions = new HashSet<Action>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public int ID_Size { get; set; }
    
        public virtual Size Size { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Utensil_Stock> Utensil_Stock { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Action> Actions { get; set; }
    }
}