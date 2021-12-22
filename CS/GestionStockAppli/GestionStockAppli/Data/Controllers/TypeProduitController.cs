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
    class TypeProduitController : ControllerBase
    {


        private readonly TypeProduitService _service;
        private readonly IMapper _mapper;

        public TypeProduitController(MyDbContext _context)
        {
            _service = new TypeProduitService(_context);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<TypeProduitProfile>();
            });
            _mapper = config.CreateMapper();
        }


        //GET api/TypesProduits
        [HttpGet]
        public ActionResult<IEnumerable<TypeProduitDTOIn>> GetAllTypeProduit()
        {
            IEnumerable<typesproduit> listeTypesProduits = _service.GetAllTypeProduit();
            return Ok(_mapper.Map<IEnumerable<TypeProduitDTOIn>>(listeTypesProduits));
        }

        //GET api/TypesProduits/{i}
        [HttpGet("{id}", Name = "GetTypesProduitsById")]
        public ActionResult<TypeProduitDTOIn> GetTypeProduitById(int id)
        {
            typesproduit commandItem = _service.GetTypeProduitById(id);
            if (commandItem != null)
            {
                return Ok(_mapper.Map<TypeProduitDTOIn>(commandItem));
            }
            return NotFound();
        }

        //POST api/TypesProduits
        [HttpPost]
        public ActionResult<TypeProduitDTOIn> CreateTypeProduit(typesproduit obj)
        {
            _service.AddTypeProduit(obj);
            return CreatedAtRoute(nameof(GetTypeProduitById), new { Id = obj.IdTypeProduit }, obj);
        }

        //POST api/TypesProduits/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateTypeProduit(int id, TypeProduitDTOIn obj)
        {
            typesproduit objFromRepo = _service.GetTypeProduitById(id);
            if (objFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(obj, objFromRepo);
            _service.UpdateTypeProduit(objFromRepo);
            return NoContent();
        }

        // Exemple d'appel
        // [{
        // "op":"replace",
        // "path":"",
        // "value":""
        // }]
        //PATCH api/TypesProduits/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialTypesProduitsUpdate(int id, JsonPatchDocument<typesproduit> patchDoc)
        {
            typesproduit objFromRepo = _service.GetTypeProduitById(id);
            if (objFromRepo == null)
            {
                return NotFound();
            }
            typesproduit objToPatch = _mapper.Map<typesproduit>(objFromRepo);
            patchDoc.ApplyTo(objToPatch, ModelState);
            if (!TryValidateModel(objToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(objToPatch, objFromRepo);
            _service.UpdateTypeProduit(objFromRepo);
            return NoContent();
        }

        //DELETE api/TypesProduits/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteTypeProduit(int id)
        {
            typesproduit obj = _service.GetTypeProduitById(id);
            if (obj == null)
            {
                return NotFound();
            }
            _service.DeleteTypeProduit(obj);
            return NoContent();
        }


    }
}
