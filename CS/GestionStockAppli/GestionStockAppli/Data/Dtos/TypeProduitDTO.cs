using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStockAppli.Data.Dtos
{
   public partial class TypeProduitDTOIn
    {
        public TypeProduitDTOIn() 
        { }
        public int IdTypeProduit { get; set; }
        public string LibelleTypeProduit { get; set; }
    }

    public partial class TypeProduitDTOOut
    {
        public TypeProduitDTOOut()
        { }
        public string LibelleTypeProduit { get; set; }
    }



}
