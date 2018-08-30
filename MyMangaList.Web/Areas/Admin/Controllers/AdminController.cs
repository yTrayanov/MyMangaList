namespace MyMangaList.Web.Areas.Admin.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using MyMangaList.Constants;
    using MyMangaList.Data;
    using MyMangaList.Models;

    [Area("Admin")]
    [Authorize(Roles = Constants.Administrator)]
    public class AdminController : Controller
    {
        public AdminController(
            MyMangaListContext context,
            IMapper mapper,
            UserManager<User> userManager)
        {
            this.Context = context;
            this.Mapper = mapper;
            this.UserManager = userManager;
        }


        public MyMangaListContext Context { get; set; }
        public IMapper Mapper { get; set; }
        public UserManager<User> UserManager { get; set; }

    }
}