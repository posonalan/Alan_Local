using Schools.Data.Models;
using System;
using System.Collections.Generic;

#nullable disable

namespace Schools.Data.Dtos
{
    public partial class CourseDTOAvecStudentCourse
    {
        public CourseDTOAvecStudentCourse()
        {
            StudentsCourses = new HashSet<StudentsCourseDTOAvecStudent>();
        }

        public string CourseName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<StudentsCourseDTOAvecStudent> StudentsCourses { get; set; }
    }
}
