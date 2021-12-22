using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Data.Models;

namespace WpfApp2.Data.Services
{
    class Entite1Service
    {

        private readonly MyDbContext _context;

        public Entite1Service(MyDbContext context)
        {
            _context = context;
        }

        public void AddEntite1(Entite1 obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _context.Entite1.Add(obj);
            _context.SaveChanges();
        }

        public void DeleteEntite1(Entite1 obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _context.Entite1.Remove(obj);
            _context.SaveChanges();
        }

        public IEnumerable<Entite1> GetAllEntite1()
        {
            return _context.Entite1.ToList();
        }

        public Entite1 GetEntite1ById(int id)
        {
            return _context.Entite1.FirstOrDefault(obj => obj.IdEntite1 == id);

         }

        public void UpdateEntite1(Entite1 obj)
        {
            _context.SaveChanges();
        }


    }
}
