using Schools.Data.Models;
using System;
using System.Collections.Generic;

#nullable disable

namespace Schools.Data.Dtos
{
    public partial class StudentDTOIn
    {
        public StudentDTOIn()
        {
        }

        // les données présentes dans la tables uniquement
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int GradeId { get; set; }

         }
}
