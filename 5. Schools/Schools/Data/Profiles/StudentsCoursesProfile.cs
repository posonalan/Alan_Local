using AutoMapper;
using Schools.Data.Dtos;
using Schools.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schools.Data.Profiles
{
    public class StudentsCoursesProfile:Profile
    {
        public StudentsCoursesProfile()
        {

            //CreateMap<StudentCourse, StudentCourseDTOIn>();
            //CreateMap<StudentCourseDTOIn, StudentCourse>();

            //CreateMap<StudentCourse, StudentCourseDTOOut>();
            CreateMap<StudentsCourse, StudentsCourseDTOAvecStudent>();
            //CreateMap<StudentCourseDTOOut, StudentCourse>();
            CreateMap<StudentsCourseDTOAvecStudent, StudentsCourse>();
        }
    }
}
