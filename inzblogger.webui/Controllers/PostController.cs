using blogger.Models;
using blogger.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace inzblogger.webui.Controllers
{
    public class PostController : Controller
    {
        private readonly IPost _post;
        private readonly IUserAccount _account;
        public PostController(IPost post, IUserAccount account)
        {
            _post = post;
            _account = account;
        }
        [Admin]
        [HttpGet]
        public IActionResult Posts()
        {
            return View(_post.GetPosts);
        }
        [Admin]
        [HttpGet]
        public IActionResult DetailPost(int id = 0)
        {
            return View(_post.GetPost(id));
        }
        [Admin]
        [HttpGet]
        public IActionResult Categories()
        {
            return View(_post.GetCategories());
        }
        [Admin]
        [HttpGet]
        public IActionResult AddUpdateCategory(int id = 0)
        {
            return View(_post.GetCategory(id));
        }
        [Admin]
        [HttpPost]
        public IActionResult AddUpdateCategory(Category category)
        {
            _post.AddupdateCategory(category);
            return RedirectToAction("Categories");
        }
        [Admin]
        [HttpGet]
        public IActionResult DeleteCategory(int id)
        {
            _post.DetachCategory(id);
            return RedirectToAction("Categories");
        }
        [Admin]
        [HttpGet]
        public IActionResult PostStatuses()
        {
            return View(_post.GetPostStatuses());
        }
        [Admin]
        [HttpGet]
        public IActionResult AddUpdatePostStatus(int id = 0)
        {
            return View(_post.GetPostStatus(id));
        }
        [Admin]
        [HttpPost]
        public IActionResult AddUpDatePostStatus(PostStatus postStatus)
        {
            _post.AddUpDatePostStatus(postStatus);
            return RedirectToAction("PostStatuses");
        }
        [Admin]
        [HttpGet]
        public IActionResult DeletePostStatus(int id)
        {
            _post.DeletePostStatus(id);
            return RedirectToAction("PostStatuses");
        }
        [HttpGet]
        public IActionResult CreatePost()
        {
            ViewBag.PostStatus = new SelectList(_post.GetPostStatuses().ToList(), "Id", "Name");
            ViewBag.Categories = new SelectList(_post.GetCategories().ToList(), "Id", "Name");
            return View(new Post());
        }
        [HttpPost]
        public IActionResult CreatePost(Post post,IFormFile PostImage: )
        {
            string imagePath = "";

            var extension = "";

            IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".jpeg", ".png" };

            int maxContentLength = 1024 * 1024 * 10; // 10 Mb

            return View();
        }
        [HttpGet]
        public IActionResult UpdatePost(int id = 0)
        {
            ViewBag.PostStatus = new SelectList(_post.GetPostStatuses().ToList(), "Id", "Name");
            ViewBag.Categories = new SelectList(_post.GetCategories().ToList(), "Id", "Name");
            return View(_post.GetPost(id));
        }

        [HttpPost]
        public IActionResult UpdatePost(Post post)
        {
            _post.UpdatePost(post);
            return RedirectToAction("Posts");
        }
        [HttpGet]
        public IActionResult DeletePost(int id)
        {
            _post.DeletePost(id);
            return RedirectToAction("Posts");

        }
        //-----reaction type----
        [Admin]
        [HttpGet]
        public IActionResult ReactionTypes()
        {
            return View(_post.GetReactionTypes());
        }

        [Admin]
        [HttpGet]
        public IActionResult AddUpdateReactionType(int id = 0)
        {
            return View(_post.GetPostStatus(id));
        }

        [Admin]
        [HttpPost]
        public IActionResult AddUpdateReactionType(ReactionType reactionType)
        {
            _post.AddUpdateReactionType(reactionType);
            return RedirectToAction("ReactionTypes");
        }

        [Admin]
        [HttpGet]
        public IActionResult DeleteReactionType(int id)
        {
            _post.DeleteReactionType(id);
            return RedirectToAction("ReactionTypes");
        }
        // ------------------------- Post Reaction
        [Admin]
        [HttpGet]
        public IActionResult PostReactions()
        {
            return View(_post.GetPostReactions());
        }

        [Admin]
        [HttpGet]
        public IActionResult GetPostReaction(int id = 0)
        {
            return View(_post.GetPostReaction(id));
        }

        [Admin]
        [HttpGet]
        public IActionResult CreatePostReaction()
        {
            ViewBag.Posts = new SelectList(_post.GetPosts.ToList(), "Id", "Title");
            ViewBag.Reactions = new SelectList(_post.GetReactionTypes().ToList(), "Id", "Name");
            return View(new PostReaction());
        }

        [Admin]
        [HttpPost]
        public IActionResult CreatePostReaction(PostReaction postReaction)
        {
            User user = new CommonController(_account).GetUser(HttpContext);
            postReaction.UserId = user.Id;
            _post.CreatePostReaction(postReaction);
            return RedirectToAction("PostReactions");
        }

        [Admin]
        [HttpGet]
        public IActionResult UpdatePostReaction(int id = 0)
        {
            ViewBag.Posts = new SelectList(_post.GetPosts.ToList(), "Id", "Title");
            ViewBag.Reactions = new SelectList(_post.GetReactionTypes().ToList(), "Id", "Name");
            return View(_post.GetPostReaction(id));
        }

        [Admin]
        [HttpPost]
        public IActionResult UpdatePostReaction(PostReaction postReaction)
        {
            _post.UpdatePostReaction(postReaction);
            return RedirectToAction("PostReactions");
        }

        [Admin]
        [HttpGet]
        public IActionResult DeletePostReaction(int id)
        {
            _post.DeletePostReaction(id);
            return RedirectToAction("PostReactions");

        }
    }
}
