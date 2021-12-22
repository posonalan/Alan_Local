using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStockAppli.Data.Models
{
    class ArticleService
    {

        private readonly MyDbContext _context;

        public ArticleService(MyDbContext context)
        {
            _context = context;
        }

        public void AddArticle(article obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _context.Articles.Add(obj);
            _context.SaveChanges();
        }

        public void DeleteArticle(article obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _context.Articles.Remove(obj);
            _context.SaveChanges();
        }
       // public article GetAllArticle()
        public IEnumerable<article> GetAllArticle()
        {/* ceci est un test*/
            return _context.Articles.ToList();
        }

        public article GetArticleById(int id)
        {
            return _context.Articles.FirstOrDefault(obj => obj.IdArticle == id);
        }

        public void UpdateArticle(article obj)
        {
            _context.SaveChanges();
        }


    }
}
