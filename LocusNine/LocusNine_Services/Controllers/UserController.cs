using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LocusNine_DAL;
using LocusNine_Services.MapperRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using LocusNine_DAL.Models;
using LocusNine_Services.Models;
using LocusNine_Services.ServiceModels;

namespace LocusNine_Services.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly Repository _repository;
        private readonly IMapper _mapper;

        public UserController(Repository repository, IMapper mapper)
        {
            _repository=repository;
            _mapper=mapper;
        }
        // GET: api/User
        [HttpGet]
        public JsonResult GetUsers()
        {
            List<ServiceUserDetail> userList = new List<ServiceUserDetail>();
            try
            {
                var uList = _repository.GetUsers();
                if (uList != null)
                {
                    foreach (var item in uList)
                    {
                        userList.Add(_mapper.Map<ServiceUserDetail>(item));
                    }
                }

            }
            catch (Exception ex)
            {
                userList = null;
            }

            return new JsonResult(userList);
        }


        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/User
        [HttpPost]
        public JsonResult AddUser(ServiceUserDetail userDetail)
        {
            bool status = false;
            try
            {
                status = _repository.AddUser(_mapper.Map<UserDetail>(userDetail));
            }
            catch (Exception ex)
            {
                status = false;
            }
            return new JsonResult(status);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public JsonResult UpdateUser(ServiceUserDetail userDetail)
        {
            bool status = false;
            try
            {
                status = _repository.UpdateUser(_mapper.Map<UserDetail>(userDetail));
            }
            catch (Exception ex)
            {
                status = false;
            }
            return new JsonResult(status);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        public JsonResult DeleteUser(int userid)
        {
            bool status = false;
            try
            {
                status = _repository.DeleteUser(userid);
            }
            catch (Exception ex)
            {
                status = false;
            }
            return new JsonResult(status);
        }
    }
}
