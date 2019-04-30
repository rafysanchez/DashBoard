﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sow.Automation.Dashboard.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(ps => {

                ps.AddProfile(new DomainToViewModelMappingProfile());
                ps.AddProfile(new ViewModelToDomainMappingProfile());

            });
        }
    }
}
