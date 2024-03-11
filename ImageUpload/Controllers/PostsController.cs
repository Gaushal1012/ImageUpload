using ImageUpload.Entities;
using ImageUpload.Interfaces;
using ImageUpload.Requests;
using ImageUpload.Responses;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace FileUploadApi.Controllers
{
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly SocialDbContext _context;
        private readonly ILogger<PostsController> logger;
        private readonly IPostService postService;
        public PostsController(ILogger<PostsController> logger, IPostService postService, SocialDbContext context)
        {
            this.logger = logger;
            this.postService = postService;
            _context = context;
        }
        [HttpPost]
        [Route("/posts")]
        [RequestSizeLimit(5 * 1024 * 1024)]
        public async Task<IActionResult> SubmitPost([FromForm] PostRequest postRequest)
        {
            if (postRequest == null)
            {
                return BadRequest("Invalid post request");
            }
            if (string.IsNullOrEmpty(Request.GetMultipartBoundary()))
            {
                return BadRequest("Invalid post header");
            }
            if (postRequest.Image != null)
            {
                await postService.SavePostImageAsync(postRequest);
            }
            var postResponse = await postService.CreatePostAsync(postRequest);
            if (postResponse==null)
            {
                return NotFound(postResponse);
            }
            return Ok(postResponse.Post);
        }

        [HttpGet]
        [Route("/GetPosts")]
        public async Task<IActionResult> GetPosts()
        {
            var posts = await _context.Post.ToListAsync();
            return Ok(posts);
        }

    }
}