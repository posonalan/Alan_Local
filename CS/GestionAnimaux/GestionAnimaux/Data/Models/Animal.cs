using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestionAnimaux.Data.Models
{
    public class Animal
    {
        [Key]
        public int IdAnimal { get; set; }
        public string Nom { get; set; }
        //on garde l'id de la table pour établir la jointure
        public int IdAliment { get; set; }
        public Aliment Aliment { get; set; }
        internal void Dump()
        {
            throw new NotImplementedException();
        }
    }
}
