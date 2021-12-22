using System;
using System.Collections.Generic;

#nullable disable

namespace Schools.Data.Dtos
{
    public partial class StudentsCourseDTOAvecStudent
    {
        public int StudentCourseId { get; set; }
        public int? StudentId { get; set; }
        public int? CourseId { get; set; }

        public virtual StudentDTOOut Student { get; set; }
    }
}
