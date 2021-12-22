using AutoMapper;
using ECF.Data.Dtos;
using ECF.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECF.Data.Profiles
{
    class MusicienProfile : Profile
    {
        public MusicienProfile()
        {
            CreateMap<Musicien, MusiciensDTOIn>();
            CreateMap<MusiciensDTOIn, Musicien>();
            CreateMap<Musicien, MusiciensDTOOut>();
            CreateMap<MusiciensDTOOut, Musicien>();
        }
    }
}
