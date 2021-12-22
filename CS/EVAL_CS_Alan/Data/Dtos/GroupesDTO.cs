using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECF.Data.Dtos
{
    public partial class GroupesDTOIn
    {
        public GroupesDTOIn()
        { }

      
        public string NomDuGroupe { get; set; }
        public int NombreDeFollowers { get; set; }
        public string Logo { get; set; }
    }

    public partial class GroupesDTOOut
    {
        public GroupesDTOOut()
        { } 
        public int IdGroupe { get; set; }
        public string NomDuGroupe { get; set; }
        public int NombreDeFollowers { get; set; }
        public string Logo { get; set; }
    }

}
