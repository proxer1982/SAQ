﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using SAQ.Application.Dtos.Request;
using SAQ.Application.Dtos.Response;
using SAQ.Application.Interfaces;
using SAQ.Utilities.Statics;

namespace SAQ.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserApplication _userApplication;

        public UserController(IUserApplication userApplication)
        {
            _userApplication = userApplication;
        }

        [AllowAnonymous]
        [HttpPost("generate/token")]
        public async Task<IActionResult> GenerateToken([FromBody] TokenRequestDto request)
        {
            var response = await _userApplication.GenerateToken(request);

            return Ok(response);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> ListAllUser()
        {
            var response = await _userApplication.GetAllUsers(StatusType.active);
            return Ok(response);
        }

        [Authorize]
        [HttpGet("inactive")]
        public async Task<IActionResult> ListAllUserInactives()
        {
            var response = await _userApplication.GetAllUsers(StatusType.inactive);
            return Ok(response);
        }

        [Authorize]
        [HttpGet("{idUser:Guid}")]
        public async Task<IActionResult> UserById(Guid idUser)
        {
            var response = await _userApplication.GetUserById(idUser);
            return Ok(response);
        }

        [Authorize]
        [HttpGet("mail/{email}")]
        public async Task<IActionResult> UserById(string email)
        {
            var response = await _userApplication.GetUserByMail(email);
            return Ok(response);
        }

        [Authorize]
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRequestDto request)
        {
            var response = await _userApplication.RegisterUser(request);

            return Ok(response);
        }

        [Authorize]
        [HttpPut("update/{idUser:Guid}")]
        public async Task<IActionResult> UpdateUser([FromBody] UserRequestDto request, Guid idUser)
        {
            var response = await _userApplication.EditUser(idUser, request);

            return Ok(response);
        }

        [Authorize]
        [HttpDelete("delete/{idUser:Guid}")]
        public async Task<IActionResult> DeleteUser(Guid idUser)
        {
            var response = await _userApplication.RemoveUser(idUser);

            return Ok(response);
        }




        /*
        [HttpPost("list")]
        public async Task<IActionResult> GetListUser([FromBody] BaseFiltersRequest filters)
        {
            var response = await _userApplication.GetListUsers(filters);
            return Ok(response);
        }

        

        

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRequestDto requestUser)
        {
            var response = await _userApplication.RegisterUser(requestUser);
            return Ok(response);
        }

        [HttpPut("edit/{idUser:Guid}")]
        public async Task<IActionResult> EditUser(int idUser, [FromBody] UserRequestDto requestUser)
        {
            var response = await _userApplication.EditUser(idUser, requestUser);
            return Ok(response);
        }

        [HttpPut("remove/{idUser:Guid}")]
        public async Task<IActionResult> DeleteUser(int idUser)
        {
            var response = await _userApplication.RemoveUser(idUser);
            return Ok(response);
        }*/
    }
}