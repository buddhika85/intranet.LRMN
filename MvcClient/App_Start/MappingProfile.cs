﻿using AutoMapper;
using Persistance.DomainModel;
using Persistance.ViewModels;

namespace MvcClient.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // source and destination
            Mapper.CreateMap<RegisterViewModel, ApplicationUser>();
            Mapper.CreateMap<ApplicationUser, RegisterViewModel>();
        }
    }
}