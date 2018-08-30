using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyMangaList.Data;
using MyMangaList.Models;
using MyMangaList.DtoModels.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMangaList.Web.Areas.Admin.Controllers
{
    public class UsersController : AdminController
    {
        public UsersController(MyMangaListContext context, IMapper mapper, UserManager<User> userManager)
            : base(context, mapper, userManager)
        {
        }

        public async Task<IActionResult> Index()
        {
            var currentUser = await this.UserManager.GetUserAsync(this.User);
            var users = this.Context.Users
                .Where(u => u.Id != currentUser.Id)
                .ToList();

            var model = this.Mapper.Map<IEnumerable<UserConsiceViewModel>>(users);

            return this.View(model);
        }

        public async Task<IActionResult> Details(string id)
        {
            var currentUser = await this.UserManager.GetUserAsync(this.User);
            if (id == currentUser.Id)
            {
                return Unauthorized();
            }

            var user = await this.Context.Users.FindAsync(id);

            var roles = await this.UserManager.GetRolesAsync(user);
            var model = this.Mapper.Map<UserDetailsViewModel>(user);
            return View(model);
        }
    }
}