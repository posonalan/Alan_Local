using AutoMapper;
using GestionStockAppli.Data.Dtos;
using GestionStockAppli.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStockAppli.Data.Profiles
{
    public class TypeProduitProfile : Profile
    {
        public TypeProduitProfile()
        {
            CreateMap<typesproduit, TypeProduitDTOIn>();
            CreateMap<TypeProduitDTOIn, typesproduit>();

            CreateMap<typesproduit, TypeProduitDTOOut>();
            CreateMap<TypeProduitDTOOut, typesproduit>();
        }
    }
}
