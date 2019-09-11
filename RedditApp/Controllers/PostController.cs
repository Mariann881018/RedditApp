using Microsoft.AspNetCore.Mvc;
using RedditApp.Models;
using System.Linq;

namespace RedditApp.Controllers
{
    public class PostController : Controller
    {
        private readonly ApplicationContext applicationContext;

        public PostController(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }

        [HttpGet("/")]
        public IActionResult Index()
        {
            var posts = applicationContext.Posts.OrderByDescending(p => p.Score).ToList();
            return View(posts);
        }

        [HttpGet("/Post/Add")]
        public IActionResult AddPostPage(PostInput input)
        {
            return View("Add");
        }

        [HttpPost("/Post/Add")]
        public IActionResult AddPost(PostInput input)
        {
            var post = new Post
            {
                Title = input.Title,
                Url = input.Url
            };

            applicationContext.Posts.Add(post);

            applicationContext.SaveChanges();

            return Redirect("/");
        }

        public class PostInput
        {
            public string Title { get; set; }
            public string Url { get; set; }
        }

        [HttpPost("/Post/Up")]
        public IActionResult UpvotePost(long id)
        {
            var post = applicationContext.Posts.SingleOrDefault(p => p.PostId == id);

            if (post == null)
            {
                return BadRequest();
            }

            post.Score += 1;

            applicationContext.SaveChanges();

            return Redirect("/");
        }

        [HttpPost("/Post/Down")]
        public IActionResult DownvotePost(long id)
        {
            var post = applicationContext.Posts.SingleOrDefault(p => p.PostId == id);

            if (post == null)
            {
                return BadRequest();
            }
            post.Score -= 1;

            applicationContext.SaveChanges();

            return Redirect("/");
        }

        [HttpPost("/Post/Del")]
        public IActionResult DeletePost(long id)
        {
            var post = applicationContext.Posts.SingleOrDefault(p => p.PostId == id);

            if (post == null)
            {
                return BadRequest();
            }

            applicationContext.Posts.Remove(post);

            applicationContext.SaveChanges();

            return Redirect("/");
        }
    }
}
