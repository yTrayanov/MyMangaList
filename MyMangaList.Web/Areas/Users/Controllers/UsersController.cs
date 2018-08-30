namespace MyMangaList.Web.Areas.Users.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using MyMangaList.Constants;
    using MyMangaList.Data;
    using MyMangaList.Models;
    using MyMangaList.Services.Users;

    [Area("Users")]
    [Authorize(Roles = Constants.User)]
    public class UsersController : Controller
    {
        protected UsersController(UserManager<User> userManager)
        {
            this.UserManager = userManager;
        }

        protected UserManager<User> UserManager { get; set; }
    }   
}