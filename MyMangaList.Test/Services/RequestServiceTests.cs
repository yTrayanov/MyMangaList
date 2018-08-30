using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyMangaList.Data;
using MyMangaList.Models;
using MyMangaList.Services.Users;
using MyMangaList.Test.Mocks;
using System.Linq;

namespace MyMangaList.Test.Services
{
    [TestClass]
    public class RequestServiceTests
    {
        private MyMangaListContext dbContext;
        private IMapper mapper;

        [TestMethod]
        public void GetAllRequests()
        {
            User user1 = AddToDatabase();

            var requestService = new RequestService(dbContext, mapper);
            var models = requestService.GetAllRequests(user1.Id);

            Assert.AreEqual(1, models.ToList().Count);
        }

        [TestMethod]
        public void AcceptRequest()
        {
            User user1 = AddToDatabase();
            var user2 = this.dbContext.Users.FirstOrDefault(u => u.Id == "2");
            var request = this.dbContext.Requests.Find(1);
            
            var requestService = new RequestService(dbContext, mapper);

            requestService.AcceptRequest(user1.UserName, user2.Id, request.Id);

            Assert.AreEqual(0, this.dbContext.Requests.ToList().Count);
            Assert.AreEqual(1, this.dbContext.Friends.ToList().Count);
        }

        [TestMethod]
        public void DeclineRequest()
        {
            User user = AddToDatabase();
            var request = this.dbContext.Requests.FirstOrDefault();

            var requestService = new RequestService(dbContext, mapper);

            requestService.DeclineRequest(request.Id);

            Assert.AreEqual(0, this.dbContext.Requests.ToList().Count);
        }

        private User AddToDatabase()
        {
            var user1 = new User() { Id = "1", UserName = "user1", Email = "email@abv.bg" };
            var user2 = new User() { Id = "2", UserName = "user2", Email = "email@abv.bg" };
            var request = new Request()
            {
                Id = 1,
                Content = "fdsasad",
                User = user1,
                Author = user2.UserName,
            };
            dbContext.Users.Add(user2);
            dbContext.Requests.Add(request);
            dbContext.SaveChangesAsync();
            return user1;
        }

        [TestInitialize]
        public void InicializeTests()
        {
            this.dbContext = MockDbContext.GetDbContext();
            this.mapper = MockAutoMapper.GetMapper();
        }
    }
}
