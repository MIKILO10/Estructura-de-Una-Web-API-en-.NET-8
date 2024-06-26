﻿using Estructura.Software.Web.API.Domain.Entities;
using Estructura.Software.Web.Application.Application.Interfaces.IUsers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Estructura.Software.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ICreateUserService _createUserServices;
        private readonly IGetAllUserService _getAllUserService;
        private readonly IDeleteUserService _deleteUserServices;
        private readonly IGetUserService _getUserService;
        private readonly IUpdateEmailService _updateEmailService;


        public UserController(ICreateUserService createUserServices, IGetAllUserService getAllUserService, IDeleteUserService deleteUserServices, IGetUserService getUserService, IUpdateEmailService updateEmailService)
        {
            _createUserServices = createUserServices;
            _getAllUserService = getAllUserService;
            _deleteUserServices = deleteUserServices;
            _getUserService = getUserService;
            _updateEmailService = updateEmailService;
        }


        [HttpPost]
        public IActionResult Create([FromBody] User user)
        {
            return Ok(_createUserServices.Create(user));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_getAllUserService.GetAll());
        }

        [HttpDelete]
        public IActionResult Delete(string name)
        {
            return Ok(_deleteUserServices.delete(name));
        }


        [HttpGet("{name}")]
        public IActionResult Get(string name)
        {
            return Ok(_getUserService.Get(name));
        }

        [HttpPut]
        public IActionResult UpdateEmail(string name, string email)
        {
            return Ok(_updateEmailService.UpdateEmail(name, email));
        }
    }
}
