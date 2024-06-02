using Forum.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ForumAPI.Controllers
{
    [Route("api/[controller]")]
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
    }
}
