
using GestionStockAppli.Data.Dtos;
using GestionStockAppli.Data.Models;
using GestionStockAppli.Data.Profiles;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;

using GestionStockAppli.Data.Services;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace GestionStockAppli.Data.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    class ArticleController : ControllerBase
    {


        private readonly ArticleService _service;
        private readonly IMapper _mapper;

        public ArticleController(MyDbContext _context)
        {
            _service = new ArticleService(_context);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ArticleProfile>();
            });
            _mapper = config.CreateMapper();
        }

        //GET api/Article
        //[HttpGet]
        public ActionResult<IEnumerable<ArticleDTOIn>> GetAllArticle()
       // public IEnumerable<article> GetAllArticle()
        {
            IEnumerable<article> listeArticle = _service.GetAllArticle();
            return Ok(_mapper.Map<IEnumerable<ArticleDTOIn>>(listeArticle));
            //return listeArticle;
        }


        /****************************************************************************/
        //GET api/Article/{i}
        [HttpGet("{id}", Name = "GetArticleById")]
        public ActionResult<ArticleDTOIn> GetArticleById(int id)
        {
            article commandItem = _service.GetArticleById(id);
            if (commandItem != null)
            {
                return Ok(_mapper.Map<ArticleDTOIn>(commandItem));
            }
            return NotFound();
        }

        //POST api/Article
        [HttpPost]
        public ActionResult<ArticleDTOIn> CreateArticle(article obj)
        {
            _service.AddArticle(obj);
            return CreatedAtRoute(nameof(GetArticleById), new { Id = obj.IdArticle }, obj);
        }

        //POST api/Article/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateArticle(int id, ArticleDTOIn obj)
        {
            article objFromRepo = _service.GetArticleById(id);
            if (objFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(obj, objFromRepo);
            _service.UpdateArticle(objFromRepo);
            return NoContent();
        }

        // Exemple d'appel
        // [{
        // "op":"replace",
        // "path":"",
        // "value":""
        // }]
        //PATCH api/Article/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialArticleUpdate(int id, JsonPatchDocument<article> patchDoc)
        {
            article objFromRepo = _service.GetArticleById(id);
            if (objFromRepo == null)
            {
                return NotFound();
            }
            article objToPatch = _mapper.Map<article>(objFromRepo);
            patchDoc.ApplyTo(objToPatch, ModelState);
            if (!TryValidateModel(objToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(objToPatch, objFromRepo);
            _service.UpdateArticle(objFromRepo);
            return NoContent();
        }

        //DELETE api/Article/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteArticle(int id)
        {
            article obj = _service.GetArticleById(id);
            if (obj == null)
            {
                return NotFound();
            }
            _service.DeleteArticle(obj);
            return NoContent();
        }


    }
}
