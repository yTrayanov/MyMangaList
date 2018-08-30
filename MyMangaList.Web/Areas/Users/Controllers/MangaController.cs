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
    using MyMangaList.DtoModels.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using MyMangaList.Mapper;

    public class MangaController : UsersController
    {
        private MangaService mangaService;

        public MangaController(UserManager<User> userManager , MangaService mangaService) 
            : base(userManager)
        {
            this.mangaService = mangaService;
        }

        [HttpGet]
        public IActionResult Write()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Write(MangaBindingModel model)
        {
            var currentUser = await UserManager.GetUserAsync(User);

            var id = this.mangaService.AddManga(currentUser.UserName, model);

            return RedirectToAction("Details", "Manga", new { id });
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var model = this.mangaService.GetMangaDetails(id);
            return View(model);
        }

        [HttpGet]
        public IActionResult ReadStory(int id)
        {
            var model = this.mangaService.GetMangaStory(id);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Favour(int id)
        {
            var currentUser = await UserManager.GetUserAsync(this.User);

            this.mangaService.FavourManga(currentUser.Id, id);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Favourites()
        {
            var currentUser = await UserManager.GetUserAsync(this.User);
            var models = this.mangaService.GetFavouriteManga(currentUser.Id);
            return this.View(models);
        }

        [HttpGet]
        public async Task<IActionResult> UnFavour(int id)
        {
            var currentUser = await this.UserManager.GetUserAsync(this.User);

            this.mangaService.UnFavourManga(currentUser.Id, id);

            return RedirectToAction("Favourites", "Manga");
        }
    }
}