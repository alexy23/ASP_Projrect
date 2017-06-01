using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ImageBoard.Models;

namespace ImageBoard.Data
{
    public interface IPostRepository : IRepository<Post>
    {
        Post GetBy(int id);
        IEnumerable<Post> GetFor(User user);
        void AddFor(Post theme, User user);
    }
}
