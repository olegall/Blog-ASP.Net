using System.Collections.Generic;

namespace Xm.Trial.Models
{
    public class BlogViewModel
    {
        public string Title { get; set; }
        public ICollection<PostSnippetViewModel> Posts { get; set; }
    }
}