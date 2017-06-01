using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ImageBoard.Models;
using ImageBoard.Data;
using ImageBoard.ViewModel;

namespace ImageBoard.Service
{
    public class ProfileService
    {
        private readonly IContext _context;
        private readonly IProfileRepository _profiles;

        public ProfileService(IContext context)
        {
            _context = context;
            _profiles = context.Profiles;
        }

        public Profile GetBy(int id)
        {
            return _profiles.Find(p => p.Id == id);
        }

        public void Update(ProfileModel model)
        {
            var profile = new Profile()
            {
                Id = model.Id,
                Sex = model.Sex,
                Email = model.Email,
                Name = model.Name,
                SubName = model.SubName,
                Birthday = model.Birthday
            };

            _profiles.Update(profile);

            _context.SaveChanges();
        }
    }
}