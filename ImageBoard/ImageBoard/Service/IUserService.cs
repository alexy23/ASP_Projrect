using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ImageBoard.Models;

namespace ImageBoard.Service
{
    public interface IUserService
    {
        IEnumerable<User> All(bool includeProfile);
        //void Follow(string username, User follower);
        //void Unfollow(string username, User follower);
        User GetAllFor(int id);
        User GetAllFor(string username);
        User GetBy(int id);
        User GetBy(string username);
        User GetBy(string Name, string Password);
        User Create(string username, string password, Profile profile, DateTime? created = null);
    }
}
