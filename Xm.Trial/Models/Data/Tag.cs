using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Xm.Trial.Models.Data
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(75)]
        public string Name { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}