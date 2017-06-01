using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ImageBoard.Data;
using ImageBoard.Models;

namespace ImageBoard.Service
{
    public class ThemeService : IThemeService
    {
        private readonly IContext _context;
        private readonly IThemeRepository _themes;

        public ThemeService(IContext context)
        {
            _context = context;
            _themes = context.Themes;
        }

        public Theme GetBy(int id)
        {
            return _themes.GetBy(id);
        }

        public Theme Create(User user, string status)
        {
            return Create(user.Id, status);
        }

        public Theme Create(int userId, string Status)
        {
            var theme = new Theme()
            {
                UserId = userId,
                ThemeBody = Status,
                DateCreated = DateTime.Now

            };

            _themes.Create(theme);

            _context.SaveChanges();

            return theme;
        }

        public IEnumerable<Theme> GetTimelineFor(int userId)
        {
            return _themes.FindAll(r => r.User.Followers.Any(f => f.Id == userId) || r.UserId == userId)
                .OrderByDescending(r => r.DateCreated);
        }
    }
}