using AutoMapper;
using GestionAnimaux.Data.Dtos;
using GestionAnimaux.Data.Models;
using GestionAnimaux.Data.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionAnimaux.Controllers
{

    [Route("api/Alimentation")]
    [ApiController]
    public class AlimentationsController : ControllerBase 
    {
        /* il va chercher alimentation service  */ 
        private readonly AlimentationsService _service;
        /* il fait correspondre ( mapper ) */ 
        private readonly IMapper _mapper;

        /* Constructeur */ 
        public AlimentationsController(AlimentationsService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper; 
        }

        [HttpGet]
        /* fonction getAllAliment =>  va chercher tout les aliments */ 
        public ActionResult<IEnumerable<AlimentationsDTO>> GetAllAliment()
        { /* liste des aliments */ 
            IEnumerable<Aliment> listeAliment = _service.GetAllAliment();
            /* affichage du resultat de la correspondance */ 
            return Ok(_mapper.Map<IEnumerable<AlimentationsDTO>>(listeAliment));
        }

 
    }
}
