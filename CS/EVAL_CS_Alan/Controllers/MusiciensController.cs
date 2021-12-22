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

namespace ECF.Controllers
{

class MusiciensController : ControllerBase
    {
        private readonly MusicienService _service;
        private readonly IMapper _mapper;

        public MusiciensController(MusicienService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        //GET api/Musicien
        [HttpGet]
        public ActionResult<IEnumerable<MusiciensDTOIn>> GetAllMusicien()
        {
            IEnumerable<Musicien> listeMusicien = _service.GetAllMusicien();
            return Ok(_mapper.Map<IEnumerable<MusiciensDTOIn>>(listeMusicien));
        }

        //GET api/Musicien/{i}
        [HttpGet("{id}", Name = "GetMusicienById")]
        public ActionResult<MusiciensDTOIn> GetMusicienById(int id)
        {
            Musicien commandItem = _service.GetMusicienById(id);
            if (commandItem != null)
            {
                return Ok(_mapper.Map<MusiciensDTOIn>(commandItem));
            }
            return NotFound();
        }

        //POST api/Musicien
        [HttpPost]
        public ActionResult<MusiciensDTOIn> CreateMusicien(Musicien obj)
        {
            _service.AddMusicien(obj);
            return CreatedAtRoute(nameof(GetMusicienById), new { Id = obj.IdMusicien }, obj);
        }

        //POST api/Musicien/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateMusicien(int id, MusiciensDTOIn obj)
        {
            Musicien objFromRepo = _service.GetMusicienById(id);
            if (objFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(obj, objFromRepo);
            _service.UpdateMusicien(objFromRepo);
            return NoContent();
        }

        // Exemple d'appel
        // [{
        // "op":"replace",
        // "path":"",
        // "value":""
        // }]
        //PATCH api/Musicien/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialMusicienUpdate(int id, JsonPatchDocument<Musicien> patchDoc)
        {
            Musicien objFromRepo = _service.GetMusicienById(id);
            if (objFromRepo == null)
            {
                return NotFound();
            }
            Musicien objToPatch = _mapper.Map<Musicien>(objFromRepo);
            patchDoc.ApplyTo(objToPatch, ModelState);
            if (!TryValidateModel(objToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(objToPatch, objFromRepo);
            _service.UpdateMusicien(objFromRepo);
            return NoContent();
        }

        //DELETE api/Musicien/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteMusicien(int id)
        {
            Musicien obj = _service.GetMusicienById(id);
            if (obj == null)
            {
                return NotFound();
            }
            _service.DeleteMusicien(obj);
            return NoContent();
        }


    }
}
