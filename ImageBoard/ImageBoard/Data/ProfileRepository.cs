using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ImageBoard.Models;
using System.Data.Entity;

namespace ImageBoard.Data
{
    public class ProfileRepository : EntityRepository<Profile>, IProfileRepository
    {
        public ProfileRepository(DbContext context, bool sharedContext) : base(context, sharedContext) { }
    }
}