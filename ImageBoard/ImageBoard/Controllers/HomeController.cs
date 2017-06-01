using System.Web.Mvc;
using ImageBoard.Models;
using System.Linq;
using ImageBoard.Controllers;
using ImageBoard.ViewModel;

namespace ImageBoard.Controllers
{
    public class HomeController : ImageControllerBase
    {
        //
        // GET: /Home/
        MainContext _db = new MainContext();
        LoginModel Temp = new LoginModel();
        ModelPostThemeAll UserAndTheme = new ModelPostThemeAll();

        public ActionResult Index()
        {
            return View();
        }
    }
}
