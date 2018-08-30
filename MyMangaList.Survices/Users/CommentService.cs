namespace MyMangaList.Services.Users
{
    using AutoMapper;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using MyMangaList.Data;
    using MyMangaList.DtoModels.BindingModels;
    using MyMangaList.DtoModels.MixedModels;
    using MyMangaList.DtoModels.ViewModels;
    using MyMangaList.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CommentService : Service
    {
        public CommentService(MyMangaListContext context, IMapper mapper) 
            : base(context, mapper)
        {
        }

        public CommentViewBindingModel GetAllComments(int id)
        {
            var comments = this.Context
                .Comments
                .Include(c => c.User)
                .Where(c => c.MangaId == id)
                .ToList();

            var bindingModel = new CommentBindingModel();
            var model = new CommentViewBindingModel() { BindingModel = bindingModel };
            MapToCommentModel(id, comments, model);

            return model;
        }

        public void AddComment(string currentUserName , string content , int mangaId)
        {
            var currentUser = this.FindUserByName(currentUserName);

            var comment = new MyMangaList.Models.Comment()
            {
                Content = content,
                User = currentUser,
                MangaId = mangaId,
                Date = DateTime.Now
            };
            this.Context.Comments.Add(comment);
            this.Context.SaveChanges();

        }

        private static void MapToCommentModel(int id, List<Comment> comments, CommentViewBindingModel model)
        {
            model.BindingModel.MangaId = id;

            foreach (var comment in comments)
            {
                var viewModel = new CommentViewModel()
                {
                    Content = comment.Content,
                    User = comment.User.UserName,
                    Date = comment.Date.ToString()
                };
                model.ViewModels.Add(viewModel);
            }
        }
    }
}
