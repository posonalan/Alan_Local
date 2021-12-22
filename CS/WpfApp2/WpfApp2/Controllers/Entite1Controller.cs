using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Data;
using WpfApp2.Data.Models;
using WpfApp2.Data.Services;

namespace WpfApp2.Controllers
{
    class Entite1Controller:ControllerBase
    {
        private readonly Entite1Service _service;
        private readonly IMapper _mapper;

        public Entite1Controller(MyDbContext context, IMapper mapper)
       {
            _service = new Entite1Service(context);
            _mapper = mapper;
        }

        
        public IEnumerable<Entite1> GetAllEntite1()
        {
            IEnumerable<Entite1> listeEntite1 = _service.GetAllEntite1();
            return listeEntite1;
        }

    }
}
