namespace MyMangaList.Services.Users
{
    using AutoMapper;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using MyMangaList.Data;
    using MyMangaList.DtoModels.BindingModels;
    using MyMangaList.DtoModels.ViewModels;
    using MyMangaList.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MangaService : Service
    {
        public MangaService(MyMangaListContext context, IMapper mapper) 
            : base(context, mapper)
        {
        }

        public int AddManga(string currentUserName , MangaBindingModel model)
        {
            var user = this.FindUserByName(currentUserName);
            Manga manga = MapFromModelToManga(model, user);

            this.Context.Manga.Add(manga);
            this.Context.SaveChanges();

            return manga.Id;

        }

        public MangaDetailsViewModel GetMangaDetails(int id)
        {
            var manga = this.Context
                .Manga
                .Include(m => m.Author)
                .FirstOrDefault(m => m.Id == id);

            var model = this.Mapper.Map<MangaDetailsViewModel>(manga);

            return model;

        }

        //Automapper can be used here!!!
        public StoryViewModel GetMangaStory(int id)
        {
            var manga = this.Context.Manga.Find(id);

           // var model = this.Mapper.Map<StoryViewModel>(manga);

            var model = new StoryViewModel()
            {
                MangaId = manga.Id,
                Story = manga.Story,
                Title = manga.Title,
            };

            return model;
        }

        public IEnumerable<MangaDetailsViewModel> GetFavouriteManga(string userId)
        {
            var mangaList = new List<MyMangaList.Models.Manga>();
            GetManga(userId, mangaList);

            var models = this.Mapper.Map<IEnumerable<MangaDetailsViewModel>>(mangaList);

            return models;

        }


        public void FavourManga(string userId , int mangaId)
        {
            var manga = new UserManga() { UserId = userId, MangaId = mangaId };

            if (!this.Context.UsersManga.Any(m => m.UserId == manga.UserId && m.MangaId == manga.MangaId))
            {
                this.Context.UsersManga.Add(manga);
                this.Context.SaveChanges();
            }
        }

        public void UnFavourManga(string userId , int mangaId)
        {
            var manga = this.Context.UsersManga
                .FirstOrDefault(m => m.MangaId == mangaId && m.UserId == userId);

            this.Context.UsersManga.Remove(manga);
            this.Context.SaveChanges();
        }



        private static Manga MapFromModelToManga(MangaBindingModel model, User user)
        {
            return new Manga()
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
        }


        private void GetManga(string userId, List<Manga> mangaList)
        {
            foreach (var userManga in this.Context.UsersManga)
            {
                var model = this.Context.Manga
                    .FirstOrDefault(m => m.Id == userManga.MangaId && userManga.UserId == userId);

                mangaList.Add(model);
            }
        }
    }
}
