using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStockAppli.Data.Dtos
{
    public partial class ArticleDTOIn
    {
        public ArticleDTOIn()
        { }

        public string LibelleArticle { get; set; }
        public int? QuantiteStockee { get; set; }
        public int IdCategorie { get; set; }
    }
    public partial class ArticleDTOOut
    {
        public ArticleDTOOut()
        { }

        public string LibelleArticle { get; set; }
        public int? QuantiteStockee { get; set; }



    }
}
