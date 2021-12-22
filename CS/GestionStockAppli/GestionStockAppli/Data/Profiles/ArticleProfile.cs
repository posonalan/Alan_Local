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
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<article, ArticleDTOIn>();
            CreateMap<ArticleDTOIn, article>();

            CreateMap<article, ArticleDTOOut>();
            CreateMap<ArticleDTOOut, article>();

        }

    }
}
