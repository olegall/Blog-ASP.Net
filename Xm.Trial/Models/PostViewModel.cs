using System;
using System.Collections.Generic;
using Xm.Trial.Models.Data;

namespace Xm.Trial.Models
{
    public class PostViewModel : IPostViewModel
    {
        public int Id { get; set; }

        public DateTimeOffset Created { get; set; }

        public string Title { get; set; }

        public string Picture { get; set; }

        public string PictureCaption { get; set; }

        public string Text { get; set; }

        public int Likes { get; set; }

        public Author Author { get; set; }

        public ICollection<Tag> Tags { get; set; }
    }
}