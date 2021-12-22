using System;
using System.Collections.Generic;

#nullable disable

namespace GestionStockAppli.Data.Models
{
    public partial class category
    {
        public category()
        {
            articles = new HashSet<article>();
        }

        public int IdCategorie { get; set; }
        public string LibelleCategorie { get; set; }
        public int IdTypesProduits { get; set; }

        public virtual typesproduit IdTypesProduitsNavigation { get; set; }
        public virtual ICollection<article> articles { get; set; }
    }
}
