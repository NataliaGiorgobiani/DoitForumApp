﻿using Forum.Contracts;
using Forum.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ForumAPI.Controllers
{
    [ApiController]
    [Route("api/forum/topic")]
    public class ForumController : ControllerBase
    {
        private readonly IForumServices _forumServices;

        public ForumController(IForumServices forumServices) 
        {
            _forumServices = forumServices;
        }

        [Authorize(Policy = "DoubleRolePolicy")]
        [HttpGet]
        public async Task<IActionResult>All()
        {
            var result = await _forumServices.GetAllAsync();
            return Ok(result);
        }

        [Authorize(Policy = "Admin")]
        [HttpPut]
        public async Task<IActionResult>Add([FromForm] ForumForAddingDto model )
        {
            await _forumServices.AddAsync(model);
            return Ok(model);
        }

        [Authorize(Policy = "Admin")]
        [HttpPost]
        public async Task<IActionResult> UpdateForum([FromForm] ForumForUpdatingDto model)
        {
            await _forumServices.UpdateAsync(model);
            return Ok(model);
        }

        [Authorize(Policy = "Admin")]
        [HttpDelete]
        public async Task<IActionResult> Delete( int id)
        {
            await _forumServices.DeleteAsync(id);
            return Ok(id);
        }

    }
}
