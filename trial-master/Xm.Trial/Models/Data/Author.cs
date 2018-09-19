using System;
using System.ComponentModel.DataAnnotations;

namespace Xm.Trial.Models.Data
{
    public class Author
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(150)]
        public string Name { get; set; }

        [MaxLength(400)]
        public string Avatar { get; set; }

        public DateTimeOffset Registered { get; set; }
    }
}