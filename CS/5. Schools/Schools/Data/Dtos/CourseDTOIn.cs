using System;
using System.Collections.Generic;

#nullable disable

namespace Schools.Data.Dtos
{
    public partial class CourseDTOIn
    {
        public CourseDTOIn()
        {
         }

        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }

     }
}
