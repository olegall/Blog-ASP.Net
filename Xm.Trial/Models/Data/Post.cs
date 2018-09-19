using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Xm.Trial.Models.Data
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        public int AuthorId { get; set; }

        public DateTimeOffset Created { get; set; }

        public string Title { get; set; }

        public string Picture { get; set; }

        public string PictureCaption { get; set; }

        public string Text { get; set; }

        public string Snippet { get; set; }

        public int Likes { get; set; }

        [ForeignKey(nameof(AuthorId))]
        public Author Author { get; set; }

        public ICollection<Tag> Tags { get; set; }
    }
}