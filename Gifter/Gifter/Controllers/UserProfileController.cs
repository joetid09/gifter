﻿using Gifter.Models;
using Gifter.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gifter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserProfileRepository _userProfileRepo;
        public UserProfileController(IUserProfileRepository userProfileRepo)
        {
            _userProfileRepo = userProfileRepo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_userProfileRepo.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_userProfileRepo.GetById(id));
        }

        [HttpPost]
        public IActionResult Post(UserProfile profile)
        {
            _userProfileRepo.AddProfile(profile);
            return CreatedAtAction("Get", new { id = profile.Id }, profile);

        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UserProfile profile)
        {
           if(id != profile.Id)
            {
                return BadRequest();    
            }

            _userProfileRepo.Update(profile);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userProfileRepo.Delete(id);
            return NoContent();
        }
    }
}
