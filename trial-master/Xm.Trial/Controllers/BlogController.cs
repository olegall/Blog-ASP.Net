using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Xm.Trial.Models;
using Xm.Trial.Models.Data;

namespace Xm.Trial.Controllers
{
    public class BlogController : Controller
    {
        private readonly DataContext _db = new DataContext();
        private const int postsPerScroll = 5;
        public async Task<ActionResult> Index()
        {
            var posts = await _db.Posts
                                 .Select(p => new PostSnippetViewModel
                                              {
                                                  Id = p.Id,
                                                  Created = p.Created,
                                                  Title = p.Title,
                                                  Picture = p.Picture,
                                                  PictureCaption = p.PictureCaption,
                                                  Snippet = p.Snippet,
                                                  Author = p.Author
                                              }).Take(postsPerScroll)
                                 .ToArrayAsync();

            var viewModel = new BlogViewModel
                            {
                                Title = "Posts",
                                Posts = posts
                            };

            return View(viewModel);
        }

        public async Task<ActionResult> Details(int id)
        {
            var post = await _db.Posts
                                .Select(p => new PostViewModel
                                             {
                                                 Id = p.Id,
                                                 Created = p.Created,
                                                 Title = p.Title,
                                                 Picture = p.Picture,
                                                 PictureCaption = p.PictureCaption,
                                                 Text = p.Text,
                                                 Likes = p.Likes,
                                                 Author = p.Author,
                                                 Tags = p.Tags
                                             })
                                .FirstOrDefaultAsync(p => p.Id == id);

            if (post == null)
                return new HttpNotFoundResult();

            ViewBag.Title = post.Title;

            var ids = _db.PostsStatistics.Select(x => x.PostId);
            if (ids.Contains(post.Id))
            {
                var postStatistics = _db.PostsStatistics.SingleOrDefault(x => x.PostId == post.Id);
                postStatistics.Like = post.Likes;
                postStatistics.Visit += 1;
            }
            else
            {
                PostStatistics item = new PostStatistics();
                item.PostId = post.Id;
                item.Title = post.Title;
                item.Visit = 1;
                item.Like = post.Likes;
                item.Referrer = Request.UrlReferrer.ToString();
                _db.PostsStatistics.Add(item);
            }
            await _db.SaveChangesAsync();
            return View(post);
        }

        public JsonResult GetPostsByScroll(int postsOnPage)
        {
            var posts = _db.Posts
                      .Select(p => new PostSnippetViewModel
                      {
                          Id = p.Id,
                          Created = p.Created,
                          Title = p.Title,
                          Picture = p.Picture,
                          PictureCaption = p.PictureCaption,
                          Snippet = p.Snippet,
                          Author = p.Author
                      }).ToArray().Skip(postsOnPage).Take(postsPerScroll);

            return Json(new {posts}, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _db.Dispose();

            base.Dispose(disposing);
        }
    }
}