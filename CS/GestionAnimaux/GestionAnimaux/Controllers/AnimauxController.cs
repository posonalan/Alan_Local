using AutoMapper;
using GestionAnimaux.Data.Dtos;
using GestionAnimaux.Data.Models;
using GestionAnimaux.Data.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionAnimaux.Controllers
{

    /* définit la route qui mènera à cette classe */
    [Route("api/Animaux")]
    [ApiController]

    public class AnimauxController : ControllerBase
    {
        /* le service amené par le constructeur */
        private readonly AnimauxService _service;
        /* le mapper amené par le constructeur */
        private readonly IMapper _mapper;

        /* ********** */

        /* Constructeur */
        public AnimauxController(AnimauxService service, IMapper mapper)

        {
            _service = service; _mapper = mapper;
        }

        /* ********** */

        //GET api/Animaux
        [HttpGet] /* Précise le chemin qui amènera à cette méthode */
        public ActionResult<IEnumerable<AnimauxDTO>> GetAllAnimal()
        {
            var listeAnimaux = _service.GetAllAnimal();
            return Ok(_mapper.Map<IEnumerable<AnimauxDTO>>(listeAnimaux));
        }

        /* ********** */

        ///* GET api/Animaux/{id} */
        [HttpGet("{id}", Name = "GetAnimalById")]
        /* fonction de selection d'un animal par rapport a son id */ 
        public ActionResult<AnimauxDTO> GetAnimalById(int id)
        { /* on va chercher la fonction dans le service */ 
            var commandItem = _service.GetAnimalById(id);
            /* si different de vide */ 
            if (commandItem != null)
            { /* retour de l'objet rechercher */
                return Ok(_mapper.Map<AnimauxDTO>(commandItem));
            }
            return NotFound();
        }

        /* ********** */

        /* POST api/Animaux */
        [HttpPost]
        /* fonction de creation d'animaux */
        public ActionResult CreateAnimaux(AnimauxDTOIn animal)
        {
            //on ajoute l’objet à la base de données
            _service.AddAnimal(animal); //on retourne le chemin de findById avec l'objet créé
            //return CreatedAtRoute(nameof(GetAnimalById), new { Id = animal.IdAnimal }, animal);
            return NoContent();
        }

        /* ********** */

        //PUT api/Animaux/{id}
        [HttpPut("{id}")]
        /* fonction de mise a jour de l'animal */
        public ActionResult UpdateAnimal(int id, AnimauxDTO animal)
        { /* prendre les personne de service par leur id */
            var animalFromRepo = _service.GetAnimalById(id);
            /* On récupère l’objet en base, s’il n’existe pas, on renvoi une erreur. */
            if (animalFromRepo == null)
            { /* on retourne pas remplis */
                return NotFound();
            }

            /* On propage les modifications grâce au mapper. */
            _mapper.Map(animal, animalFromRepo);

            // inutile puisque la fonction ne fait rien, mais garde la cohérence
            /* On persiste les données. */
            _service.UpdateAnimal(animalFromRepo);

            return NoContent();
        }

        /* ********** */

        /* ********** */

        /*PATCH api/Animaux/{id} */

        //[HttpPatch("{id}")]
        /* Modifier qu'une partie de l'objet */
        //public ActionResult PartialAnimauxUpdate(int id, JsonPatchDocument<Animal> patchDoc)
        //{
        //    /* On précise l’id dans l’URL, on passe les instructions de modification en POST */
        //    var animalFromRepo = _service.GetAnimalById(id);
        //    /* On récupère l’objet en base, s’il n’existe pas, on renvoi une erreur. */
        //    if (animalFromRepo == null)
        //    {
        //        return NotFound();
        //    }
        //    /* On vérifie que les modifications sont cohérentes */
        //    var animalToPatch = _mapper.Map<Animal>(animalFromRepo);
        //    patchDoc.ApplyTo(animalToPatch, ModelState);
        //    if (!TryValidateModel(animalToPatch))
        //    {
        //        return ValidationProblem(ModelState);
        //    } /* On propage les modifications grâce au mapper. */
        //    _mapper.Map(animalToPatch, animalFromRepo);
        //    /* On persiste les données. */
        //    _service.UpdateAnimal(animalFromRepo);
        //    return NoContent();
        //}

        /* ********** */

        //DELETE api/Animaux/{id}
        //[HttpDelete("{id}")]
        /* fonction de suppression */
        //public ActionResult DeleteAnimal(int id)
        //{
        //    var animalModelFromRepo = _service.GetAnimalById(id);
        //    if (animalModelFromRepo == null)
        //    {
        //        return NotFound();
        //    }
        //    _service.DeleteAnimal(animalModelFromRepo);
        //    return NoContent();


    }
}