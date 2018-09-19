using System;
using Xm.Trial.Models.Data;

namespace Xm.Trial.Models
{
    public interface IPostViewModel
    {
        Author Author { get; set; }
        DateTimeOffset Created { get; set; }
        int Id { get; set; }
        string Title { get; set; }
    }
}