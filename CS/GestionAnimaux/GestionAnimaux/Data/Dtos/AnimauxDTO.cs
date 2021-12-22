using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionAnimaux.Data.Dtos
{
    /* Cette classe servira à envoyer les données à l’extérieur sans mentionner l’id qui reste de la logique interne. */
    public class AnimauxDTO
    {

        public string Nom { get; set; }
        // On masque également les informations dans Alimentation
        public AlimentationsDTO Aliment { get; set; }

        //internal void Dump()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
