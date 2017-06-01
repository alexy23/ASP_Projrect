using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ImageBoard.Service;
using System.Security.Cryptography;
using System.Text;
using ImageBoard.Models;
using ImageBoard.Data;

namespace ImageBoard.Controllers
{
    public class ImageControllerBase : Controller
    {
        protected IContext DataContext;
        public IAuthorization Auth = new BaseMethods();
        public ISecurityService Security { get; private set; }
        public IUserService Users { get; private set; }

        public ImageControllerBase()
        {
            DataContext = new Context();
            Users = new UserService(DataContext);
            Security = new SecurityService(Users);
            
        }
    }
}
