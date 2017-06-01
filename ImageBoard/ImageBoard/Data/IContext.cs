using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImageBoard.Data
{
    public interface IContext : IDisposable
    {
        IUserRepository Users { get; }
        IThemeRepository Themes { get; }
        IProfileRepository Profiles { get; }
        IPostRepository Posts { get; }

        int SaveChanges();
    }
}