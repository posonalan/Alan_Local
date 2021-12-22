using Schools.Data.Models;
using System;
using System.Collections.Generic;

#nullable disable

namespace Schools.Data.Dtos

{
    public partial class CourseDTOOut
    {
        public CourseDTOOut()
        {
        }

        public string CourseName { get; set; }
        public string Description { get; set; }

        }
}
