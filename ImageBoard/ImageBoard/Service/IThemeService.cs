using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ImageBoard.Models;

namespace ImageBoard.Service
{
    public interface IThemeService
    {
        Theme GetBy(int id);
        Theme Create(int userId, string status);
        Theme Create(User user, string status);
        IEnumerable<Theme> GetTimelineFor(int userId);
    }
}