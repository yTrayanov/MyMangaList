namespace MyMangaList.Test.Services
{
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MyMangaList.Data;
    using MyMangaList.Mapper.Mapping;
    using MyMangaList.Models;
    using MyMangaList.Services.Users;
    using MyMangaList.Test.Mocks;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    [TestClass]
    public class HomeServiceTest
    {
        private MyMangaListContext dbContext;
        private IMapper mapper;

        [TestMethod]
        public void GetUserFriends_WithSomeFriends_ReturnAll()
        {
            this.dbContext.Friends.Add(new Friend()
            { Id = 1,User = new User() { Id = "1", UserName = "user1", Email = "email@abv.bg" },
                Contract = new User() { Id = "2", UserName = "user2", Email = "email@abv.bg" } });


            this.dbContext.Friends.Add(new Friend()
            {
                Id = 2,
                User = new User() { Id = "1", UserName = "user1", Email = "email@abv.bg" },
                Contract = new User() { Id = "3", UserName = "user3", Email = "email@abv.bg" }
            });
            dbContext.SaveChanges();

            var homeService = new HomeService(dbContext, AutoMapper.Mapper.Instance);

            var friends = homeService.GetUserFriends("user1");

            Assert.AreEqual(2, friends.ViewModel.Count);
        }

        [TestMethod]
        public void GetAllManga_WithAFewmanga_ReturnAll()
        {
            var user1 = new User() { Id = "1", UserName = "user1", Email = "email@abv.bg" };
            var user2  = new User() { Id = "2", UserName = "user2", Email = "email@abv.bg" };

            var story = @"Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of de Finibus Bonorum et Malorum (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, Lorem ipsum dolor sit amet.., comes from a line in section 1.10.32.";

            this.dbContext.Manga.Add(new Manga() { Title = "Title1", Author = user1, ShortDescription = "dsadas", Story = story });
            this.dbContext.Manga.Add(new Manga() { Title = "Title2", Author = user2, ShortDescription = "dsadas", Story = story });

            this.dbContext.SaveChanges();

            var homeService = new HomeService(dbContext ,mapper);

            var manga = homeService.GetAllManga().ToList();

            Assert.AreEqual(2, manga.Count);
            
        }

        [TestMethod]
        public void AddFriend_WithUsers_ReturnAll()
        {
            var user1 = new User() { Id = "1", UserName = "user1", Email = "email@abv.bg" };
            var user2 = new User() { Id = "2", UserName = "user2", Email = "email@abv.bg" };

            var user3 = new User() { Id = "3", UserName = "user3", Email = "email@abv.bg" };
            var user4 = new User() { Id = "4", UserName = "user4", Email = "email@abv.bg" };

            this.dbContext.Users.Add(user1);
            this.dbContext.Users.Add(user2);
            this.dbContext.Users.Add(user3);
            this.dbContext.Users.Add(user4);
            this.dbContext.SaveChanges();

            var homeService = new HomeService(dbContext, mapper);
            homeService.AddFriend(user1.UserName, user2.UserName);
            homeService.AddFriend(user3.UserName, user4.UserName);

            int friends = this.dbContext.Friends.ToList().Count;

            Assert.AreEqual(2, friends);
        }

        [TestMethod]
        public void RemoveFriend()
        {
            var user1 = new User() { Id = "1", UserName = "user1", Email = "email@abv.bg" };
            var user2 = new User() { Id = "2", UserName = "user2", Email = "email@abv.bg" };

            var user3 = new User() { Id = "3", UserName = "user3", Email = "email@abv.bg" };
            var user4 = new User() { Id = "4", UserName = "user4", Email = "email@abv.bg" };

            this.dbContext.Users.Add(user1);
            this.dbContext.Users.Add(user2);
            this.dbContext.Users.Add(user3);
            this.dbContext.Users.Add(user4);

            this.dbContext.Friends.Add(new Friend() {Id = 1 , User = user1 , Contract = user2});
            this.dbContext.Friends.Add(new Friend() { Id = 2, User = user3, Contract = user4 });

            this.dbContext.SaveChanges();

            var homeService = new HomeService(dbContext, mapper);

            homeService.RemoveFriend("user2", "user1");

            var friends = this.dbContext.Friends.ToList();

            Assert.AreEqual(1, friends.Count);
        }

        [TestInitialize]
        public void InicializeTets()
        {
            this.dbContext = MockDbContext.GetDbContext();
            this.mapper = MockAutoMapper.GetMapper();
        }
    }
}
