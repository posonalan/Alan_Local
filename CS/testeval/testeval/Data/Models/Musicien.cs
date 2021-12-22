﻿using System;
using System.Collections.Generic;

#nullable disable

namespace testeval.Data.Models
{
    public partial class Musicien
    {
        public int IdMusicien { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Instrument { get; set; }
        public int IdGroupe { get; set; }

        public virtual Groupe IdGroupeNavigation { get; set; }
    }
}
