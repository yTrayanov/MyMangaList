using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyMangaList.Data;
using MyMangaList.Models;
using MyMangaList.Services.Users;
using MyMangaList.ViewModels.MixedModels;
using MyMangaList.ViewModels.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMangaList.Web.Areas.Users.Controllers
{
    public class HomeController : UsersController
    {
        public HomeController(
            MyMangaListContext context,
            UserManager<User> userManager,
            IMapper mapper,
            HomeService homeService)
            : base(context, userManager, mapper, homeService)
        {
        }


        public IActionResult Index()
        {
            var mangas = this.Context.Manga;
            var models = this.Mapper.Map<IEnumerable<MangaDetailsViewModel>>(mangas);

            return View(models);
        }


        [HttpGet]
        public async Task<IActionResult> Friends()
        {
            var currentUser = await UserManager.GetUserAsync(this.User);

            var model = this.HomeService.GetUserFriends(currentUser.UserName);
            

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Friends(UsersVewBindingModel model)
        {
            var currentUser = await this.UserManager.GetUserAsync(this.User);
            var friend = this.Context.Users.FirstOrDefault(u => u.UserName == model.BindingModel.Username);

            if (friend == null)
            {
                ModelState.AddModelError("Not Found", "This user doesn't exist. Please try again.");
                var friendsModel = this.HomeService.GetUserFriends(currentUser.UserName);
                return View(friendsModel);
            }

            bool DoesUserExist = this.Context.Friends.Any(f => f.UserId == currentUser.Id && f.ContractId == friend.Id);

            if (!DoesUserExist)
            {
                var contract = new Friend()
                {
                    UserId = currentUser.Id,
                    ContractId = friend.Id,
                };

                this.Context.Friends.Add(contract);
                await this.Context.SaveChangesAsync();
            }
            return RedirectToAction("Friends", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> RemoveFriend(string username)
        {
            var currentUser = await this.UserManager.GetUserAsync(this.User);
            var friendUser = this.Context.Users.FirstOrDefault(u => u.UserName == username);

            var friend = this.Context.Friends.FirstOrDefault(f => f.UserId == currentUser.Id && f.ContractId == friendUser.Id);

            this.Context.Friends.Remove(friend);
            this.Context.SaveChanges();

            return RedirectToAction("Friends", "Home");
        }
    }
}