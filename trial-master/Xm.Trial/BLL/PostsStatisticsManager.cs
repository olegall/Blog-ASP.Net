using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Xm.Trial.Models;
using System.Data.Entity;
using System.Threading.Tasks;
using Xm.Trial.Models.Data;

namespace Xm.Trial.BLL
{
    public class PostsStatisticsManager
    {
        private readonly DataContext _db = new DataContext();
        public async Task<List<PostsStatisticsViewModel>> GetPostsStatisticsVMs()
        {
            IEnumerable<PostStatistics> postsStatistics = await _db.PostsStatistics.ToArrayAsync();
            List<PostsStatisticsViewModel> postsStatisticsVMs = new List<PostsStatisticsViewModel>();
            foreach (PostStatistics postStatistics in postsStatistics)
            {
                postsStatisticsVMs.Add(new PostsStatisticsViewModel
                {
                    Title = postStatistics.Title,
                    Visit = postStatistics.Visit,
                    Like = postStatistics.Like,
                    Referrer = postStatistics.Referrer
                });
            }
            return postsStatisticsVMs;
        }
    }
}