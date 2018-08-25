namespace MyMangaList.Web.Areas.Users.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using MyMangaList.Common;
    using MyMangaList.Data;
    using MyMangaList.Models;
    using MyMangaList.Services.Users;

    [Area("Users")]
    [Authorize(Roles = Constants.User)]
    public class UsersController : Controller
    {
        protected UsersController(MyMangaListContext context, UserManager<User> userManager, IMapper mapper, HomeService homeService)
        {
            this.Context = context;
            this.UserManager = userManager;
            this.Mapper = mapper;
            this.HomeService = homeService;
        }

        protected MyMangaListContext Context { get; set; }
        protected UserManager<User> UserManager { get; set; }
        protected IMapper Mapper { get; set; }
        public HomeService HomeService { get; set; }
    }   
}