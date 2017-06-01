using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ImageBoard.Models;
using ImageBoard.Data;
using System.Web.Mvc;

namespace ImageBoard.Service
{
    public class UserService : IUserService
    {
        private readonly IContext _context;
        private readonly IUserRepository _users;
        public IAuthorization Auth = new BaseMethods();
        public UserService(IContext context)
        {
            _context = context;
            _users = context.Users;
        }

        public IEnumerable<User> All(bool includeProfile)
        {
            return _users.All(includeProfile).ToArray();
        }

        //public void Follow(string username, User follower)
        //{
        //    _users.CreateFollower(username, follower);

        //    _context.SaveChanges();
        //}

        public User GetAllFor(int id)
        {
            return _users.GetBy(id,
                                includeProfile: true,
                                includeRibbits: true,
                                includeFollowers: true,
                                includeFollowing: true);
        }

        public User GetAllFor(string username)
        {
            return _users.GetBy(username,
                                includeProfile: true,
                                includeRibbits: true,
                                includeFollowers: true,
                                includeFollowing: true);
        }

        //public void Unfollow(string username, User follower)
        //{
        //    _users.DeleteFollower(username, follower);

        //    _context.SaveChanges();
        //}

        public User GetBy(int id)
        {
            return _users.GetBy(id);
        }
        public User GetBy(string Name, string Password)
        {
            return _users.GetBy(Name, Password);
        }
        public User GetBy(string username)
        {
            return _users.GetBy(username);

        }

        public User Create(string username, string password,
            Profile profile, DateTime? created = null)
        {
            profile.Email = "Test@gmail.com";
            profile.Name = "Alex";
            profile.SubName = "Busin";
            profile.Birthday = DateTime.Now;
            Role role = new Role();
            var user = new User()
            {
                UserName = username,
                Password = password,
                DateCreated = DateTime.Now,
                Profile = profile,
                RoleId = 1,
                Role = role,
                Salt = Auth.GenerateSalt()
             };

            _users.Create(user);

            _context.SaveChanges();
            //HttpResponse.Cookies["userName"].Value = "patrick";
            return user;
        }
    }
}