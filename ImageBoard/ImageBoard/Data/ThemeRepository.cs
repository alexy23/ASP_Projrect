using ImageBoard.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ImageBoard.Data
{
    public class ThemeRepository : EntityRepository<Theme>, IThemeRepository
    {
        public ThemeRepository(DbContext context, bool sharedContext)
            : base(context, sharedContext) { }

        public Theme GetBy(int id)
        {
            return Find(r => r.Id == id);
        }

        public IEnumerable<Theme> GetFor(User user)
        {
            return user.Themes.OrderByDescending(r => r.DateCreated);
        }

        public void AddFor(Theme ribbit, User user)
        {
            user.Themes.Add(ribbit);

            if (!ShareContext)
            {
                Context.SaveChanges();
            }
        }
    }
}