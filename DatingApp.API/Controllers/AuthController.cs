
using DatingApp.API.Data;
using DatingApp.API.DTO;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController: ControllerBase
    {
        private readonly IAuthRepository repo;
        public AuthController(IAuthRepository repo)
        {
            this.repo = repo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegister)
        {
            userForRegister.username = userForRegister.username.ToLower();
            if (await repo.UserExist(userForRegister.username))
            {
                return BadRequest("Username already exist");
            }
            var userToCreate = new User
            {
                Name = userForRegister.username
            };

            var userCreated = await repo.Register(userToCreate, userForRegister.password);

            return StatusCode(201);

        }
    }
}
