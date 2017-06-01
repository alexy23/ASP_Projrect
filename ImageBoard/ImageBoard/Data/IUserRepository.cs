using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ImageBoard.Models;

namespace ImageBoard.Data
{
    public interface IUserRepository : IRepository<User>
    {
        IQueryable<User> All(bool includeProfile);
        //void CreateFollower(string username, User follower);
        //void DeleteFollower(string username, User follower);

        User GetBy(int id, bool includeProfile = false, bool includeRibbits = false,
            bool includeFollowers = false, bool includeFollowing = false);
        User GetBy(string username, bool includeProfile = false, bool includeRibbits = false,
            bool includeFollowers = false, bool includeFollowing = false);
        User GetBy(string Name, string Password, bool includeProfile = false, bool includeRibbits = false,
            bool includeFollowers = false, bool includeFollowing = false);
    }
}