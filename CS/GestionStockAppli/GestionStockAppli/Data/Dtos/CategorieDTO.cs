using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStockAppli.Data.Dtos
{
    public partial class CategorieDTOIn
    {
        public CategorieDTOIn()
        { }
        public int IdCategorie { get; set; }
        public string LibelleCategorie { get; set; }
        public int IdTypesProduits { get; set; }
    }

    public partial class CategorieDTOOut
    {
        public CategorieDTOOut()
        { }
        public string LibelleCategorie { get; set; }
        public int IdTypesProduits { get; set; }
    }
}






