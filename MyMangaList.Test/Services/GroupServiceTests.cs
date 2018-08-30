namespace MyMangaList.Test.Services
{
    using AutoMapper;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MyMangaList.Data;
    using MyMangaList.DtoModels.ViewModels;
    using MyMangaList.Models;
    using MyMangaList.Services.Users;
    using MyMangaList.Test.Mocks;
    using System.Linq;

    [TestClass]
    public class GroupServiceTests
    {
        private MyMangaListContext dbContext;
        private IMapper mapper;

        [TestMethod]
        public void GetAllGroups_WithAFewGroups_ReturnAll()
        {
            var user1 = new User() { Id = "1", UserName = "user1", Email = "email@abv.bg" };
            var user2 = new User() { Id = "2", UserName = "user2", Email = "email@abv.bg" };

            var group1 = new Group() { Id = 1, Creator = user1.UserName, Title = "group1" };
            var group2 = new Group() { Id = 2, Creator = user1.UserName, Title = "group2" };
            var group3 = new Group() { Id = 3, Creator = user2.UserName, Title = "group3" };

            var userInGroup1 = new UsersInGroups() { Id = 1, User = user1, Group = group1 };
            var userInGroup2 = new UsersInGroups() { Id = 2, User = user1, Group = group2 };
            var userInGroup3 = new UsersInGroups() { Id = 3, User = user2, Group = group3 };

            this.dbContext.UsersInGrouos.Add(userInGroup1);
            this.dbContext.UsersInGrouos.Add(userInGroup2);
            this.dbContext.UsersInGrouos.Add(userInGroup3);
            this.dbContext.Groups.Add(group1);
            this.dbContext.Groups.Add(group2);
            this.dbContext.Groups.Add(group3);
            this.dbContext.SaveChanges();

            var groupService = new GroupService(dbContext, mapper);

            var groups = groupService.GetAllGroups(user1.UserName).ToList();

            Assert.AreEqual(2, groups.Count);
        }

        [TestMethod]
        public void CreateGroup()
        {
            var user1 = new User() { Id = "1", UserName = "user1", Email = "email@abv.bg" };
            this.dbContext.Users.Add(user1);
            this.dbContext.SaveChanges();

            var groupService = new GroupService(dbContext, mapper);

            var group1 = groupService.CreateGroup("group1", user1.UserName);
            var group2 = groupService.CreateGroup("group2", user1.UserName);

            Assert.AreEqual(2, this.dbContext.Groups.ToList().Count);
            Assert.AreEqual(2, this.dbContext.UsersInGrouos.ToList().Count);

        }

        [TestMethod]
        public void GetDetailsOfGroup_WithMembers_ReturnAll()
        {
            var user1 = new User() { Id = "1", UserName = "user1", Email = "email@abv.bg" };
            var user2 = new User() { Id = "2", UserName = "user2", Email = "email@abv.bg" };
            var group1 = new Group() { Id = 1, Creator = user1.UserName, Title = "group1" };
            var userInGroup1 = new UsersInGroups() { Id = 1, User = user1, Group = group1 };
            var userInGroup2 = new UsersInGroups() { Id = 1, User = user2, Group = group1 };
            this.dbContext.UsersInGrouos.Add(userInGroup1);
            this.dbContext.UsersInGrouos.Add(userInGroup2);
            this.dbContext.SaveChanges();

            var groupService = new GroupService(dbContext, mapper);

            var model = groupService.GetDetailsOfGroup(group1.Id);

            Assert.AreEqual(2, model.Members.Count);
        }

        [TestMethod]
        public void AddUserToGroup_AddAFewUsers_ReturnAll()
        {
            var user1 = new User() { Id = "1", UserName = "user1", Email = "email@abv.bg" };
            var user2 = new User() { Id = "2", UserName = "user2", Email = "email@abv.bg" };
            var group1 = new Group() { Id = 1, Creator = user1.UserName, Title = "group1" };
            this.dbContext.Users.Add(user1);
            this.dbContext.Users.Add(user2);
            this.dbContext.Groups.Add(group1);
            this.dbContext.SaveChanges();

            var groupService = new GroupService(dbContext, mapper);
            groupService.AddUserToGroup(group1.Id, user1.UserName);
            groupService.AddUserToGroup(group1.Id, user2.UserName);

            Assert.AreEqual(2, this.dbContext.UsersInGrouos.ToList().Count);
        }

        [TestMethod]
        public void LeaveGroup()
        {

            var user1 = new User() { Id = "1", UserName = "user1", Email = "email@abv.bg" };
            var user2 = new User() { Id = "2", UserName = "user2", Email = "email@abv.bg" };
            var group1 = new Group() { Id = 1, Creator = user1.UserName, Title = "group1" };
            var userInGroup1 = new UsersInGroups() { Id = 1, User = user1, Group = group1 };
            var userInGroup2 = new UsersInGroups() { Id = 1, User = user2, Group = group1 };
            this.dbContext.Users.Add(user1);
            this.dbContext.Groups.Add(group1);
            this.dbContext.UsersInGrouos.Add(userInGroup1);
            this.dbContext.UsersInGrouos.Add(userInGroup2);
            this.dbContext.SaveChanges();

            var groupService = new GroupService(dbContext, mapper);

            groupService.LeaveGroup(user2.UserName,group1.Id);


            Assert.AreEqual(1, this.dbContext.UsersInGrouos.ToList().Count);
        }

        [TestMethod]
        public void GetAllMessagesOfGroup_WithAFewMessages_ReturnAll()
        {

            var user1 = new User() { Id = "1", UserName = "user1", Email = "email@abv.bg" };
            var group1 = new Group() { Id = 1, Creator = user1.UserName, Title = "group1" };
            var message1 = new Message() { Id = 1, Group = group1, User = user1, Content = "Hello" };
            var message2 = new Message() { Id = 2, Group = group1, User = user1, Content = "Hello" };
            this.dbContext.Messages.Add(message1);
            this.dbContext.Messages.Add(message2);
            this.dbContext.SaveChanges();

            var groupService = new GroupService(dbContext, mapper);

            var messages = groupService.GetAllMessagesOfGroup(group1.Id);

            Assert.AreEqual(2, messages.ViewModel.ToList().Count);

        }
        [TestMethod]
        public void AddMessageToGroup()
        {
            var user1 = new User() { Id = "1", UserName = "user1", Email = "email@abv.bg" };
            var group1 = new Group() { Id = 1, Creator = user1.UserName, Title = "group1" };
            this.dbContext.Add(user1);
            this.dbContext.Add(group1);
            this.dbContext.SaveChanges();

            var groupService = new GroupService(dbContext, mapper);

            groupService.AddMessageToGroup(group1.Id, user1.UserName, "Hello");
            groupService.AddMessageToGroup(group1.Id, user1.UserName, "Hi");

            Assert.AreEqual(2, this.dbContext.Messages.ToList().Count);
        }


        [TestInitialize]
        public void InicializeTets()
        {
            this.dbContext = MockDbContext.GetDbContext();
            this.mapper = MockAutoMapper.GetMapper();
        }
    }
}
