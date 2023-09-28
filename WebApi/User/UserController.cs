﻿using WebApi.User;
using Microsoft.AspNetCore.Mvc;
using DataAccessLibrary.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserModel user)
        {
            if (user == null)
            {
                return BadRequest("User model is null.");
            }

            await _userService.CreateUser(user);
            return CreatedAtAction(nameof(CreateUser), user);
        }

    }
}