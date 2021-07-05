using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TestPOCWebApp.Models;

namespace TestPOCWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static readonly List<UserDetail> Data = new List<UserDetail>
        {
            new UserDetail{ UserId = "1", FirstName ="Tom", LastName="Cruise",Role="Actor",Location="New York",IsActive=true},
            new UserDetail{ UserId = "2", FirstName ="Chris", LastName="Pratt",Role="Actor",Location="Virginia",IsActive=true},
            new UserDetail{ UserId = "3", FirstName ="Jennifer ", LastName="Ann",Role="Actress",Location="California",IsActive=true},
            new UserDetail{ UserId = "4", FirstName ="Ross", LastName="Geller",Role="Actor",Location="New York",IsActive=true},
            new UserDetail{ UserId = "5", FirstName ="Rachel", LastName="Green",Role="Actress",Location="New York",IsActive=false}
        };

        public UserController()
        {
        }

        [HttpGet]
        [Route("GetAll")]
        public IList<UserDetail> Get()
        {
            return Data;
        }

        [HttpPost]
        [Route("Create")]
        public UserDetail Post(UserDetail model)
        {
            Data.Add(model);
            return model;
        }

    }
}
