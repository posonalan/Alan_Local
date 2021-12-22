using GestionStockAppli.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStockAppli.Data.Services
{
    class CategorieService
    {

        private readonly MyDbContext _context;

        public CategorieService(MyDbContext context)
        {
            _context = context;
        }

        public void AddCategorie(category obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _context.Categories.Add(obj);
            _context.SaveChanges();
        }

        public void DeleteCategorie(category obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _context.Categories.Remove(obj);
            _context.SaveChanges();
        }

        public IEnumerable<category> GetAllCategorie()
        {
            return _context.Categories.ToList();
        }

        public category GetCategorieById(int id)
        {
            return _context.Categories.FirstOrDefault(obj => obj.IdCategorie == id);
        }

        public void UpdateCategorie(category obj)
        {
            _context.SaveChanges();
        }
    }

}
