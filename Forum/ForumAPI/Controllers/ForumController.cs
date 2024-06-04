using Forum.Contracts;
using Forum.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ForumAPI.Controllers
{
    [Route("api/forum")]
    [ApiController]
    public class ForumController : ControllerBase
    {
        private readonly IForumServices _forumServices;

        public ForumController(IForumServices forumServices) 
        {
            _forumServices = forumServices;
        }

        [HttpGet]
        public async Task<IActionResult>All()
        {
            var result = await _forumServices.GetAllAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult>Add([FromForm] ForumForAddingDto model)
        {
            await _forumServices.AddAsync(model);
            return Ok(model);
        }
    }
}
