﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyAuthServer.Core.Dtos;
using UdemyAuthServer.Core.Services;

namespace UdemyAuthServer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : CustomBaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDto createUserDto)
        {
            var result = await _userService.CreateUserAsync(createUserDto);
            return ActionResultInstance(result);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUser()
        {
            return ActionResultInstance(await _userService.GetUserByNameAsync(HttpContext.User.Identity.Name));
        }
    }
}
