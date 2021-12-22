using GestionAnimaux.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionAnimaux.Data.Services
{
    public class AlimentationsService
    {


       
            private readonly MyDbContext _context;

            public AlimentationsService(MyDbContext context)
            {
                _context = context;

            }


            public IEnumerable<Aliment> GetAllAliment()
            {
                return _context.Alimentation.ToList();
            }
        
    }
}
