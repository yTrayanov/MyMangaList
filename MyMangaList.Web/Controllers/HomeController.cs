namespace MyMangaList.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MyMangaList.Constants;
    using MyMangaList.Web.Models;
    using System.Diagnostics;

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (this.User.IsInRole(Constants.User))
            {
                return RedirectToAction("Index", "Home", new { Area = "Users" });
            }
            else if(this.User.IsInRole(Constants.Administrator))
            {
                return RedirectToAction("Index", "Home", new { Area = "Admin" });
            }
            else
            {
                return View();
            }
            
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
