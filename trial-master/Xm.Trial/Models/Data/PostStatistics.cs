using System;
using System.ComponentModel.DataAnnotations;

namespace Xm.Trial.Models.Data
{
    public class PostStatistics
    {
        [Key]
        public int Id { get; set; }

        public int PostId { get; set; }

        public string Title { get; set; }

        public int Visit { get; set; }

        public int Like { get; set; }

        public string Referrer { get; set; }
    }
}