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
    class GroupeProfile : Profile
    {
        public GroupeProfile()
        {
            CreateMap<Groupe, GroupesDTOIn>();
            CreateMap<GroupesDTOIn, Groupe>();
            CreateMap<Groupe, GroupesDTOOut>();
            CreateMap<GroupesDTOOut, Groupe>();
        }
    }
}
