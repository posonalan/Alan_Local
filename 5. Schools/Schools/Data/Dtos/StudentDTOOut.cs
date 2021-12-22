using System;
using System.Collections.Generic;

#nullable disable

namespace Schools.Data.Dtos
{
    public partial class StudentDTOOut
    {
        public StudentDTOOut()
        {
           
        }
        // les données de la table sans les id et sans les clés etrangères
        public string Name { get; set; }
    }
}
