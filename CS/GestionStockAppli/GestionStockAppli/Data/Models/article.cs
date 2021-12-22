using System;
using System.Collections.Generic;

#nullable disable

namespace GestionStockAppli.Data.Models
{
    public partial class article
    {
        public int IdArticle { get; set; }
        public string LibelleArticle { get; set; }
        public int? QuantiteStockee { get; set; }
        public int IdCategorie { get; set; }

        public virtual category IdCategorieNavigation { get; set; }
    }
}
