using GestionAnimaux.Data.Dtos;
using GestionAnimaux.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GestionAnimaux.Data.Services
{
    public class AnimauxService
    {
        /* ***** Propriété ***** */
        private readonly MyDbContext _context; /* _context au format MyDbContext */

        /* ***** Constructeur ***** */
        public AnimauxService(MyDbContext context)
        {
            _context = context;
        }

        /* GetAllAnimal presente tout les animaux */ 
        public IEnumerable<Animal> GetAllAnimal()
        {
            var liste = (from animal in _context.Animaux
                         join aliment in _context.Alimentation
                         on animal.IdAliment equals aliment.IdAliment
                         select new Animal
                         {
                             IdAnimal = animal.IdAnimal,
                             Nom = animal.Nom,
                             IdAliment = aliment.IdAliment,
                             Aliment = aliment
                         }).ToList();
            return liste;
        }
        /* fonction permettant de selectionner un animal par rapport a son id */
        public Animal GetAnimalById(int id)
        {
            var unAnimal = (from animal in _context.Animaux
                         join aliment in _context.Alimentation
                         on animal.IdAliment equals aliment.IdAliment
                         select new Animal
                         {
                             IdAnimal = animal.IdAnimal,
                             Nom = animal.Nom,
                             IdAliment = aliment.IdAliment,
                             Aliment = aliment
                         }).FirstOrDefault(p => p.IdAnimal == id);
             return unAnimal;
        }




        /* Fonction ajout de un Animal */
        public void AddAnimal(AnimauxDTOIn p) /* le p est au format animaux */
        {/* si le p est null 'vide' on genere une erreur et on la montre */
            if (p == null) 
            { 
                throw new ArgumentNullException(nameof(p));
            } /* on cree un nouvelle objet et on le remplie */ 
            var ani = new Animal()
            {
                Nom = p.Nom,
                IdAliment = p.IdAliment
            };
            /* ajout du p et sauvegarde */
            _context.Add(ani);
            
            _context.SaveChanges(); 
        }

        /* fonction de suppression d'un Animal , pauvre Bete :'( */
        public void DeleteAnimal(Animal p)
        { //si l'objet Animal est null, on renvoi une exception
            if (p == null) { throw new ArgumentNullException(nameof(p)); }
            // on met à jour le context
            _context.Animaux.Remove(p);
            _context.SaveChanges();
        }

        ///* fonction get liste : affichage de la liste */
        //public IEnumerable<Animal> GetAllAnimal()
        //{
        //    return _context.Animaux.ToList();
        //}
        /* fonction getById : chercher par id */
        //public Animal GetAnimalById(int id)
        //{ /* first le premier ou celui par default */
        //    return _context.Animaux.FirstOrDefault(p => p.IdAnimal == id);
        //}

        /* mise a jour de l'animal */ 
        public void UpdateAnimal(Animal p)
        { /* si vide ... */
           if (p == null)
            {
                throw new ArgumentNullException(nameof(p)); 
            }
           /* cree et remplie */ 
            var ani = new Animal()
            {
                IdAnimal = p.IdAnimal,
                Nom = p.Nom,
                IdAliment = p.IdAliment,
            };
            /* MAJ et Save */ 
            _context.Update(p);
            _context.SaveChanges();

           }
        }




    }

