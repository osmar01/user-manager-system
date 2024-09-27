﻿using api_manager_user.Models;
using Microsoft.AspNetCore.Mvc;

namespace api_manager_user.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet]
        public async Task<ActionResult<List<User>>> ListAll()
        {
            List<User> users = await _userRepository.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<User>>> FindById(int id)
        {
            User user = await _userRepository.GetById(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<List<User>>> Insert([FromBody] User user)
        {
            User userModel = await _userRepository.Create(user);
            return Ok(userModel);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<User>>> Update([FromBody] User user, int id)
        {
            User userModel = await _userRepository.Update(id,user);
            return Ok(userModel);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<User>>> Delete(int id)
        {
            User userModel = await _userRepository.Delete(id);
            return Ok(userModel);
        }
    }
}
