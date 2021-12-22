using ECF.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECF.Data.Dtos
{
    public partial class MusiciensDTOInAvecGroupe
    {
        public MusiciensDTOInAvecGroupe()
        {
        }

        public int IdMusicien { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Instrument { get; set; }
        public int IdGroupe { get; set; }

        public virtual Musicien Musiciens { get; set; }
    

    public partial class MusiciensDTOOutAvecGroupe
        {
        public MusiciensDTOOutAvecGroupe()
        {

        }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Instrument { get; set; }
        public int IdGroupe { get; set; }

        public virtual Musicien Musiciens { get; set; }
    }






}
}
