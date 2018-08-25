using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyMangaList.Common;
using MyMangaList.Data;
using MyMangaList.Models;

namespace MyMangaList.Web.Areas.Admin.Controllers
{
    
    public class HomeController : AdminController
    {
        public HomeController(MyMangaListContext context, IMapper mapper, UserManager<User> userManager) 
            : base(context, mapper, userManager)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}