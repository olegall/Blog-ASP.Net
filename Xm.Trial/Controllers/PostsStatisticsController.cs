using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Xm.Trial.Models;
using Xm.Trial.Models.Data;
using System.Collections.Generic;
using Xm.Trial.BLL;

namespace Xm.Trial.Controllers
{
    public class PostsStatisticsController : Controller
    {
        private readonly DataContext _db = new DataContext();

        public async Task<ActionResult> Index()
        {
            IEnumerable<PostsStatisticsViewModel> postsStatisticsVMs = await new PostsStatisticsManager().GetPostsStatisticsVMs();
            return View(postsStatisticsVMs);
        }

        public async Task<ActionResult> OrderBy(string property)
        {
            IEnumerable<PostsStatisticsViewModel> postsStatisticsVMs = await new PostsStatisticsManager().GetPostsStatisticsVMs();
            switch (property)
            {
                case "Title": return View("Index", postsStatisticsVMs.OrderBy(x => x.Title).ToList());
                case "Visit": return View("Index", postsStatisticsVMs.OrderBy(x => x.Visit).ToList());
                case "Like": return View("Index", postsStatisticsVMs.OrderBy(x => x.Like).ToList());
                case "Referrer": return View("Index", postsStatisticsVMs.OrderBy(x => x.Referrer).ToList());
            }
            return View("Index", postsStatisticsVMs);
        }
    }
}