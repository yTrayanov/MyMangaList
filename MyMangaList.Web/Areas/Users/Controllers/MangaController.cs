using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyMangaList.Data;
using MyMangaList.Models;
using MyMangaList.Services.Users;
using MyMangaList.ViewModels.BindingModels;
using MyMangaList.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyMangaList.Mapper;

namespace MyMangaList.Web.Areas.Users.Controllers
{
    public class MangaController : UsersController
    {
        public MangaController(MyMangaListContext context, UserManager<User> userManager, IMapper mapper, HomeService homeService) 
            : base(context, userManager, mapper, homeService)
        {
        }

        [HttpGet]
        public IActionResult Write()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Write(MangaBindingModel model)
        {
            var currentUser = UserManager.GetUserId(User);
            var user = this.Context.Users.Find(currentUser);


            var manga = new MyMangaList.Models.Manga()
            {
                Title = model.Title,
                Image = model.Image,
                Genre = model.Genre,
                ShortDescription = model.ShortDescription,
                Story = model.Story,
                AuthorId = user.Id,
                Date = DateTime.Now,
                LastUpdated = DateTime.Now
            };

            user.MangaWritten.Add(manga);
            this.Context.Manga.Add(manga);
            this.Context.SaveChanges();

            return RedirectToAction("Details", "Manga", new { manga.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var manga = await this.Context
                .Manga
                .Include(m => m.Author)
                .FirstOrDefaultAsync(m => m.Id == id);

            var model = this.Mapper.Map<MangaDetailsViewModel>(manga);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ReadStory(int id)
        {
            var manga = await this.Context.Manga.FindAsync(id);

            var model = new StoryViewModel()
            {
                MangaId = manga.Id,
                Story = manga.Story,
                Title = manga.Title,
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Favour(int id)
        {
            var currentUser = await UserManager.GetUserAsync(this.User);

            var manga = new UserManga() { UserId = currentUser.Id, MangaId = id };

            if (!this.Context.UsersManga.Any(m => m.UserId == manga.UserId && m.MangaId == manga.MangaId))
            {
                this.Context.UsersManga.Add(manga);
                this.Context.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Favourites()
        {
            var currentUser = await UserManager.GetUserAsync(this.User);
            var mangaList = new List<MyMangaList.Models.Manga>();

            foreach (var userManga in this.Context.UsersManga)
            {
                var model = this.Context.Manga
                    .FirstOrDefault(m => m.Id == userManga.MangaId && userManga.UserId == currentUser.Id);

                mangaList.Add(model);
            }

            var models = this.Mapper.Map<IEnumerable<MangaDetailsViewModel>>(mangaList);

            return this.View(models);
        }

        [HttpGet]
        public async Task<IActionResult> UnFavour(int Id)
        {
            var currentUser = await this.UserManager.GetUserAsync(this.User);
            var manga = this.Context.UsersManga.FirstOrDefault(m => m.MangaId == Id && m.UserId ==currentUser.Id );

            this.Context.UsersManga.Remove(manga);
            this.Context.SaveChanges();

            return RedirectToAction("Favourites", "Manga");
        }
    }
}