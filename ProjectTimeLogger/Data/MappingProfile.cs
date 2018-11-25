using AutoMapper;
using ProjectTimeLogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTimeLogger.Data
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Project, ChangeProjectEditModel>();
        }
    }
}
