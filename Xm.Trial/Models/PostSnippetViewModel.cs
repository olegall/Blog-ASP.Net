using System;
using Xm.Trial.Models.Data;

namespace Xm.Trial.Models
{
    public class PostSnippetViewModel : IPostViewModel
    {
        public int Id { get; set; }

        public DateTimeOffset Created { get; set; }

        public string Title { get; set; }

        public string Picture { get; set; }

        public string PictureCaption { get; set; }

        public string Snippet { get; set; }

        public Author Author { get; set; }
    }
}