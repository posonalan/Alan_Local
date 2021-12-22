using AutoMapper;
using GestionAnimaux.Data.Dtos;
using GestionAnimaux.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionAnimaux.Data.Profiles
{
    public class AnimauxProfile : Profile
    {
        public AnimauxProfile()
        {
            CreateMap<Animal, AnimauxDTO>();
            CreateMap<AnimauxDTO, Animal>();
        }


    }
}