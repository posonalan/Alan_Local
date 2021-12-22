﻿using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Schools.Data.Dtos;
using Schools.Data.Models;
using Schools.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schools.Controllers
{
    [Route("api/Students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentsServices _service;
        private readonly IMapper _mapper;

        public StudentsController(StudentsServices service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        //GET api/Students
        [HttpGet]
        public ActionResult<IEnumerable<StudentDTOAvecGrade>> GetAllStudents()
        {
            IEnumerable<Student> listeStudents = _service.GetAllStudents();
            return Ok(_mapper.Map<IEnumerable<StudentDTOAvecGrade>>(listeStudents));
        }

        //GET api/Students/{i}
        [HttpGet("{id}", Name = "GetStudentById")]
        public ActionResult<StudentDTOAvecGrade> GetStudentById(int id)
        {
            Student commandItem = _service.GetStudentsById(id);
            if (commandItem != null)
            {
                return Ok(_mapper.Map<StudentDTOAvecGrade>(commandItem));
            }
            return NotFound();
        }

        //POST api/Students
        [HttpPost]
        public ActionResult<Student> CreateStudent(StudentDTOIn obj)
        {
            _service.AddStudents(_mapper.Map<Student>(obj));
            return CreatedAtRoute(nameof(GetStudentById), new { Id = obj.StudentId }, obj);
        }

        //POST api/Students/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateStudent(int id, Student obj)
        {
            Student objFromRepo = _service.GetStudentsById(id);
            if (objFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(obj, objFromRepo);
            _service.UpdateStudents(objFromRepo);
            return NoContent();
        }

        // Exemple d'appel
        // [{
        // "op":"replace",
        // "path":"",
        // "value":""
        // }]
        //PATCH api/Students/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialStudentUpdate(int id, JsonPatchDocument<Student> patchDoc)
        {
            Student objFromRepo = _service.GetStudentsById(id);
            if (objFromRepo == null)
            {
                return NotFound();
            }
            Student objToPatch = _mapper.Map<Student>(objFromRepo);
            patchDoc.ApplyTo(objToPatch, ModelState);
            if (!TryValidateModel(objToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(objToPatch, objFromRepo);
            _service.UpdateStudents(objFromRepo);
            return NoContent();
        }

        //DELETE api/Students/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteStudent(int id)
        {
            Student obj = _service.GetStudentsById(id);
            if (obj == null)
            {
                return NotFound();
            }
            _service.DeleteStudents(obj);
            return NoContent();
        }


    }
}
