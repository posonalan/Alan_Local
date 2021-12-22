using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionAnimaux.Data.Dtos
{
    public class AnimauxDTOIn
    {
        public string Nom { get; set; }
        // On masque également les informations dans Alimentation
        public int IdAliment { get; set; }
    }
}
