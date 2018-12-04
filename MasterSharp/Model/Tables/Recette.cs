using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterSharp.Model
{
    class Recette
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Timestamp]
        public byte[] PreparationTime { get; set; }


        [Required]
        [Timestamp]
        public byte[] CookTime { get; set; }


        [Required]
        [Timestamp]
        public byte[] RestTime { get; set; }


        [Required]
        public string Description { get; set; }

        [Required]
        public string Side { get; set; }

        public virtual List<Aliment> Aliments { get; set; }
    }
}
