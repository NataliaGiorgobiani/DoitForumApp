using Azure;
using Forum.Contracts;
using Forum.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ForumAPI.Controllers
{

    
    [ApiController]
    [Route("api/forum/comment")]
    public class CommentController : ControllerBase
    {
        private readonly IForumServices _forumServices;

        public CommentController(IForumServices forumServices)
        {
            _forumServices = forumServices;
        }

        [Authorize(Policy = "DoubleRolePolicy")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _forumServices.GetAllCommentsAsync();
            return Ok(result);
        }
       

        [Authorize(Policy = "DoubleRolePolicy")]
        [HttpPut]
        public async Task<IActionResult> AddComment([FromForm] CommentForAddingDto model)
        {
            await _forumServices.AddCommentAsync(model);
            return Ok(model);
        }

          [Authorize(Policy = "DoubleRolePolicy")]
           [HttpPost]
           public async Task<IActionResult> UpdateComment([FromRoute] CommentForUpdatingDto model)
           {
               await _forumServices.UpdateCommentAsync(model);
               return Ok(model);


           }

           [Authorize(Policy = "Admin")]
           [HttpDelete]
            public async Task<IActionResult> Delete(int  id) 
             {
                await _forumServices.DeleteCommentAsync(id);
                return Ok(id);
             }
        
    }

   
}
