namespace MyMangaList.Web.Areas.Users.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using MyMangaList.Data;
    using MyMangaList.Models;
    using MyMangaList.Services.Users;
    using MyMangaList.DtoModels.BindingModels;
    using MyMangaList.DtoModels.MixedModels;
    using MyMangaList.DtoModels.ViewModels;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Constants;

    public class GroupController : UsersController
    {
        private GroupService groupService;

        public GroupController(UserManager<User> userManager , GroupService groupService) 
            : base(userManager)
        {
            this.groupService = groupService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var currentUser = await this.UserManager.GetUserAsync(this.User);

            var model = this.groupService.GetAllGroups(currentUser.UserName);

            return View(model);
        }

        [HttpGet]
        public IActionResult CreateGroup()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateGroup(GroupBindingModel model)
        {
            var currentUser = await this.UserManager.GetUserAsync(this.User);

            var id = this.groupService.CreateGroup(model.Title , currentUser.UserName);

            return RedirectToAction("Details", "Group", new { id});
        }

        [HttpGet]
        public IActionResult Details(int id )
        {
            var model = this.groupService.GetDetailsOfGroup(id);

            return this.View(model);
        }

        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }

        //Add model state!
        [HttpPost]
        public async Task<IActionResult> AddUser(int id,UserAddBindingModel model)
        {
            var currentUser = await this.UserManager.GetUserAsync(this.User);
            var user = this.groupService.FindUserByName(model.Username);

            if (user == null)
            {
                ModelState.AddModelError("Not Found", "This user doesn't exist. Please try again.");
                return View();
            }

            this.groupService.AddUserToGroup(id, user.Id);

            return RedirectToAction("Index","Group");
        }
        
        [HttpGet]
        public async Task<IActionResult> LeaveGroup(int id)
        {
            var currentUser = await this.UserManager.GetUserAsync(this.User);


            this.groupService.LeaveGroup(currentUser.UserName, id);

            return RedirectToAction("Index", "Group");
        }

        [HttpGet]
        public IActionResult Chat(int id)
        {
            var model = this.groupService.GetAllMessagesOfGroup(id);

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Chat(GroupViewBindingModel model , int id)
        {
            var currentUser = await this.UserManager.GetUserAsync(this.User);
            this.groupService.AddMessageToGroup(id, currentUser.UserName, model.BindingModel.Content);

            return RedirectToAction("Chat" , "Group" , new { id});
        }

    }
}