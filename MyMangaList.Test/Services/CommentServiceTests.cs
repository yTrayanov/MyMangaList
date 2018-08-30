namespace MyMangaList.Test.Services
{
    using AutoMapper;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MyMangaList.Data;
    using MyMangaList.Models;
    using MyMangaList.Services.Users;
    using MyMangaList.Test.Mocks;
    using System;
    using System.Linq;

    [TestClass]
    public class CommentServiceTests
    {
        private MyMangaListContext dbContext;
        private IMapper mapper;

        [TestMethod]
        public void GetAllComments_WithAFewComments_ReturnAll()
        {
            var user1 = new User() { Id = "1", UserName = "user1", Email = "email@abv.bg" };
            var story = @"Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of de Finibus Bonorum et Malorum (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, Lorem ipsum dolor sit amet.., comes from a line in section 1.10.32.";

            var manga = new Manga() { Title = "Title1", Author = user1, ShortDescription = "dsadas", Story = story };

            var comment1 = new Comment() {Id =1 ,User = user1 ,Manga = manga ,Date = DateTime.Now , Content="hello" ,};
            var comment2 = new Comment() { Id = 2, User = user1, Manga = manga, Date = DateTime.Now, Content = "hi", };

            this.dbContext.Comments.Add(comment1);
            this.dbContext.Comments.Add(comment2);
            this.dbContext.SaveChanges();

            var commentService = new CommentService(dbContext, mapper);

            var comments = commentService.GetAllComments(manga.Id);

            Assert.AreEqual(2, comments.ViewModels.Count);

        }

        [TestMethod]
        public void AddComment_Valid()
        {
            var user = new User() { Id = "1", UserName = "user1", Email = "email@abv.bg" };
            var story = @"Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of de Finibus Bonorum et Malorum (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, Lorem ipsum dolor sit amet.., comes from a line in section 1.10.32.";
            var manga = new Manga() { Title = "Title1", Author = user, ShortDescription = "dsadas", Story = story };
            var commentContent = "This manga is the best";
            var commentService = new CommentService(dbContext, mapper);

            commentService.AddComment(user.UserName, commentContent, manga.Id);
            commentService.AddComment(user.UserName, commentContent, manga.Id);

            Assert.AreEqual(2, this.dbContext.Comments.ToList().Count);
            
        }



        [TestInitialize]
        public void InicializeTets()
        {
            this.dbContext = MockDbContext.GetDbContext();
            this.mapper = MockAutoMapper.GetMapper();
        }
    }
}
