using AutoMapper;
using ECF.Data.Dtos;
using ECF.Data.Models;
using ECF.Data.Services;
using ECF.Data.Profiles;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using ECF.Data;

namespace ECF.Controllers
{
    class GroupesController : ControllerBase
    {
        private readonly GroupeService _service;
        private readonly IMapper _mapper;

        //public GroupesController(GroupeService service, IMapper mapper)
        //{
        //    _service = service;
        //    _mapper = mapper;
        //}

        public GroupesController(EcfContext context)
        {
            _service = new GroupeService(context);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<GroupeProfile>();
                
            });
            _mapper = config.CreateMapper();
        }

        ////GET api/Groupe
        //[HttpGet]
        //public ActionResult<IEnumerable<GroupesDTOIn>> GetAllGroupe()
        //{
        //    IEnumerable<Groupe> listeGroupe = _service.GetAllGroupe();
        //    return Ok(_mapper.Map<IEnumerable<GroupesDTOIn>>(listeGroupe));
        //}

        //GET api/Plats
        [HttpGet]
        public IEnumerable<GroupesDTOOut> GetAllGroupes()
        {
            IEnumerable<Groupe> listeGroupe = _service.GetAllGroupe();
            return _mapper.Map<IEnumerable<GroupesDTOOut>>(listeGroupe);
        }


        //GET api/Groupe/{i}
        [HttpGet("{id}", Name = "GetGroupeById")]
        public ActionResult<GroupesDTOIn> GetGroupeById(int id)
        {
            Groupe commandItem = _service.GetGroupeById(id);
            if (commandItem != null)
            {
                return Ok(_mapper.Map<GroupesDTOIn>(commandItem));
            }
            return NotFound();
        }

        //POST api/Groupe
        [HttpPost]
        public ActionResult<GroupesDTOIn> CreateGroupe(Groupe obj)
        {
            _service.AddGroupe(obj);
            return CreatedAtRoute(nameof(GetGroupeById), new { Id = obj.IdGroupe }, obj);
        }

        //POST api/Groupe/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateGroupe(int id, GroupesDTOIn obj)
        {
            Groupe objFromRepo = _service.GetGroupeById(id);
            if (objFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(obj, objFromRepo);
            _service.UpdateGroupe(objFromRepo);
            return NoContent();
        }

        // Exemple d'appel
        // [{
        // "op":"replace",
        // "path":"",
        // "value":""
        // }]
        //PATCH api/Groupe/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialGroupeUpdate(int id, JsonPatchDocument<Groupe> patchDoc)
        {
            Groupe objFromRepo = _service.GetGroupeById(id);
            if (objFromRepo == null)
            {
                return NotFound();
            }
            Groupe objToPatch = _mapper.Map<Groupe>(objFromRepo);
            patchDoc.ApplyTo(objToPatch, ModelState);
            if (!TryValidateModel(objToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(objToPatch, objFromRepo);
            _service.UpdateGroupe(objFromRepo);
            return NoContent();
        }

        //DELETE api/Groupe/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteGroupe(int id)
        {
            Groupe obj = _service.GetGroupeById(id);
            if (obj == null)
            {
                return NotFound();
            }
            _service.DeleteGroupe(obj);
            return NoContent();
        }


    }
}
