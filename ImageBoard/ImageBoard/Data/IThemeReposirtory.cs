using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ImageBoard.Models;

namespace ImageBoard.Data
{
    public interface IThemeRepository : IRepository<Theme>
    {
        Theme GetBy(int id);
        IEnumerable<Theme> GetFor(User user);
        void AddFor(Theme theme, User user);
    }
}
