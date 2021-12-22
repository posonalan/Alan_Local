using Schools.Data.Models;
using System;
using System.Collections.Generic;

#nullable disable

namespace Schools.Data.Dtos
{
    public partial class StudentDTOAvecGrade
    {
        public StudentDTOAvecGrade()
        {
        }
        // les colonnes de la table sans les id
        public string Name { get; set; }
        public int GradeId { get; set; }

        // ajouter les données attachées
        // ATTENTION il faut retourner un DTOOut
        public virtual GradeDTOOut Grade { get; set; }
    }
}
