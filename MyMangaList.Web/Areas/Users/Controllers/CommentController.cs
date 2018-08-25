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
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MyMangaList.Web.Areas.Users.Controllers
{
    public class CommentController : UsersController
    {
        public CommentController(MyMangaListContext context, UserManager<User> userManager, IMapper mapper, HomeService homeService) 
            : base(context, userManager, mapper, homeService)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            var currentUser = await this.UserManager.GetUserAsync(this.User);

            var comments = this.Context
                .Comments
                .Include(c => c.User)
                .Where(c => c.MangaId == id);

            var bindingModel = new CommentBindingModel();
            var model = new CommentViewBindingModel() { BindingModel = bindingModel};

            model.BindingModel.MangaId = id;

            foreach (var comment in comments)
            {
                var viewModel = new CommentViewModel()
                {
                    Content = comment.Content,
                    User = comment.User.UserName,
                    Date = comment.Date.ToString()
                };
                model.ViewModels.Add(viewModel);
            }


            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(CommentViewBindingModel model , int id)
        {
            var currentUser = await this.UserManager.GetUserAsync(this.User);

            var comment = new MyMangaList.Models.Comment()
            {
                Content = model.BindingModel.Content,
                User = currentUser,
                MangaId = id,
                Date = DateTime.Now
            };
            this.Context.Comments.Add(comment);
            this.Context.SaveChanges();

            return RedirectToAction("Index", "Comment");
        }
    }
}