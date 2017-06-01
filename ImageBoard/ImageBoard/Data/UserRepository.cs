using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ImageBoard.Models;
using System.Data.Entity;

namespace ImageBoard.Data
{
    public class UserRepository : EntityRepository<User>, IUserRepository
    {
        public UserRepository(DbContext context, bool sharedContext) : base(context, sharedContext) { }

        public IQueryable<User> All(bool includeProfile)
        {
            return includeProfile ? DbSet.Include(u => u.Profile).AsQueryable() : All();
        }

        public void CreateFollower(string username, User follower)
        {
            var user = GetBy(username);
            DbSet.Attach(follower);

            user.Followers.Add(follower);

            if (!ShareContext)
            {
                Context.SaveChanges();
            }
        }

        public void DeleteFollower(string username, User follower)
        {
            var user = GetBy(username);
            DbSet.Attach(follower);

            user.Followers.Remove(follower);

            if (!ShareContext)
            {
                Context.SaveChanges();
            }
        }

        public User GetBy(int id, bool includeProfile = false, bool includeRibbits = false,
            bool includeFollowers = false, bool includeFollowing = false)
        {
            var query = BuildUserQuery(includeProfile, includeRibbits, includeFollowers, includeFollowing);

            return query.SingleOrDefault(u => u.Id == id);
        }
        public User GetBy(string Name, string Password, bool includeProfile = false, bool includeRibbits = false,
            bool includeFollowers = false, bool includeFollowing = false)
        {
            var query = BuildUserQuery(includeProfile, includeRibbits, includeFollowers, includeFollowing);

            return query.SingleOrDefault(u => u.UserName == Name && u.Password == Password);
        }

        private IQueryable<User> BuildUserQuery(bool includeProfile, bool includeRibbits, bool includeFollowers, bool includeFollowing)
        {
            var query = DbSet.AsQueryable();

            if (includeProfile)
                query = DbSet.Include(u => u.Profile);

            if (includeRibbits)
                query = DbSet.Include(u => u.Themes);

            if (includeFollowers)
                query = DbSet.Include(u => u.Posts);

            if (includeFollowing)
                query = DbSet.Include(u => u.Role);
            return query;
        }

        public User GetBy(string username, bool includeProfile = false, bool includeRibbits = false,
            bool includeFollowers = false, bool includeFollowing = false)
        {
            var query = BuildUserQuery(includeProfile, includeRibbits, includeFollowers, includeFollowing);

            return query.SingleOrDefault(u => u.UserName == username);

        }
    }
}