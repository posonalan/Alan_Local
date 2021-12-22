using AutoMapper;
using GestionStockAppli.Data.Dtos;
using GestionStockAppli.Data.Models;
using GestionStockAppli.Data.Services;
using GestionStockAppli.Data.Profiles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;


namespace GestionStockAppli.Data.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    class CategorieController : ControllerBase
    {

        private readonly CategorieService _service;
        private readonly IMapper _mapper;

        public CategorieController(MyDbContext _context)
        {
            _service = new CategorieService(_context);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CategorieProfile>();
            });
            _mapper = config.CreateMapper();
        }


        //GET api/Categorie
        [HttpGet]
        public ActionResult<IEnumerable<CategorieDTOIn>> GetAllCategorie()
        {
            IEnumerable<category> listeCategorie = _service.GetAllCategorie();
            return Ok(_mapper.Map<IEnumerable<CategorieDTOIn>>(listeCategorie));
        }

        //GET api/Categorie/{i}
        [HttpGet("{id}", Name = "GetCategorieById")]
        public ActionResult<CategorieDTOIn> GetCategorieById(int id)
        {
            category commandItem = _service.GetCategorieById(id);
            if (commandItem != null)
            {
                return Ok(_mapper.Map<CategorieDTOIn>(commandItem));
            }
            return NotFound();
        }

        //POST api/Categorie
        [HttpPost]
        public ActionResult<CategorieDTOIn> CreateCategorie(CategorieDTOIn objDTO)
        {
            var obj = _mapper.Map<category>(objDTO);
            _service.AddCategorie(obj);
            return CreatedAtRoute(nameof(GetCategorieById), new { Id = obj.IdCategorie }, obj);
        }

        //POST api/Categorie/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCategorie(int id, CategorieDTOIn obj)
        {
            category objFromRepo = _service.GetCategorieById(id);
            if (objFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(obj, objFromRepo);
            _service.UpdateCategorie(objFromRepo);
            return NoContent();
        }

        // Exemple d'appel
        // [{
        // "op":"replace",
        // "path":"",
        // "value":""
        // }]
        //PATCH api/Categorie/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCategorieUpdate(int id, JsonPatchDocument<category> patchDoc)
        {
            category objFromRepo = _service.GetCategorieById(id);
            if (objFromRepo == null)
            {
                return NotFound();
            }
            category objToPatch = _mapper.Map<category>(objFromRepo);
            patchDoc.ApplyTo(objToPatch, ModelState);
            if (!TryValidateModel(objToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(objToPatch, objFromRepo);
            _service.UpdateCategorie(objFromRepo);
            return NoContent();
        }

        //DELETE api/Categorie/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCategorie(int id)
        {
            category obj = _service.GetCategorieById(id);
            if (obj == null)
            {
                return NotFound();
            }
            _service.DeleteCategorie(obj);
            return NoContent();
        }


    }
}
