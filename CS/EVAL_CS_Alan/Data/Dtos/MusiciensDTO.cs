using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECF.Data.Dtos
{
    public partial class MusiciensDTOIn
    {
        public MusiciensDTOIn()
        {
        }

public int IdMusicien { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Instrument { get; set; }
        public int IdGroupe { get; set; }
    }

    public partial class MusiciensDTOOut
    {
        public MusiciensDTOOut()
        {

        }

        
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Instrument { get; set; }
        public int IdGroupe { get; set; }
    }

}
