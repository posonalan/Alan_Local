using GestionStockAppli.Data.Dtos;
using GestionStockAppli.Data.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStockAppli.Data.Profiles
{
    public class CategorieProfile : Profile
    {
        public CategorieProfile()
        {
            CreateMap<category, CategorieDTOIn>();
            CreateMap<CategorieDTOIn, category>();

            CreateMap<category, CategorieDTOOut>();
            CreateMap<CategorieDTOOut, category>();
        }

    }
}
