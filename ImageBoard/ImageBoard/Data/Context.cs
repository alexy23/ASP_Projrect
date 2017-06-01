using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ImageBoard.Models;
using System.Data.Entity.Validation;
using System.Text;

namespace ImageBoard.Data
{
    public class Context : IContext
    {
        private readonly DbContext _db;

        public Context(DbContext context = null, IUserRepository users = null,
            IThemeRepository themes = null, IProfileRepository profiles = null, IPostRepository posts = null)
        {
            _db = context ?? new MainContext();
            Users = users ?? new UserRepository(_db, true);
            Themes = themes ?? new ThemeRepository(_db, true);
            Profiles = profiles ?? new ProfileRepository(_db, true);
            Posts = posts ?? new PostRepository(_db, true);
        }

        public IUserRepository Users { get; private set; }

        public IThemeRepository Themes { get; private set; }

        public IProfileRepository Profiles { get; private set; }

        public IPostRepository Posts { get; private set; }

        public int SaveChanges()
        {
            return _db.SaveChanges();
        }

        public void Dispose()
        {
            if (_db != null)
            {
                try
                {
                    _db.Dispose();
                }
                catch { }
            }
        }
    }
}