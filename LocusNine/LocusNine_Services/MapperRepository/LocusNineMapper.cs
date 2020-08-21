using AutoMapper;
using LocusNine_DAL.Models;
using LocusNine_Services.Models;
using LocusNine_Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocusNine_Services.MapperRepository
{
    public class LocusNineMapper : Profile
    {
        public LocusNineMapper()
        {
            CreateMap<UserDetail, ServiceUserDetail>();
            CreateMap<ServiceUserDetail, UserDetail>();
            CreateMap<Roles, ServiceRoles>();
            CreateMap<ServiceRoles, Roles>();
        }

    }
}
