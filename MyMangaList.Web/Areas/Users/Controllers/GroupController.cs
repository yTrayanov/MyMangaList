using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyMangaList.Data;
using MyMangaList.Models;
using MyMangaList.Services.Users;
using MyMangaList.ViewModels.BindingModels;
using MyMangaList.ViewModels.MixedModels;
using MyMangaList.ViewModels.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMangaList.Web.Areas.Users.Controllers
{
    public class GroupController : UsersController
    {
        public GroupController(MyMangaListContext context, UserManager<User> userManager, IMapper mapper, HomeService homeService) 
            : base(context, userManager, mapper, homeService)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var currentUser = await this.UserManager.GetUserAsync(this.User);

            var usersInGroups = this.Context
                .UsersInGrouos
                .Where(ug => ug.UserId == currentUser.Id);

            var groups = new List<MyMangaList.Models.Group>();
            foreach (var userInGroup in usersInGroups)
            {
                if (userInGroup.UserId == currentUser.Id)
                {
                    var group = this.Context.Groups.FirstOrDefault(g => g.Id == userInGroup.GroupId);
                    groups.Add(group);
                }
            }

            var model = new List<GroupViewModel>();

            foreach (var group in groups)
            {
                var gv = new GroupViewModel()
                {
                    Id = group.Id,
                    Title = group.Title,
                };
                model.Add(gv);
            }

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

            var group = new MyMangaList.Models.Group()
            {
                Title = model.Title,
                Creator = currentUser.UserName
            };

            var userGroup = new UsersInGroups()
            {
                User = currentUser,
                Group = group
            };
            this.Context.UsersInGrouos.Add(userGroup);
            this.Context.SaveChanges();

            return RedirectToAction("Details", "Group", new { group.Id});
        }

        [HttpGet]
        public IActionResult Details(int id )
        {
            var userGroup = this.Context
                .UsersInGrouos
                .Where(g => g.GroupId == id)
                .ToList();

            var group = this.Context.Groups.Find(id);

            var model = new GroupViewModel()
            {
                Title = group.Title,
                Creator = group.Creator,
                Members = new List<User>()
                
            };

            foreach (var member in userGroup)
            {
                var user = this.Context.Users.FirstOrDefault(u => u.Id == member.UserId);
                model.Members.Add(user);
            }

            return this.View(model);
        }

        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUser(int id,UserAddBindingModel model)
        {
            var user = this.Context.Users.FirstOrDefault(u => u.UserName == model.Username);
            if (user == null)
            {
                return NotFound();
            }

            var group = this.Context.Groups.Find(id);
            var userGroup = new UsersInGroups() { UserId = user.Id, GroupId = id };

            if (!group.Users.Contains(userGroup))
            {
                this.Context.UsersInGrouos.Add(userGroup);
                this.Context.SaveChanges();
            }

            return RedirectToAction("Details","Group",new {group.Id });
        }
        
        [HttpGet]
        public async Task<IActionResult> LeaveGroup(int id)
        {
            var currentUser = await this.UserManager.GetUserAsync(this.User);
            

            var userInGroup = await this.Context.UsersInGrouos
                .FirstOrDefaultAsync(g => g.UserId == currentUser.Id && g.GroupId == id);
            
            this.Context.UsersInGrouos.Remove(userInGroup);
            this.Context.SaveChanges();

            var group = this.Context.Groups.Find(id);
            var membersLeft = this.Context.UsersInGrouos
                .Any(ug => ug.GroupId == id);

            if (!membersLeft)
            {
                this.Context.Groups.Remove(group);
                this.Context.SaveChanges();
            }

            return RedirectToAction("Index", "Group");
        }

        [HttpGet]
        public IActionResult Chat(int id)
        {
            var messages = this.Context.Messages
                .Include(m => m.User)
                .Where(m => m.GroupId == id)
                .ToList();

            var groupName = this.Context.Groups.FirstOrDefault(g => g.Id == id).Title;

            var messagesCollection = this.Mapper
                .Map<IEnumerable<MessageViewModel>>(messages)
                .ToList();

            var model = new GroupViewBindingModel()
            {
                GroupId = id,
                GroupTitle = groupName,
                ViewModel = messagesCollection,
            };

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Chat(GroupViewBindingModel model , int id)
        {
            var currentUser = await this.UserManager.GetUserAsync(this.User);
            var group = this.Context.Groups.FirstOrDefault(g => g.Id == id);

            var message = new Message()
            {
                User = currentUser,
                Group = group,
                Content = model.BindingModel.Content
            };
            


            this.Context.Messages.Add(message);
            this.Context.SaveChanges();

            return RedirectToAction("Chat" , "Group" , new { id});
        }

    }
}