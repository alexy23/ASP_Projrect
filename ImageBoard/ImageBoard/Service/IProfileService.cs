using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ImageBoard.Models;
using ImageBoard.ViewModel;

namespace ImageBoard.Service
{
    interface IProfileService
    {
        Profile GetBy(int id);
        void Update(ProfileModel model);
    }
}
