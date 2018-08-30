namespace MyMangaList.Web.Areas.Users.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
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
    

    public class CommentController : UsersController
    {
        private CommentService commentService;

        public CommentController(UserManager<User> userManager , CommentService commentService) 
            : base(userManager)
        {
            this.commentService = commentService;
        }
    
        

        [HttpGet]
        public IActionResult Index(int id)
        {
            var model = this.commentService.GetAllComments(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(CommentViewBindingModel model , int id)
        {
            var currentUser = await this.UserManager.GetUserAsync(this.User);

            this.commentService.AddComment(currentUser.UserName, model.BindingModel.Content, id);

            return RedirectToAction("Index", "Comment");
        }
    }
}