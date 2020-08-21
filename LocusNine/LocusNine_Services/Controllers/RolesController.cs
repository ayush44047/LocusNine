using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LocusNine_DAL;
using LocusNine_Services.ServiceModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LocusNine_Services.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly Repository _repository;
        private readonly IMapper _mapper;

        public RolesController(Repository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/Roles
        [HttpGet]
        public JsonResult GetRoles()
{
        
        List<ServiceRoles> roleList = new List<ServiceRoles>();
            try
            {
                var rList = _repository.GetRoles();
                if (rList != null)
                {
                    foreach (var item in rList)
                    {
                        roleList.Add(_mapper.Map<ServiceRoles>(item));
                    }
                }

            }
            catch (Exception)
            {
                roleList = null;
            }

            return new JsonResult(roleList);
        }

    }
}
