using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ImageBoard.Models;
using System.Data.Entity;

namespace ImageBoard.Data
{
    public class PostRepository : EntityRepository<Post>, IPostRepository
    {
        public PostRepository(DbContext context, bool sharedContext)
            : base(context, sharedContext) { }

        public Post GetBy(int id)
        {
            return Find(r => r.Id == id);
        }

        public IEnumerable<Post> GetFor(User user)
        {
            return user.Posts.OrderByDescending(r => r.DateCreate);
        }
        public void AddFor(Post post, User user)
        {
            user.Posts.Add(post);

            if (!ShareContext)
            {
                Context.SaveChanges();
            }
        }
    }
}