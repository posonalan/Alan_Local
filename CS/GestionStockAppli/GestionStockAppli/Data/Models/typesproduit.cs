using System;
using System.Collections.Generic;

#nullable disable

namespace GestionStockAppli.Data.Models
{
    public partial class typesproduit
    {
        public typesproduit()
        {
            categories = new HashSet<category>();
        }

        public int IdTypeProduit { get; set; }
        public string LibelleTypeProduit { get; set; }

        public virtual ICollection<category> categories { get; set; }
    }
}
