namespace MyMangaList.Web.Areas.Users.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using MyMangaList.Data;
    using MyMangaList.DtoModels.MixedModels;
    using MyMangaList.Models;
    using MyMangaList.Services.Users;
    using System.Linq;
    using System.Threading.Tasks;
    using Constants;

    public class HomeController : UsersController
    {
        private HomeService homeService;

        public HomeController(UserManager<User> userManager , HomeService homeService) 
            : base(userManager)
        {
            this.homeService = homeService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var models = this.homeService.GetAllManga();

            return View(models);
        }


        [HttpGet]
        public async Task<IActionResult> Friends()
        {
            var currentUser = await UserManager.GetUserAsync(this.User);

            var model = this.homeService.GetUserFriends(currentUser.UserName);


            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Friends(UsersVewBindingModel model)
        {
            var currentUser = await this.UserManager.GetUserAsync(this.User);
            var friend = this.homeService.FindUserByName(model.BindingModel.Username);

            if (friend == null)
            {
                ModelState.AddModelError("Not Found", "This user doesn't exist. Please try again.");
                var friendsModel = this.homeService.GetUserFriends(currentUser.UserName);
                return View(friendsModel);
            }

            this.homeService.SendRequest(currentUser.UserName, friend.UserName, Constants.FriendRequestString);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> RemoveFriend(string username)
        {
            var currentUser = await this.UserManager.GetUserAsync(this.User);

            this.homeService.RemoveFriend(username, currentUser.UserName);

            return RedirectToAction("Friends", "Home");
        }
    }
}