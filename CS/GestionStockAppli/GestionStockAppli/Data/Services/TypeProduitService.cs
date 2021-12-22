using GestionStockAppli.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStockAppli.Data.Services
{
    class TypeProduitService
    {


        private readonly MyDbContext _context;

        public TypeProduitService(MyDbContext context)
        {
            _context = context;
        }

        public void AddTypeProduit(typesproduit obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _context.TypesProduits.Add(obj);
            _context.SaveChanges();
        }

        public void DeleteTypeProduit(typesproduit obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _context.TypesProduits.Remove(obj);
            _context.SaveChanges();
        }

        public IEnumerable<typesproduit> GetAllTypeProduit()
        {
            return _context.TypesProduits.ToList();
        }

        public typesproduit GetTypeProduitById(int id)
        {
            return _context.TypesProduits.FirstOrDefault(obj => obj.IdTypeProduit == id);
        }

        public void UpdateTypeProduit(typesproduit obj)
        {
            _context.SaveChanges();
        }


    }
}
